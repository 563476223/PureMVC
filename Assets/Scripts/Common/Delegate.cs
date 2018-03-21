
//--全局的方法调用
//防止传入的参数错误
using LuaInterface;
using System.Collections;
using UnityEngine;
[LuaByteBuffer]
public delegate void Callback_0();
[LuaByteBuffer]
public delegate void Callback_1<T>(T param);
[LuaByteBuffer]
public delegate void Callback_2<T1, T2>(T1 param1, T2 param2);
[LuaByteBuffer]
public delegate void Callback_3<T1, T2, T3>(T1 param1, T2 param2, T3 param3);
[LuaByteBuffer]
public delegate void Callback_4<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4);
[LuaByteBuffer]
public delegate void Callback_5<T1, T2, T3, T4, T5>(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5);
[LuaByteBuffer]
public delegate float Float_Callback_0();
[LuaByteBuffer]
public delegate bool Bool_Callback_1<T>(T param);
[LuaByteBuffer]
public delegate bool Bool_Callback_2<T1, T2>(T1 param1, T2 param2);