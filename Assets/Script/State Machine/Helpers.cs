using System;
using UnityEngine;

public static class Helpers
{
    public static float Map(float value, float originaMin, float originaMax, float newMin, float newMax, bool clamp )
    {
        float newValue = (value - originaMin) / (originaMax - originaMin) * (newMax - newMin) + newMin;
        if (clamp)
        {
            newValue = Mathf.Clamp(newValue, newMin, newMax);
        }

        return newValue;
    }
}
