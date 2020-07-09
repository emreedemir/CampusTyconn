using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods 
{
    public static bool NameIsRight(this string value)
    {
        return value.Length > 5;
    }
}
