using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GFunc
{
    #region  Print Log Func
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif  // DEBUG_MODE;
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message, Object context)
    {
#if DEBUG_MODE
        Debug.Log(message, context);
#endif  // DEBUG_MODE;
    }
    #endregion  // Print Log Func

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif  // DEBUG_MODE;
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message, Object context)
    {
#if DEBUG_MODE
        Debug.LogWarning(message, context);
#endif  // DEBUG_MODE;
    }

    #region Assert for Debug
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif  // DEBUG_MODE;
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition, object message)
    {
#if DEBUG_MODE
        Debug.Assert(condition, message);
#endif  // DEBUG_MODE;
    }

    #endregion  // Assert for Debug

    #region Valid Func
    public static bool IsValid<T>(this T component_)
    {
        bool isValid = component_.Equals(null) == false;
        
        return isValid;
    }
    #endregion // Valid Func
}
