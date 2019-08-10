using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

public enum EventName
{
    OnInputTouched,
    OnFire,
}



public class EventMgr
{
    private Dictionary<int, Delegate> _events = new Dictionary<int, Delegate>();

    #region 0 param event
    public void RegisterAction(EventName name, Action callback)
    {
        int intName = (int)name;
        Delegate action = null;
        _events.TryGetValue(intName, out action);
        if (action != null)
        {
            Action func = action as Action;
            if (func != null)
            {
                func += callback;
                _events[intName] = func;
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            _events[intName] = callback;
        }

    }

    public void UnRegisterAction(EventName name, Action callback)
    {
        int intName = (int)name;
        Delegate action = null;
        _events.TryGetValue(intName, out action);
        if (action != null)
        {
            Action func = action as Action;
            if (func != null)
            {
                func -= callback;
                _events[intName] = func;
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            ThrowEventAlreadyUnRegsisteredException(name);
        }

    }

    public void TriggerAction(EventName name)
    {
        int intName = (int)name;
        Delegate callback = null;
        _events.TryGetValue(intName, out callback);
        if (callback != null)
        {
            Action func = callback as Action;
            if (func != null)
            {
                func();
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            ThrowEventNotFindException(name);
        }
    }
    #endregion

    #region 1 param event
    public void RegisterAction<T>(EventName name, Action<T> callback)
    {
        int intName = (int)name;
        Delegate action = null;
        _events.TryGetValue(intName, out action);
        if (action != null)
        {
            Action<T> func = action as Action<T>;
            if (func != null)
            {
                func += callback;
                _events[intName] = func;
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            _events[intName] = callback;
        }
    }

    public void UnRegisterAction<T>(EventName name, Action<T> callback)
    {
        int intName = (int)name;
        Delegate action = null;
        _events.TryGetValue(intName, out action);
        if (action != null)
        {
            Action<T> func = action as Action<T>;
            if (func != null)
            {
                func -= callback;
                _events[intName] = func;
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            ThrowEventAlreadyUnRegsisteredException(name);
        }

    }

    public void TriggerAction<T>(EventName name, T arg1)
    {
        int intName = (int)name;
        Delegate callback = null;
        _events.TryGetValue(intName, out callback);
        if (callback != null)
        {
            Action<T> func = callback as Action<T>;
            if (func != null)
            {
                func(arg1);
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            ThrowEventNotFindException(name);
        }
    }
    #endregion

    #region 2 params event
    public void RegisterAction<T, U>(EventName name, Action<T, U> callback)
    {
        int intName = (int)name;
        Delegate action = null;
        _events.TryGetValue(intName, out action);
        if (action != null)
        {
            Action<T, U> func = action as Action<T, U>;
            if (func != null)
            {
                func += callback;
                _events[intName] = func;
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            _events[intName] = callback;
        }
    }

    public void UnRegisterAction<T, U>(EventName name, Action<T, U> callback)
    {
        int intName = (int)name;
        Delegate action = null;
        _events.TryGetValue(intName, out action);
        if (action != null)
        {
            Action<T, U> func = action as Action<T, U>;
            if (func != null)
            {
                func -= callback;
                _events[intName] = func;
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            ThrowEventAlreadyUnRegsisteredException(name);
        }

    }

    public void TriggerAction<T, U>(EventName name, T arg1, U arg2)
    {
        int intName = (int)name;
        Delegate callback = null;
        _events.TryGetValue(intName, out callback);
        if (callback != null)
        {
            Action<T, U> func = callback as Action<T, U>;
            if (func != null)
            {
                func(arg1, arg2);
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            ThrowEventNotFindException(name);
        }
    }
    #endregion

    #region 3 params event
    public void RegisterAction<T, U, V>(EventName name, Action<T, U, V> callback)
    {
        int intName = (int)name;
        Delegate action = null;
        _events.TryGetValue(intName, out action);
        if (action != null)
        {
            Action<T, U, V> func = action as Action<T, U, V>;
            if (func != null)
            {
                func += callback;
                _events[intName] = func;
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            _events[intName] = callback;
        }
    }

    public void UnRegisterAction<T, U, V>(EventName name, Action<T, U, V> callback)
    {
        int intName = (int)name;
        Delegate action = null;
        _events.TryGetValue(intName, out action);
        if (action != null)
        {
            Action<T, U, V> func = action as Action<T, U, V>;
            if (func != null)
            {
                func -= callback;
                _events[intName] = func;
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            ThrowEventAlreadyUnRegsisteredException(name);
        }

    }

    public void TriggerAction<T, U, V>(EventName name, T arg1, U arg2, V arg3)
    {
        int intName = (int)name;
        Delegate callback = null;
        _events.TryGetValue(intName, out callback);
        if (callback != null)
        {
            Action<T, U, V> func = callback as Action<T, U, V>;
            if (func != null)
            {
                func(arg1, arg2, arg3);
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            ThrowEventNotFindException(name);
        }
    }
    #endregion

    #region 4 params event
    public void RegisterAction<T, U, V, W>(EventName name, Action<T, U, V, W> callback)
    {
        int intName = (int)name;
        Delegate action = null;
        _events.TryGetValue(intName, out action);
        if (action != null)
        {
            Action<T, U, V, W> func = action as Action<T, U, V, W>;
            if (func != null)
            {
                func += callback;
                _events[intName] = func;
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            _events[intName] = callback;
        }
    }

    public void UnRegisterAction<T, U, V, W>(EventName name, Action<T, U, V, W> callback)
    {
        int intName = (int)name;
        Delegate action = null;
        _events.TryGetValue(intName, out action);
        if (action != null)
        {
            Action<T, U, V, W> func = action as Action<T, U, V, W>;
            if (func != null)
            {
                func -= callback;
                _events[intName] = func;
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            ThrowEventAlreadyUnRegsisteredException(name);
        }

    }

    public void TriggerAction<T, U, V, W>(EventName name, T arg1, U arg2, V arg3, W arg4)
    {
        int intName = (int)name;
        Delegate callback = null;
        _events.TryGetValue(intName, out callback);
        if (callback != null)
        {
            Action<T, U, V, W> func = callback as Action<T, U, V, W>;
            if (func != null)
            {
                func(arg1, arg2, arg3, arg4);
            }
            else
            {
                ThrowEventTranslationException(name);
            }
        }
        else
        {
            ThrowEventNotFindException(name);
        }
    }
    #endregion


    void ThrowEventAlreadyUnRegsisteredException(EventName name)
    {
        string log = string.Format("{0} already unregistered", name);
        Debug.LogWarning(log);
    }

    void ThrowEventNotFindException(EventName name)
    {
        Debug.LogError("Can not find event " + name);
    }

    void ThrowEventTranslationException(EventName name)
    {
        string log = string.Format("can not convert event {0} to correct callck,please check event name and params type ", name);
        Debug.LogError(log);
    }

    public void Clear()
    {
        _events.Clear();
    }
}
