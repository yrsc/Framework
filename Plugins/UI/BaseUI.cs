using UnityEngine;
public class BaseUI : MonoBehaviour {

    protected UIRegisterData _registerData = null;

    public virtual void OnOpen(params object[] data) {

    }

    public virtual void OnClose(params object[] data) {

    }

    public virtual void Release() {

    }

    public void SetRegisterData(UIRegisterData data) {
        _registerData = data;
    }
}