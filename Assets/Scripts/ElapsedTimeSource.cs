using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ElapsedTimeSource", order = 1)]
public class ElapsedTimeSource : TimeSource
{
    [SerializeField] private float m_multiplier = 2f;
    public override void InitValues()
    {
        m_seconds = Mathf.RoundToInt(Time.time * m_multiplier);
        m_minutes = Mathf.RoundToInt(m_seconds / 60);
        m_hours   = Mathf.RoundToInt(m_minutes / 60);
    }
}
