// ========================================================
// 描 述：
// 作 者：Fu Xing 
// 创建时间：2018/03/22 14:19:11
// ========================================================
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 自定义事件类型
/// </summary>
public class EventType
{
    private static int startEventID = 1000;

    //------------------外部事件------------------------
    public static int ADD_HP_EVENT = ++startEventID;

    public static int ADD_BUFF_EVENT = ++startEventID;
}
