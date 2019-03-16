using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// Ad positions
public enum CrazyAdType
{
    midgame,
    rewarded
}

// Ad events
public enum CrazySDKEvent
{
    adStarted, // fired when ad starts playing
    adFinished, // fired when ad has finished (either when completed or when user pressed skip)
    adCompleted, // fired when user has completely watched the ad
    adError, // fired when an error occurs, also fired when no ad is available
    adblockDetectionExecuted, // fired when adblock detection has run
}

// http://wiki.unity3d.com/index.php/Singleton
public class CrazySDK : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void Init(string version, string objectName);

    [DllImport("__Internal")]
    private static extern void RequestAd(string str);

    public static string sdkVersion = "1.4.0";

    private static CrazySDK instance = null;
    private static object _lock = new object();

    private Dictionary<CrazySDKEvent, List<EventCallback>> eventListeners;
    private bool isInitialized = false;

    private bool requestInProgress = false;
    private bool adblockDetectionExecuted = false;
    private bool hasAdblock = false;

    private CrazySDK()
    {
        eventListeners = new Dictionary<CrazySDKEvent, List<EventCallback>>();
    }

    public static CrazySDK Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (CrazySDK)FindObjectOfType(typeof(CrazySDK));

                if (FindObjectsOfType(typeof(CrazySDK)).Length > 1)
                {
                    return instance;
                }

                lock (_lock)
                {
                    if (instance == null)
                    {
                        GameObject singleton = new GameObject();
                        instance = singleton.AddComponent<CrazySDK>();
                        singleton.name = "(singleton) " + typeof(CrazySDK).ToString();

                        DontDestroyOnLoad(singleton);
                    }
                }
            }
            return instance;
        }
    }

    public void Initialize()
    {
        if (isInitialized)
        {
            return;
        }
        if (Debug.isDebugBuild)
        {
            Debug.LogWarning("[CrazySDK] Development Build");
        }
        Debug.Log("[CrazySDK] Initializing SDK");
        isInitialized = true;
#if (!UNITY_EDITOR)
        CrazySDK.Init(CrazySDK.sdkVersion, this.name);
        SiteLock sitelock = new SiteLock();
        sitelock.SiteLockCheck();
#endif
    }

    public bool IsInitialized()
    {
        return isInitialized;
    }

    public void RequestAd(CrazyAdType adType = CrazyAdType.midgame)
    {
        DebugLog("Requesting Ad");

        if (!isInitialized)
        {
            DebugLog("Initialize CrazySDK first");
            return;
        }
        if (requestInProgress)
        {
            DebugLog("Request in progress");
            return;
        }
        requestInProgress = true;
#if (!UNITY_EDITOR)
        CrazySDK.RequestAd(adType.ToString());
#else
        AdEvent("adError");
#endif
    }


    public delegate void EventCallback();

    public void AddEventListener(CrazySDKEvent eventType, EventCallback callback)
    {
        DebugLog("Adding event listener " + eventType.ToString());

        if (!eventListeners.ContainsKey(eventType))
        {
            eventListeners.Add(eventType, new List<EventCallback>());
        }

        eventListeners[eventType].Add(callback);
    }

    public void RemoveEventListener(CrazySDKEvent eventType, EventCallback callback)
    {
        DebugLog("Removing event listener");

        if (eventListeners.ContainsKey(eventType))
        {
            eventListeners[eventType].Remove(callback);
        }
    }

    public void RemoveEventListenersForEvent(CrazySDKEvent eventType)
    {
        DebugLog("Removing all event listener for " + eventType.ToString());

        eventListeners.Remove(eventType);
    }

    public void RemoveAllEventListeners()
    {
        DebugLog("Removing all event listeners");

        eventListeners.Clear();
    }

    public void AdEvent(string eventName)
    {
        if (!isInitialized)
        {
            return;
        }
        CrazySDKEvent parsedEvent = (CrazySDKEvent)System.Enum.Parse(typeof(CrazySDKEvent), eventName);
        HandleEvent(parsedEvent);
        CallCallbacks(parsedEvent);

    }

    public bool HasAdblock()
    {
        if (!adblockDetectionExecuted)
        {
            DebugLog("Adblock detection has not finished");
        }
        return hasAdblock;
    }

    public bool AdblockDetectionExecuted()
    {
        return adblockDetectionExecuted;
    }

    public void AdblockDetected()
    {
        Adblock(true);
    }

    public void AdblockNotDetected()
    {
        Adblock(false);
    }

    private void HandleEvent(CrazySDKEvent ev)
    {
        switch (ev)
        {
            case CrazySDKEvent.adFinished:
            case CrazySDKEvent.adError:
                requestInProgress = false;
                break;

            default:
                break;
        }
    }

    private void Adblock(bool detected)
    {
        this.adblockDetectionExecuted = true;
        this.hasAdblock = detected;
        CallCallbacks(CrazySDKEvent.adblockDetectionExecuted);
    }

    private void CallCallbacks(CrazySDKEvent ev)
    {
        if (eventListeners.ContainsKey(ev))
        {
            foreach (EventCallback callback in eventListeners[ev])
            {
                callback();
            }
        }
    }

    private void DebugLog(string msg)
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("[CrazySDK] " + msg);
        }
    }
}
