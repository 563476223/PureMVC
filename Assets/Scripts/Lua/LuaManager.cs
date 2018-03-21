using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Lua;

public class LuaManager
{
    private LuaState luaState;

    private static LuaManager instance;

    public static LuaManager Instance
    {
        get
        {
            if (null == instance)
                instance = new LuaManager();
            return instance;
        }
    }


    public void Luanch()
    {
        LoadLuaBundle();
    }

    private void LoadLuaBundle()
    {
        //--添加搜索路径

        //初始化虚拟机
        luaState = new LuaState();
        OpenLibs();
        luaState.LuaSetTop(0);
        CSharpLuaBridge.Init();
        DelegateFactory.Init();
        LuaBinder.Bind(luaState);

        CSharpLuaBridge.Register(luaState);

        InitSearchPath();

        luaState.Start();

        StartMain();
    }

    void StartMain()
    {
        luaState.DoFile("Assets/Lua/Main");
        LuaFunction main = luaState.GetFunction("Main");
        main.Call();
        main.Dispose();
        main = null;
    }

    void OpenLibs()
    {
        //luaState.OpenLibs(LuaDLL.luaopen_protobuf_c);
        OpenCJson();
    }

    private void InitSearchPath()
    {
        luaState.AddSearchPath(Application.dataPath.Replace("Assets", ""));
        luaState.AddSearchPath(Application.dataPath + "/ToLua/Lua");
    }

    protected void OpenCJson()
    {
        luaState.LuaGetField(LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
        luaState.OpenLibs(LuaDLL.luaopen_cjson);
        luaState.LuaSetField(-2, "cjson");

        luaState.OpenLibs(LuaDLL.luaopen_cjson_safe);
        luaState.LuaSetField(-2, "cjson.safe");
    }

    public LuaFunction GetFunction(string functionName)
    {
        return luaState.GetFunction(functionName);
    }
}
