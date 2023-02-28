using UnityEngine;
using UnityEngine.Events;

namespace WallClock.Inputs
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnClockCreate;

        private void Update()
        {
            //legacy input system
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnClockCreate?.Invoke();
            }
        }
    }

}
