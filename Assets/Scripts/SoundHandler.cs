using UnityEngine;

namespace WallClock.Sounds
{
    public class SoundHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource m_audioSource;
        public void PlaySound()
        {
            m_audioSource.Play();
        }
    }

}
