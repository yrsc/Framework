using UnityEngine;
public class FPSHelper : MonoBehaviour {
    private float _fps = 60;
    private GUIStyle _guiStyle = new GUIStyle();
    void Awake() {
        _guiStyle = new GUIStyle();
        _guiStyle.fontSize = 50;

    }
    void Update() {
        _fps = 1 / Time.deltaTime;
        _fps = (int)(_fps * 100) / 100;
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 100), "FPS:" + _fps, _guiStyle);
    }
}