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
    [SerializeField]
    private AudioClip _shootSe;
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float _moveSpeed = 5.0f;

    private readonly Vector3 _cameraOffset = new Vector3(0.0f, 0.0f, -10.0f);
    private readonly float _attackInterval = 2.0f;
    private readonly float _flashTime = 0.5f;
    private InputAction _moveAction;
    private InputAction _rotationAction;

    private float _attackIntervalTimer = 0.0f;

    private void Start()
    {
        // "Move"のリファレンスを探す
        _moveAction = InputSystem.actions.FindAction("Move");
        _rotationAction = InputSystem.actions.FindAction("Look");
    }

    private void Update()
    {
        UpdateLightIntensity();
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
        var moveValue = _moveAction.ReadValue<Vector2>();
        var move = new Vector2(moveValue.x, moveValue.y) * _moveSpeed * Time.deltaTime;
        transform.Translate(move);

        GameScene.MainCamera.transform.position = transform.position + _cameraOffset;

        _animator.SetBool("IsMove", moveValue.magnitude > 0.0f);
    }

    /// <summary>
    /// 回転処理
    /// </summary>
    private void Rotate()
    {
        var rotation = transform.rotation;
        rotation.z
            -= _rotationAction.ReadValue<Vector2>().x
                * OptionManager.Instance.OptionData.MouseSensitivity
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
            _muzzleFlash.SetActive(true);
            InGameSystem.Instance.ObjectManager
                .CreateObject<Bullet>(_muzzleFlash.transform.position, transform.rotation);
            AudioManager.Instance.PlaySE(_shootSe);
            _attackIntervalTimer = _attackInterval;
        }

        if (_attackIntervalTimer > 0.0f)
        {
            _attackIntervalTimer -= Time.deltaTime;

            if (_attackIntervalTimer < _attackInterval - _flashTime)
            {
                _muzzleFlash.SetActive(false);
            }
        }
    }

    private void UpdateLightIntensity()
    {
        _frontLight.intensity
            = InGameSystem.Context.AuxiliaryEnergy
                / InGameSystem.Instance.CurrentStageSetting.MaxPlayerEnergy;
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