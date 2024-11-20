using NLua;
using System;
using UnityEngine;

public class ReimuTanmakLoader : ITanmakLoader
{
    private readonly IScriptEnv _scriptEnv;
    public ReimuTanmakLoader(IScriptEnv pScriptEnv)
    {
        _scriptEnv = pScriptEnv;
    }
    public TanmakLevelInfo[][] GetTanmakLevel()
    {
        var box = _scriptEnv.GetObject<LuaTable>("reimuTanmakLevels");
        TanmakLevelInfo[][] temp = new TanmakLevelInfo[box.Values.Count][];
        Int32 index = 0;
        foreach(LuaTable t in box.Values)
        {
            temp[index] = new TanmakLevelInfo[t.Values.Count];
            Int32 j = 0;
            foreach(LuaTable t2 in t.Values)
            {
                temp[index][j] = new TanmakLevelInfo(
                    (String)t2["Name"],
                    (Int32)(Int64)t2["Count"],
                    (Single)(Double)t2["Cooltime"],
                    (Vector2[])t2["SpawnPosition"],
                    (Vector2[])t2["Direction"]);
                j++;
            }
            index++;
        }
        return temp;
    }
}
