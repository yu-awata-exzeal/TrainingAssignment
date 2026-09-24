
using UnityEngine;
using UnityEngine.InputSystem;

namespace Manager
{
    public class InputManager
    {
        private InputAction _moveAction;
        private InputAction _rotationAction;

        public void Setup()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
        }

        /// <summary>
        /// 入力状態を更新する
        /// </summary>
        public void UpdateInputs()
        {
            UpdateMoveInput();
            UpdateRotateInput();
        }

        private void UpdateMoveInput()
        {
            // 移動処理
            var moveValue = _moveAction.ReadValue<Vector2>();
            var move = new Vector2(moveValue.x, moveValue.y) * Time.deltaTime;


        }

        private void UpdateRotateInput()
        {
            var rotationValue = _rotationAction.ReadValue<Vector2>();
        }
    }
}
