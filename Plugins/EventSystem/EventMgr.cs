using System.Collections.Generic;
using System;
using UnityEngine;

public class EventMgr {
    protected Dictionary<int, Delegate> _events = new Dictionary<int, Delegate>();

    #region 0 param event
    public void RegisterAction(int name, Action callback) {
        Delegate action = null;
        _events.TryGetValue(name, out action);
        if (action != null) {
            Action func = action as Action;
            if (func != null) {
                func += callback;
                _events[name] = func;
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            _events[name] = callback;
        }
    }

    public void UnRegisterAction(int name, Action callback) {
        Delegate action = null;
        _events.TryGetValue(name, out action);
        if (action != null) {
            Action func = action as Action;
            if (func != null) {
                func -= callback;
                _events[name] = func;
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            ThrowEventAlreadyUnRegsisteredException(name);
        }

    }

    public void TriggerAction(int name) {
        Delegate callback = null;
        _events.TryGetValue(name, out callback);
        if (callback != null) {
            Action func = callback as Action;
            if (func != null) {
                func();
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            ThrowEventNotFindException(name);
        }
    }
    #endregion

    #region 1 param event
    public void RegisterAction<T>(int name, Action<T> callback) {
        Delegate action = null;
        _events.TryGetValue(name, out action);
        if (action != null) {
            Action<T> func = action as Action<T>;
            if (func != null) {
                func += callback;
                _events[name] = func;
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            _events[name] = callback;
        }
    }

    public void UnRegisterAction<T>(int name, Action<T> callback) {
        Delegate action = null;
        _events.TryGetValue(name, out action);
        if (action != null) {
            Action<T> func = action as Action<T>;
            if (func != null) {
                func -= callback;
                _events[name] = func;
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            ThrowEventAlreadyUnRegsisteredException(name);
        }

    }

    public void TriggerAction<T>(int name, T arg1) {
        Delegate callback = null;
        _events.TryGetValue(name, out callback);
        if (callback != null) {
            Action<T> func = callback as Action<T>;
            if (func != null) {
                func(arg1);
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            ThrowEventNotFindException(name);
        }
    }
    #endregion

    #region 2 params event
    public void RegisterAction<T, U>(int name, Action<T, U> callback) {
        Delegate action = null;
        _events.TryGetValue(name, out action);
        if (action != null) {
            Action<T, U> func = action as Action<T, U>;
            if (func != null) {
                func += callback;
                _events[name] = func;
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            _events[name] = callback;
        }
    }

    public void UnRegisterAction<T, U>(int name, Action<T, U> callback) {
        Delegate action = null;
        _events.TryGetValue(name, out action);
        if (action != null) {
            Action<T, U> func = action as Action<T, U>;
            if (func != null) {
                func -= callback;
                _events[name] = func;
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            ThrowEventAlreadyUnRegsisteredException(name);
        }

    }

    public void TriggerAction<T, U>(int name, T arg1, U arg2) {
        Delegate callback = null;
        _events.TryGetValue(name, out callback);
        if (callback != null) {
            Action<T, U> func = callback as Action<T, U>;
            if (func != null) {
                func(arg1, arg2);
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            ThrowEventNotFindException(name);
        }
    }
    #endregion

    #region 3 params event
    public void RegisterAction<T, U, V>(int name, Action<T, U, V> callback) {
        Delegate action = null;
        _events.TryGetValue(name, out action);
        if (action != null) {
            Action<T, U, V> func = action as Action<T, U, V>;
            if (func != null) {
                func += callback;
                _events[name] = func;
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            _events[name] = callback;
        }
    }

    public void UnRegisterAction<T, U, V>(int name, Action<T, U, V> callback) {
        Delegate action = null;
        _events.TryGetValue(name, out action);
        if (action != null) {
            Action<T, U, V> func = action as Action<T, U, V>;
            if (func != null) {
                func -= callback;
                _events[name] = func;
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            ThrowEventAlreadyUnRegsisteredException(name);
        }

    }

    public void TriggerAction<T, U, V>(int name, T arg1, U arg2, V arg3) {
        Delegate callback = null;
        _events.TryGetValue(name, out callback);
        if (callback != null) {
            Action<T, U, V> func = callback as Action<T, U, V>;
            if (func != null) {
                func(arg1, arg2, arg3);
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            ThrowEventNotFindException(name);
        }
    }
    #endregion

    #region 4 params event
    public void RegisterAction<T, U, V, W>(int name, Action<T, U, V, W> callback) {
        Delegate action = null;
        _events.TryGetValue(name, out action);
        if (action != null) {
            Action<T, U, V, W> func = action as Action<T, U, V, W>;
            if (func != null) {
                func += callback;
                _events[name] = func;
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            _events[name] = callback;
        }
    }

    public void UnRegisterAction<T, U, V, W>(int name, Action<T, U, V, W> callback) {
        Delegate action = null;
        _events.TryGetValue(name, out action);
        if (action != null) {
            Action<T, U, V, W> func = action as Action<T, U, V, W>;
            if (func != null) {
                func -= callback;
                _events[name] = func;
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            ThrowEventAlreadyUnRegsisteredException(name);
        }

    }

    public void TriggerAction<T, U, V, W>(int name, T arg1, U arg2, V arg3, W arg4) {
        Delegate callback = null;
        _events.TryGetValue(name, out callback);
        if (callback != null) {
            Action<T, U, V, W> func = callback as Action<T, U, V, W>;
            if (func != null) {
                func(arg1, arg2, arg3, arg4);
            } else {
                ThrowEventTranslationException(name);
            }
        } else {
            ThrowEventNotFindException(name);
        }
    }
    #endregion


    void ThrowEventAlreadyUnRegsisteredException(int name) {
        string log = string.Format("{0} already unregistered", name);
        Debug.LogWarning(log);
    }

    void ThrowEventNotFindException(int name) {
        Debug.LogError("Can not find event " + name);
    }

    void ThrowEventTranslationException(int name) {
        string log = string.Format("can not convert event {0} to correct callck,please check event name and params type ", name);
        Debug.LogError(log);
    }

    public void Clear() {
        _events.Clear();
    }
}
