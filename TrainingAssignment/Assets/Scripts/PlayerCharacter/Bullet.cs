using UnityEngine;

public class Bullet : InteractionDetector
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _power = 100.0f;

    private static readonly float _activeTime = 10.0f;
    private float _timer = 0.0f;

    private void Start()
    {
        _rigidbody2D.AddForce(transform.up * _power, ForceMode2D.Impulse);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _activeTime)
        {
            Destroy(gameObject);
        }
    }
}
