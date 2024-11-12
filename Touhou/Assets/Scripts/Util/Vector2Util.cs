using System;
using UnityEngine;

namespace MinseoUtil
{
    public static class Vector2Util
    {
        public static Vector2 RotateVector(Vector2 vec, Single angle)
        {
            return Quaternion.AngleAxis(angle, Vector3.forward) * vec;
        }
    }
}
