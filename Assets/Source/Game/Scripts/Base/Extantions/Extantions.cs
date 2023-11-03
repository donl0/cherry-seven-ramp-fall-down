using System;
using UnityEngine;

public static class Extantions
{
    public static String FixSerializeFieldLineBreak(this String value)
    {
        return value.Replace("\\n", "\n");
    }

    public static T GetComponentOrThrowNullException<T>(GameObject gameObject, string componentName)
    {
        T component = gameObject.GetComponentInChildren<T>();

        if (component == null)
        {
            throw new ArgumentNullException(componentName, $"{componentName} not found.");
        }

        return component;
    }
}
