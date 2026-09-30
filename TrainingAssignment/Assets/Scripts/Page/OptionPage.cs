using Manager;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Page
{
    public class OptionContext : IContext
    {
        public OptionData optionData { get; init; }
        public Action<float> OnUpdateSeVolume { get; init; }
        public Action<bool> OnUpdateSeMute { get; init; }
        public Action<float> OnUpdateMouseSensitivity { get; init; }
        public Action OnRevertOption { get; init; }
        public Action OnResetOption { get; init; }
        public Action OnSaveOption { get; init; }
        public Action OnDestroy { get; init; }
    }

    public class OptionPage : PageBase<OptionContext>
    {
        [SerializeField]
        private Slider _seVolume;
        [SerializeField]
        private Slider _mouseSensitivity;
        [SerializeField]
        private Toggle _seIsMute;

        protected override void OnSetup()
        {
            Time.timeScale = 0.0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            _seVolume.value = Context.optionData.Se.Volume;
            _seIsMute.isOn = Context.optionData.Se.IsMute;
            _mouseSensitivity.value = Context.optionData.MouseSensivity;
        }

        private void OnDestroy()
        {
            Time.timeScale = 1.0f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Context.OnDestroy.Invoke();
        }

        /// <summary>
        /// Se音量設定を更新(スライダーUIイベント用)
        /// </summary>
        public void UpdateSeVolume(float value)
        {
            Context.OnUpdateSeVolume.Invoke(value);
        }

        /// <summary>
        /// Seミューーと設定を更新(トグルUIイベント用)
        /// </summary>
        public void UpdateSeMute(bool value)
        {
            Context.OnUpdateSeMute.Invoke(value);
        }

        /// <summary>
        /// マウス感度(自機視点移動)設定を更新(スライダーUIイベント用)
        /// </summary>
        public void UpdateMouseSensitivity(float value)
        {
            Context.OnUpdateMouseSensitivity.Invoke(value);
        }

        /// <summary>
        /// Seミューーと設定を更新(トグルUIイベント用)
        /// </summary>
        public void SaveOption()
        {
            Context.OnSaveOption.Invoke();
        }

        /// <summary>
        /// Seミューーと設定を更新(トグルUIイベント用)
        /// </summary>
        public void RevertOption()
        {
            Context.OnRevertOption.Invoke();
        }

        /// <summary>
        /// Seミュート設定を更新(トグルUIイベント用)
        /// </summary>
        public void ResetOption()
        {
            Context.OnResetOption.Invoke();
        }
    }
}
