using UnityEngine;


public abstract class TimeSource : ScriptableObject
{
    protected float m_seconds;
    protected float m_minutes;
    protected float m_hours;

    public float Seconds { get => m_seconds; }
    public float Minutes { get => m_minutes; }
    public float Hours { get => m_hours; }


    public abstract void InitValues();
   
}
