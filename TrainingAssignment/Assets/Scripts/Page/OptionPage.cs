using Manager;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Page
{
    public class OptionContext : IContext
    {
        public OptionData OptionData { get; init; }
        public Action<float> OnUpdateSeVolume { get; init; }
        public Action<bool> OnUpdateSeMute { get; init; }
        public Action<float> OnUpdateMouseSensitivity { get; init; }
        public Action OnRevertOption { get; init; }
        public Action OnResetOption { get; init; }
        public Action OnSaveOption { get; init; }
        public Action OnClose { get; init; }
    }

    public class OptionPage : PageBase<OptionContext>
    {
        [SerializeField]
        private Slider _seVolume;
        [SerializeField]
        private Slider _mouseSensitivity;
        [SerializeField]
        private Toggle _seIsMuteToggle;

        protected override void OnSetup()
        {
            Time.timeScale = 0.0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            _seVolume.value = Context.OptionData.Se.Volume;
            _seIsMuteToggle.isOn = Context.OptionData.Se.IsMute;
            _mouseSensitivity.value = Context.OptionData.MouseSensitivity;
        }

        private void OnDestroy()
        {
            Time.timeScale = 1.0f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Context.OnClose.Invoke();
        }

        /// <summary>
        /// Se音量設定を更新(スライダーUIイベント用)
        /// </summary>
        public void UpdateSeVolume(float value)
        {
            Context.OnUpdateSeVolume.Invoke(value);
        }

        /// <summary>
        /// Seミュート設定を更新(トグルUIイベント用)
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
        /// 変更した設定をセーブ(トグルUIイベント用)
        /// </summary>
        public void SaveOption()
        {
            Context.OnSaveOption.Invoke();
        }

        /// <summary>
        /// S変更前の設定に戻す(トグルUIイベント用)
        /// </summary>
        public void RevertOption()
        {
            Context.OnRevertOption.Invoke();
        }

        /// <summary>
        /// 初期設定に戻す(トグルUIイベント用)
        /// </summary>
        public void ResetOption()
        {
            Context.OnResetOption.Invoke();
        }
    }
}
