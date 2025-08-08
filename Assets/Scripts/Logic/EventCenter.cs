using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{ 

}
public class EventInfo<T, K> : IEventInfo
{
    public UnityAction<T, K> actions = delegate { };
    public EventInfo(UnityAction<T, K> action)
    {
        actions += action;
    }
}
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions = delegate { };
    public EventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}
public class EventInfo : IEventInfo
{
    public UnityAction actions = delegate { };
    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}
public class EventCenter : SingletonBase<EventCenter>
{
    private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();
    public void AddEventListener<T, K>(string eventName, UnityAction<T, K> action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T, K>).actions += action;
        }
        else
        {
            eventDic.Add(eventName, new EventInfo<T, K>(action));
        }
    }
    public void AddEventListener<T>(string eventName, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T>).actions += action;
        }
        else
        {
            eventDic.Add(eventName, new EventInfo<T>(action));
        }
    }
    public void AddEventListener(string eventName, UnityAction action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(eventName, new EventInfo(action));
        }
    }
    public void RemoveEventListener<T, K>(string eventName, UnityAction<T, K> action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T, K>).actions -= action;
        }
    }
    public void RemoveEventListener<T>(string eventName, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T>).actions -= action;
        }
    }
    public void RemoveEventListener(string eventName, UnityAction action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo).actions -= action;
        }
    }
    public void TriggerEvent<T, K>(string eventName, T argT, K argK)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T, K>).actions?.Invoke(argT, argK);
        }
    }
    public void TriggerEvent<T>(string eventName, T arg)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo<T>).actions?.Invoke(arg);
        }
    }
    public void TriggerEvent(string eventName)
    {
        if (eventDic.ContainsKey(eventName))
        {
            (eventDic[eventName] as EventInfo).actions?.Invoke();
        }
    }
    public void Clear()
    {
        eventDic.Clear();
    }
}
