using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StaticTimeSource", order = 1)]
public class StaticTimeSource : TimeSource
{
    [SerializeField] private float m_overrideSeconds;
    [SerializeField] private float m_overrideMinutes;
    [SerializeField] private float m_overrideHours;
    public override void InitValues()
    {
        m_seconds = m_overrideSeconds;
        m_minutes = m_overrideMinutes;
        m_hours = m_overrideHours;
    }
}
