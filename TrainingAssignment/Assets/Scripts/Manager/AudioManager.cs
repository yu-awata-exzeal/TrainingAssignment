using UnityEngine;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField]
        private AudioSource _seSource;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// éwíËÇÃAudioClipÇçƒê∂Ç∑ÇÈ
        /// </summary>
        /// <param name="clip"></param>
        public void PlaySE(AudioClip clip)
        {
            if (clip == null
                || OptionManager.Instance.OptionData.Se.IsMute)
                return;

            _seSource.PlayOneShot(clip, OptionManager.Instance.OptionData.Se.Volume);
        }
    }
}
