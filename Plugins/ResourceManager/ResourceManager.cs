using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public static T LoadRes<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

}
