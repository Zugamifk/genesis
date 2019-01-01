using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    static Dictionary<object, object> s_ServiceLookup = new Dictionary<object, object>();

    public static void Register<T>(T service)
    {
        s_ServiceLookup[typeof(T)] = service;
    }

    public static T Get<T>() where T : new()
    {
        object result;
        if(!s_ServiceLookup.TryGetValue(typeof(T), out result))
        {
            result = new T();
            Register(result);
        } 
        return (T)result;
    }
}
