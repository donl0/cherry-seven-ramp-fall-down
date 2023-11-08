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
    
    public static bool TryGetNextEnumValue<T>(this T currentEnumValue, out T nextEnumValue) where T : Enum
    {
        Array enumValues = Enum.GetValues(typeof(T));
        int currentIndex = Array.IndexOf(enumValues, currentEnumValue);

        int nextIndex = currentIndex + 1;

        if (nextIndex < enumValues.Length)
        {
            nextEnumValue = (T)enumValues.GetValue(nextIndex);
            return true;
        }
        else
        {
            nextEnumValue = default(T);
            return false;
        }
    }
}
