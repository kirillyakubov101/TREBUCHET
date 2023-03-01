using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace WallClock.Core
{
    public class Clock : MonoBehaviour
    {
        [Header("Time Method")]
        [SerializeField] private TimeSourceMethod m_timeSourceMethod;
        [SerializeField] private TimeSource m_computerTimeSource;
        [SerializeField] private TimeSource m_elapsedTimeSource;
        [SerializeField] private TimeSource m_staticTimeSource;

        [Header("Heads")]
        [SerializeField] private GameObject m_MinutesHand;
        [SerializeField] private GameObject m_HoursHand;

        [Header("Hands Models Sets")]
        [SerializeField] private Transform[] m_minutesModels;
        [SerializeField] private Transform[] m_hoursModels;


        public static UnityEvent OnMinutePassHour = new UnityEvent();
        

        //the way to get the time source
        private TimeSource m_currentTimeSource = null;

        //every 6 degrees in unity = 1 minute (same as seconds)
        private const int c_degreesPerMinute = 6;

        //every 30 degrees in unity = 1 hour
        private const int c_degreesPerHour = 30;

        private float m_minutes;
        private float m_hours;
        private float m_seconds;

        private int randomIndexSet;
       

        private void Start()
        {
            //InitClock(); //init the clock with the current time | we cache it once to avoid calling DateTime.Now all the time
            StartCoroutine(ClockMechanism());
           
        }

        private IEnumerator ClockMechanism()
        {
            yield return InitClock(); //wait for the clock to init its starting values
   
            while (true)
            {
                if (m_seconds >= 60)
                {
                    m_seconds = 0f;
                    UpdateMinutes();
                }

                m_seconds += Time.deltaTime;
                yield return null;
            }
        }

        private void UpdateMinutes()
        {
            m_minutes++;

            //event fire when minute hand passes the hour
            if (IsMinPassHour()){ Clock.OnMinutePassHour?.Invoke(); }

            if (m_minutes >= 60)
            {
                m_minutes = 0f;
                UpdateHours();
            }

            m_MinutesHand.transform.localRotation = Quaternion.Euler(0f, m_minutes * c_degreesPerMinute, 0f);
        }

        private void UpdateHours()
        {
            m_hours++;
            if(m_hours >= 12)
            {
                m_hours = 0;
            }

            m_HoursHand.transform.localRotation = Quaternion.Euler(0f, m_hours * c_degreesPerHour, 0f);
        }

        private IEnumerator InitClock()
        {
            ActivateRandomModelsSet();

            InitTimeSource();
            InitTimeValues();

            m_MinutesHand.transform.localRotation = Quaternion.Euler(0f, m_minutes * c_degreesPerMinute, 0f);
            m_HoursHand.transform.localRotation = Quaternion.Euler(0f, m_hours * c_degreesPerHour, 0f);

            yield return null;
        }

        private void InitTimeValues()
        {
            m_minutes = m_currentTimeSource.Minutes;
            m_hours = m_currentTimeSource.Hours;
            m_seconds = m_currentTimeSource.Seconds;
        }

        //Exercise 4 addition
        private void ActivateRandomModelsSet()
        {
            randomIndexSet = UnityEngine.Random.Range(0, 3);
            m_minutesModels[randomIndexSet].gameObject.SetActive(true);
            m_hoursModels[randomIndexSet].gameObject.SetActive(true);
        }

        private enum TimeSourceMethod
        {
            COMPUTER,
            ELAPSED,
            STATIC
        }

        private void InitTimeSource()
        {
            switch (m_timeSourceMethod)
            {
                case TimeSourceMethod.COMPUTER:
                    m_currentTimeSource = m_computerTimeSource;
                    break;

                case TimeSourceMethod.ELAPSED:
                    m_currentTimeSource = m_elapsedTimeSource;
                    break;

                case TimeSourceMethod.STATIC:
                    m_currentTimeSource = m_staticTimeSource;
                    break;

                default:
                    break;
            }

            m_currentTimeSource.InitValues();

        }

        private bool IsMinPassHour()
        {
            float hourToMinConvertion = m_hours * 5;

            return m_minutes > hourToMinConvertion;
        }
    }
}

