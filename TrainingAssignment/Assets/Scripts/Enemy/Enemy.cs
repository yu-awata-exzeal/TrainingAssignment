using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 徘徊範囲
    /// </summary>
    [SerializeField]
    private BoxCollider2D _wanderArea;
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float _moveSpeed = 2f;
    /// <summary>
    /// 速度が変化する速さ
    /// </summary>
    [SerializeField]
    private float _acceleration = 3f;
    /// <summary>
    /// 方向転換の間隔
    /// </summary>
    [SerializeField]
    private float _directionChangeInterval = 2f;
    /// <summary>
    /// 方向転換時の最大値
    /// </summary>
    [SerializeField]
    private float _directionChangeAngle = 60f;
    /// <summary>
    /// 範囲の端からどれぐらい違づけば戻るか
    /// </summary>
    [SerializeField]
    private float _edgeDistance = 1f;
    /// <summary>
    /// 行動不能状態の継続時間
    /// </summary>
    [SerializeField]
    private float _incapacitatedDuration = 3.0f;
    [SerializeField]
    private int _maxHitPoint = 3;

    private Rigidbody2D _rigidbody;
    private Bounds _bounds;
    private Vector2 _direction;
    private float _directionTimer;

    private float _incapacitatedTimer;
    private int _currentHitPoint = 0;

    private bool _isIncapacitated = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _currentHitPoint = _maxHitPoint;
        _bounds = _wanderArea.bounds;
        _direction = Random.insideUnitCircle.normalized;
        _directionTimer = _directionChangeInterval;
    }

    private void Update()
    {
        ChangeIncapacitated();
    }

    private void FixedUpdate()
    {
        if (!_isIncapacitated)
        {
            UpdateDirection();
            UpdateMovement();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _currentHitPoint--;

        if (_currentHitPoint == 0)
        {
            _isIncapacitated = true;
        }
    }

    /// <summary>
    /// 移動方向の更新
    /// </summary>
    private void UpdateDirection()
    {
        _directionTimer -= Time.fixedDeltaTime;

        if (_directionTimer <= 0f)
        {
            ChangeDirection();
            _directionTimer = _directionChangeInterval;
        }

        // 範囲の端に近づいたら内側へ向ける
        Vector2 position = _rigidbody.position;


        Vector2 center = _bounds.center;
        Vector2 toCenter = center - position;

        if (IsNearEdge(position, _bounds))
        {
            _direction = Vector2.Lerp(
                _direction,
                toCenter.normalized,
                0.1f
            ).normalized;
        }
    }

    private void ChangeDirection()
    {
        float angle = Random.Range(
            -_directionChangeAngle,
            _directionChangeAngle
        );

        _direction = Quaternion.Euler(0f, 0f, angle) * _direction;
        _direction.Normalize();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void UpdateMovement()
    {
        Vector2 targetVelocity = _direction * _moveSpeed;

        _rigidbody.linearVelocity = Vector2.MoveTowards(
            _rigidbody.linearVelocity,
            targetVelocity,
            _acceleration * Time.fixedDeltaTime
        );
    }

    /// <summary>
    /// 現在位置が範囲の端に近いかを判定
    /// </summary>
    /// <param name="position"> 現在位置 </param>
    /// <param name="bounds"> 徘徊範囲 </param>
    /// <returns> 範囲の端に近いか </returns>
    private bool IsNearEdge(Vector2 position, Bounds bounds)
    {
        return
            position.x < bounds.min.x + _edgeDistance ||
            position.x > bounds.max.x - _edgeDistance ||
            position.y < bounds.min.y + _edgeDistance ||
            position.y > bounds.max.y - _edgeDistance;
    }

    private void ChangeIncapacitated()
    {
        if (_isIncapacitated)
        {
            _incapacitatedTimer += Time.deltaTime;

            if (_incapacitatedTimer > _incapacitatedDuration)
            {
                _incapacitatedTimer = 0;
                _isIncapacitated = false;
                _currentHitPoint = _maxHitPoint;
            }
        }
    }
}
