using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _health = 100;

    [SerializeField]
    private float _speedY = 0.5f;

    [SerializeField]
    private float _speedX = 1f;

    [SerializeField]
    private AnimationCurve _curve;
    private float _time = 0f;

    public void GetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // пер по Y
        transform.position += Vector3.down * _speedY * Time.deltaTime;

        // пер по x
        float currentValue = _curve.Evaluate(_time);
        if (currentValue > 0)
        {
            // levo
            transform.position += Vector3.left * _speedX * Time.deltaTime;
        }
        else if (currentValue < 0)
        {
            // pravo
            transform.position += Vector3.right * _speedX * Time.deltaTime;
        }

        _time += Time.deltaTime;

        if (_time > 1f)
        {
            _time -= 1f;
        }
    }
}
