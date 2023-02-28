using System;
using System.Collections;
using UnityEngine;

namespace WallClock
{
    public class Clock : MonoBehaviour
    {
        [SerializeField] private GameObject m_MinutesHand;
        [SerializeField] private GameObject m_HoursHand;

        //every 6 degrees in unity = 1 minute (same as seconds)
        private const int c_degreesPerMinute = 6;

        //every 30 degrees in unity = 1 hour
        private const int c_degreesPerHour = 30;

        private float m_minutes;
        private float m_hours;
        private float m_seconds;
       

        private void Start()
        {
            InitClock(); //init the clock with the current time | we cache it once to avoid calling DateTime.Now all the time
            StartCoroutine(ClockMechanism()); 
        }

        private IEnumerator ClockMechanism()
        {
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
            if(m_minutes >= 60)
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

        private void InitClock()
        {
            m_minutes = DateTime.Now.Minute;
            m_hours = DateTime.Now.Hour;
            m_seconds = DateTime.Now.Second;

            m_MinutesHand.transform.localRotation = Quaternion.Euler(0f, m_minutes * c_degreesPerMinute, 0f);
            m_HoursHand.transform.localRotation = Quaternion.Euler(0f, m_hours * c_degreesPerHour, 0f);
        }

    }
}

