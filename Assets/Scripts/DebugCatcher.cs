using UnityEngine;
using WallClock.Core;
namespace WallClock.Debugs
{
    public class DebugCatcher : MonoBehaviour
    {
        private void OnEnable()
        {
            Clock.OnMinutePassHour.AddListener(MessageReceived);
        }

        private void OnDestroy()
        {
            Clock.OnMinutePassHour.RemoveListener(MessageReceived);
        }

        public void MessageReceived()
        {
            Debug.Log("Message Was Received :)");

        }
    }

}
