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
        return _scriptEnv.GetObject<TanmakLevelInfo[][]>("reimuTanmakLevels");
    }
}
