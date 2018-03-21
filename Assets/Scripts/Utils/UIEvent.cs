using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 提供UI事件的类
/// </summary>
public static class UIEvent
{
    public static void AddButtonEvent(Transform target, LuaFunction callback)
    {
        target.GetComponent<Button>().onClick.AddListener(delegate()
        {
            callback.Call(target);
        });
    }

    public static void RemoveButtonEvent(Transform target)
    {
        target.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    public static void AddToggleEvent(Transform target, LuaFunction callback)
    {
        target.GetComponent<Toggle>().onValueChanged.AddListener(delegate(bool isToggle)
        {
            callback.Call(target, isToggle);
        });
    }

    public static void RemoveToggleEvent(Transform target)
    {
        target.GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
    }

    public static void AddToggleGroup(Transform target, Transform group)
    {
        target.GetComponent<Toggle>().group = group.GetComponent<ToggleGroup>();
    }

    public static void AddInputValueChangeEvent(Transform target, LuaFunction callback)
    {
        target.GetComponent<InputField>().onValueChanged.AddListener(delegate(string value)
        {
            callback.Call(value);
        });
    }

    public static void AddInputEndEditEvent(Transform target, LuaFunction callback)
    {
        target.GetComponent<InputField>().onEndEdit.AddListener(delegate(string value)
        {
            callback.Call(value);
        });
    }

    public static void AddSliderValueChangeEvent(Transform target, LuaFunction callback)
    {
        target.GetComponent<Slider>().onValueChanged.AddListener(delegate(float value)
        {
            callback.Call(value);
        });
    }
}