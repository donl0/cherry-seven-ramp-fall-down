using System;
using UnityEngine;

public static class Extantions
{
    public static String FixSerializeFieldLineBreak(this String value)
    {
        return value.Replace("\\n", "\n");
    }
}
