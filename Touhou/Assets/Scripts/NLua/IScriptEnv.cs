using System;
using System.Collections.Generic;

public interface IScriptEnv
{
    void DoString(String pScript);
    void Reload();
    Object[] RunFunction(String pFunctionName, params Object[] args);
    T GetObject<T>(String pObjectName);
}