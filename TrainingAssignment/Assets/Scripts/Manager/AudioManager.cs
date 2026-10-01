using UnityEngine;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField]
        private AudioSource _audioSource;

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
        /// éwíËÇµÇΩAudioClipÇçƒê∂Ç∑ÇÈ
        /// </summary>
        /// <param name="clip">çƒê∂Ç∑ÇÈAudioClip</param>
        public void PlaySE(AudioClip clip)
        {
            if (clip == null
                || OptionManager.Instance.OptionData.Se.IsMute)
                return;

            _audioSource.PlayOneShot(clip, OptionManager.Instance.OptionData.Se.Volume);
        }
    }
}
