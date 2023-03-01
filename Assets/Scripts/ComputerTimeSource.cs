using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ComputerTimeSource", order = 1)]
public class ComputerTimeSource : TimeSource
{
    public override void InitValues()
    {
        m_minutes = DateTime.Now.Minute;
        m_hours = DateTime.Now.Hour;
        m_seconds = DateTime.Now.Second;
    }
}
