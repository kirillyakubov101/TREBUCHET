using UnityEngine;
using Cinemachine;

namespace WallClock.Core
{
    public class GameManager : MonoBehaviour
    {
        [Header("Clock Creation")]
        [SerializeField] private Clock m_ClockPrefab;
        [SerializeField] private int m_clockToCreateAtStart = 3;
        [SerializeField] private float m_offsetX;

        [Header("Camera-Target")]
        [SerializeField] private CinemachineTargetGroup m_cinemachineTarget;

        private Vector3 m_StartPosition = Vector3.zero;
        private const float c_TargetGroupRadius = 2f;
      

        private void Start()
        {
            CreateClocks();
        }

        private void CreateClocks()
        {
            for (int i = 0; i < m_clockToCreateAtStart; i++)
            {
                CreateAdditionalClock();
            }
        }

        public void CreateAdditionalClock()
        {
            Clock instance = Instantiate(m_ClockPrefab, m_StartPosition, Quaternion.identity);
            m_cinemachineTarget.AddMember(instance.transform, 1f, c_TargetGroupRadius);
            m_StartPosition.x += m_offsetX;
        }
    }

}
