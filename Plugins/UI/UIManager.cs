using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType {
    MainUI,
    GameOver,
}

public class UIRegisterData {
    public string path;
    public int depth;

    public UIRegisterData(string path, int depth) {
        this.path = path;
        this.depth = depth;
    }
}



public class UIManager {

    private static UIManager _instance = null;

    private Dictionary<int, UIRegisterData> _registerData = new Dictionary<int, UIRegisterData>();
    private Dictionary<int, BaseUI> _uiPool = new Dictionary<int, BaseUI>();

    public static UIManager instance {
        get {
            if (_instance == null) {
                _instance = new UIManager();
                _instance.InitRegisterData();
            }
            return _instance;
        }
    }

    private Transform _canvas;
    public void SetCanvas(GameObject canvas) {
        _canvas = canvas.transform;
    }

    public void InitRegisterData() {
        _registerData.Add((int)UIType.MainUI, new UIRegisterData("", 0));
        _registerData.Add((int)UIType.GameOver, new UIRegisterData("UI/GameOver", 10));
    }

    public void OpenUI(UIType type, params object[] data) {
        BaseUI ui = null;
        if (_uiPool.TryGetValue((int)type, out ui)) {
            ui.OnOpen(data);
        } else {
            UIRegisterData registerData = _registerData[(int)type];
            if (registerData != null) {
                var go = ResourceManager.LoadRes<GameObject>(registerData.path);
                go = GameObject.Instantiate(go);
                ui = go.GetComponent<BaseUI>();
                go.transform.SetParent(_canvas, false);
                if (ui == null) {
                    Debug.LogError(string.Format("ui {0} not find baseui component", type));
                } else {
                    ui.SetRegisterData(registerData);
                    ui.OnOpen(data);
                    _uiPool.Add((int)type, ui);
                }
            } else {
                Debug.LogError("can not find uitype " + type);
            }
        }
    }

    public BaseUI CloseUI(UIType type, params object[] data) {
        BaseUI ui = null;
        if (_uiPool.TryGetValue((int)type, out ui)) {
            ui.OnClose(data);
        } else {
            Debug.LogError("Close: can not find ui  " + type);
        }
        return ui;
    }

    public void CloseAndReleaseUI(UIType type, params object[] data) {
        var ui = CloseUI(type, data);
        if (ui != null) {
            _uiPool.Remove((int)type);
            ui.Release();
            GameObject.Destroy(ui.gameObject);
        }
    }
}
