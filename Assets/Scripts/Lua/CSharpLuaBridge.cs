using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// cs 调用lua  ，lua调用C#接口
/// </summary>

namespace Assets.Scripts.Lua
{
    public class CSharpLuaBridge
    {
        //方便C#与lua进行交互
        public static void Init()
        {

        }

        public static void Register(LuaState L)
        {
            L.BeginModule(null);
            L.BeginStaticLibs("CSharp");
            L.RegFunction("Test", Test);
            L.EndStaticLibs();
            L.EndModule();
        }

        /// <summary>
        /// lua 调用C#
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
         [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        private static int Test(IntPtr state)
        {
            try
            {
                ToLua.CheckArgsCount(state, 1);
                float numb =  (float)LuaDLL.luaL_checknumber(state, 1);
                Debug.Log("数量" + numb);
                return 0;
            }
            catch (Exception e)
            {
                return LuaDLL.toluaL_exception(state, e);
            }
        }

        /// <summary>
        /// c#调用Lua
        /// </summary>
        /// <param name="numb"></param>
        public static void TestNumb(int numb)
         {
             LuaFunction func = LuaManager.Instance.GetFunction("TestNumb");
             if (func != null)
             {
                 func.BeginPCall();
                 func.Push(numb);
                 func.PCall();
                 func.EndPCall();
                 func.Dispose();
             }
         }
    }

}

