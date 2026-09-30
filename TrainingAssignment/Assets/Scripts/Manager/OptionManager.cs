using UnityEngine;

namespace Manager
{
    public class AudioSetting
    {
        public float Volume { get; private set; } = 0.5f;
        public bool IsMute { get; private set; } = false;

        public void SetVolume(float volume)
        {
            Volume = volume;
        }
        public void SetIsMute(bool flag)
        {
            IsMute = flag;
        }
    }

    public class OptionData
    {
        public AudioSetting Se { get; } = new();

        public float MouseSensivity { get; private set; } = 0.5f;

        public void SetMouseSensivity(float value)
        {
            MouseSensivity = value;
        }
    }

    public class OptionManager
    {
        private static OptionManager _instance;

        public static OptionManager Instance => _instance ??= new();

        private const string SE_VOLUME_KEY = "SEVolume";
        private const string SE_MUTE_KEY = "SEMute";
        private const string MOUSE_SENSITIVITY_KEY = "MouseSensitivity";

        // デフォルト値
        private const float DEFAULT_VOLUME = 0.5f;

        private const bool DEFAULT_MUTE = false;
        private const float DEFAULT_MOUSE_SENSITIVITY = 0.5f;

        private OptionData _settingOtionData = new();

        private OptionData _baseOtionData = new();

        public OptionData OptionData => _settingOtionData;

        private OptionManager()
        {
            Load();
        }

        /// <summary>
        /// PlayerPrefsから設定を読み込む
        /// </summary>
        private void Load()
        {
            _baseOtionData.Se.SetVolume(PlayerPrefs.GetFloat(SE_VOLUME_KEY, DEFAULT_VOLUME));
            _baseOtionData.Se.SetIsMute(PlayerPrefs.GetInt(SE_MUTE_KEY, 0) == 1);
            _baseOtionData.SetMouseSensivity(
                PlayerPrefs.GetFloat(MOUSE_SENSITIVITY_KEY, DEFAULT_MOUSE_SENSITIVITY));

            _settingOtionData = _baseOtionData;
        }

        public void SetSeVolume(float value)
        {
            _settingOtionData.Se.SetVolume(value);
            PlayerPrefs.SetFloat(SE_VOLUME_KEY, value);
        }

        public void SetSeMute(bool value)
        {
            _settingOtionData.Se.SetIsMute(value);
            PlayerPrefs.SetInt(SE_MUTE_KEY, value ? 1 : 0);
        }

        public void SetMouseSensitivity(float value)
        {
            _settingOtionData.SetMouseSensivity(value);

            PlayerPrefs.SetFloat(MOUSE_SENSITIVITY_KEY, value);
        }

        /// <summary>
        /// 変更前の状態にリセット
        /// </summary>
        public void ReverOption()
        {
            SetSeVolume(_baseOtionData.Se.Volume);
            SetSeMute(_baseOtionData.Se.IsMute);
            SetMouseSensitivity(_baseOtionData.MouseSensivity);
            Save();
        }

        public void ResetOption()
        {
            SetSeVolume(DEFAULT_VOLUME);
            SetSeMute(DEFAULT_MUTE);
            SetMouseSensitivity(DEFAULT_MOUSE_SENSITIVITY);
            Save();
        }

        /// <summary>
        /// PlayerPrefsに保存
        /// </summary>
        public void Save()
        {
            _baseOtionData = _settingOtionData;
            PlayerPrefs.Save();
        }
    }
}
