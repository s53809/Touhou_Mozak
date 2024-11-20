using NLua;
using System.Text;
using UnityEngine;

public class NLuaEnv : MonoSingleton<NLuaEnv>, IScriptEnv
{
    private Lua m_lua;

    protected override void Awake()
    {
        base.Awake();
        m_lua = new Lua();
        m_lua.State.Encoding = Encoding.UTF8;
        m_lua.LoadCLRPackage();
        m_lua.DoString(@"import ('UnityEngine')");
        m_lua.DoString(@"import ('Assembly-CSharp')");
        m_lua.DoString(@"import ('Assembly-CSharp', 'MinseoUtil')");

        Reload();
    }

    public void DoString(string pScript)
    {
        try
        {
            m_lua.DoString(pScript);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error while running lua : [{pScript}]");
            Debug.LogError($"{ex}");
        }
    }

    public T GetObject<T>(string pObjectName)
    {
        return (T)m_lua[pObjectName];
    }

    public object[] RunFunction(string pFunctionName, params object[] args)
    {
        LuaFunction function = m_lua.GetFunction(pFunctionName);
        return function.Call(args);
    }

    [InspectorButton("Reload Environment")]
    public void Reload()
    {
        TextAsset[] luaAssets = Resources.LoadAll<TextAsset>("Lua");
        foreach (var luaAsset in luaAssets)
        {
            DoString(luaAsset.text);
        }
        Debug.Log("Loaded Scripts");
    }
}
