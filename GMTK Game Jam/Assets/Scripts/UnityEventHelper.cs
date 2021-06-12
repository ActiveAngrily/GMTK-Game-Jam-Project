using UnityEngine.Events;

public static class UnityEventHelper
{
    public static void FireUnityEvent (UnityEvent uniEvent,ref int times)
    {
        if(times > 0)
        {
            uniEvent.Invoke();
            times--;
        }

    }

    public static void FireUnityEvent(UnityEvent uniEvent)
    {
        uniEvent.Invoke();
    }

}
