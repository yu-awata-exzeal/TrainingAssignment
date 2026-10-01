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
        public void SetMute(bool isMute)
        {
            IsMute = isMute;
        }
    }

    public class OptionData
    {
        public AudioSetting Se { get; } = new();

        public float MouseSensitivity { get; private set; } = 0.5f;

        public void SetMouseSensitivity(float value)
        {
            MouseSensitivity = value;
        }
    }

    public class OptionManager
    {
        private static OptionManager _instance;

        public static OptionManager Instance => _instance ??= new();

        private const string _seVolumeKey = "SEVolume";
        private const string _seMuteKey = "SEMute";
        private const string _mouseSensitivityKey = "MouseSensitivity";

        // デフォルト値
        private const float _defaultVolume = 0.5f;

        private const bool _defaultMute = false;
        private const float _defaultMouseSensitivity = 0.5f;

        private OptionData _settingOptionData = new();

        private OptionData _baseOtionData = new();

        public OptionData OptionData => _settingOptionData;

        private OptionManager()
        {
            Load();
        }

        /// <summary>
        /// PlayerPrefsから設定を読み込む
        /// </summary>
        private void Load()
        {
            _baseOtionData.Se.SetVolume(PlayerPrefs.GetFloat(_seVolumeKey, _defaultVolume));
            _baseOtionData.Se.SetMute(PlayerPrefs.GetInt(_seMuteKey, 0) == 1);
            _baseOtionData.SetMouseSensitivity(
                PlayerPrefs.GetFloat(_mouseSensitivityKey, _defaultMouseSensitivity));

            _settingOptionData = _baseOtionData;
        }

        public void SetSeVolume(float value)
        {
            _settingOptionData.Se.SetVolume(value);
            PlayerPrefs.SetFloat(_seVolumeKey, value);
        }

        public void SetSeMute(bool value)
        {
            _settingOptionData.Se.SetMute(value);
            PlayerPrefs.SetInt(_seMuteKey, value ? 1 : 0);
        }

        public void SetMouseSensitivity(float value)
        {
            _settingOptionData.SetMouseSensitivity(value);

            PlayerPrefs.SetFloat(_mouseSensitivityKey, value);
        }

        /// <summary>
        /// 変更前の状態にリセット
        /// </summary>
        public void RevertOption()
        {
            SetSeVolume(_baseOtionData.Se.Volume);
            SetSeMute(_baseOtionData.Se.IsMute);
            SetMouseSensitivity(_baseOtionData.MouseSensitivity);
            SaveOption();
        }

        public void ResetOption()
        {
            SetSeVolume(_defaultVolume);
            SetSeMute(_defaultMute);
            SetMouseSensitivity(_defaultMouseSensitivity);
            SaveOption();
        }

        /// <summary>
        /// PlayerPrefsに保存
        /// </summary>
        public void SaveOption()
        {
            _baseOtionData = _settingOptionData;
            PlayerPrefs.Save();
        }
    }
}
