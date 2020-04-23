using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event manager
/// </summary>
public static class EventManager
{
    // FreezerEffectActivated support
    static List<PickupBlock> freezerEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectListeners = 
        new List<UnityAction<float>>();


    // speedupEffectActivated support
    static List<PickupBlock> speedupEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float, float>> speedupEffectListeners = 
        new List<UnityAction<float, float>>();

    // add dictionary
    static Dictionary<EventName, List<IntEventInvoker>> invokers =
        new Dictionary<EventName, List<IntEventInvoker>>();
    static Dictionary<EventName, List<UnityAction<int>>> listeners =
        new Dictionary<EventName, List<UnityAction<int>>>();

    #region Public methods


    public static void Initialize()
    {
        // create empty lists for all the dictionary entries
        foreach (EventName name in Enum.GetValues(typeof(EventName)))
        {
            if (!invokers.ContainsKey(name))
            {
                invokers.Add(name, new List<IntEventInvoker>());
                listeners.Add(name, new List<UnityAction<int>>());
            }
            else
            {
                invokers[name].Clear();
                listeners[name].Clear();
            }
        }
    }

    /// <summary>
    /// Adds the given script as a freezer effect invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddFreezerEffectInvoker(PickupBlock invoker)
    {
        // add invoker to list and add all listeners to invoker
        freezerEffectInvokers.Add(invoker);
        foreach (UnityAction<float> listener in freezerEffectListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a freezer effect listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddFreezerEffectListener(UnityAction<float> listener)
    {
        // add listener to list and to all invokers
        freezerEffectListeners.Add(listener);
        foreach (PickupBlock invoker in freezerEffectInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a speedup effect invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddSpeedupEffectInvoker(PickupBlock invoker)
    {
        // add invoker to list and add all listeners to invoker
        speedupEffectInvokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedupEffectListeners)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a speedup effect listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
        // add listener to list and to all invokers
        speedupEffectListeners.Add(listener);
        foreach (PickupBlock invoker in speedupEffectInvokers)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddListener(EventName eventName, UnityAction<int> listener)
    {
        // add as listener to all invokers and add new listener to dictionary
        foreach (IntEventInvoker invoker in invokers[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        listeners[eventName].Add(listener);
    }

    /// <summary>
    /// Adds the given method as a invoker
    /// </summary>
    /// <param name="invoker">listener</param>
    public static void AddInvoker(EventName eventName, IntEventInvoker invoker)
    {
        // add listeners to new invoker and add new invoker to dictionary
        foreach (UnityAction<int> listener in listeners[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        invokers[eventName].Add(invoker);
    }

    #endregion
}
