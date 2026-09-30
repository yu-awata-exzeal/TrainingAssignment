using Manager;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerCharacter : InteractionDetector
{
    /// <summary>
    /// 前方を照らすライト
    /// </summary>
    [SerializeField]
    private Light2D _frontLight;
    /// <summary>
    /// マズルフラッシュ
    /// </summary>
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private Animator _animator;
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float _speed = 5.0f;
    /// <summary>
    /// 攻撃距離
    /// </summary>
    [SerializeField]
    private float _attackRange = 30.0f;

    private readonly Vector3 _startPosition = new Vector3(0.0f, 4.0f, 0.0f);
    private readonly Vector3 _cameraOffset = new Vector3(0.0f, 0.0f, -10.0f);
    private readonly float _attackIntervalTime = 2.0f;
    private readonly float _flashTime = 0.5f;
    private InputAction _moveAction;
    private InputAction _rotationAction;

    private float _attackIntervalTimer = 0.0f;


    private void Start()
    {
        // "Move"のリファレンスを探す
        _moveAction = InputSystem.actions.FindAction("Move");
        _rotationAction = InputSystem.actions.FindAction("Look");

        transform.position = _startPosition;
    }

    private void Update()
    {
        ChangeLightPower();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        Attack();
        InteractButtonInput();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void Move()
    {
        // 移動処理
        var moveValue = _moveAction.ReadValue<Vector2>();
        var move = new Vector2(moveValue.x, moveValue.y) * _speed * Time.deltaTime;
        transform.Translate(move);

        GameScene.MainCamera.transform.position = transform.position + _cameraOffset;

        _animator.SetBool("IsMove", moveValue.magnitude > 0.0f);
    }

    private void Rotate()
    {
        var rotation = transform.rotation;
        rotation.z
            -= _rotationAction.ReadValue<Vector2>().x
                * OptionManager.Instance.OptionData.MouseSensivity
                * Time.deltaTime;

        transform.rotation = rotation;
    }

    /// <summary>
    /// 攻撃処理
    /// </summary>
    private void Attack()
    {
        if (InputSystem.actions.FindAction("Attack").WasPressedThisFrame())
        {
            CheckRaycastInteractable(transform.position, transform.up, _attackRange);

            _muzzleFlash.SetActive(true);
            _attackIntervalTimer = _attackIntervalTime;
        }

        if (_attackIntervalTimer > 0.0f)
        {
            _attackIntervalTimer -= Time.deltaTime;

            if (_attackIntervalTimer < _attackIntervalTime - _flashTime)
            {
                _muzzleFlash.SetActive(false);
            }
        }
    }

    private void ChangeLightPower()
    {
        _frontLight.intensity
            = InGameSystem.Context.AuxiliaryEnergy / InGameSystem.Instance.CurrentStageSetting.MaxPlayerEnergy;
    }

    /// <summary>
    /// ボタン入力によるインタラクト処理
    /// </summary>
    private void InteractButtonInput()
    {
        if (InputSystem.actions.FindAction("Interact").WasPressedThisFrame())
        {
            Interact(InteractType.ButtonInput);
        }
    }
}