using NLua;
using System.Collections.Generic;   
using UnityEngine;

namespace MinseoUtil
{
    public static class LuaUtility
    {
        private static T[] LuaTableToGenericArray<T>(LuaTable pTable)
        {
            List<T> list = new List<T>();
            foreach (var item in pTable.Values)
            {
                list.Add((T)item);
            }
            return list.ToArray();
        }
        public static Vector2[] LuaTableToVectorArray(LuaTable pTable)
        {
            return LuaTableToGenericArray<Vector2>(pTable);
        }
    }
}
