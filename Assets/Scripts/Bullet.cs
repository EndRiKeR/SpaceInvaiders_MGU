using JetBrains.Annotations;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage = 30;
    private float _speed = 10f;
    public float _test = 100f;

    void FixedUpdate()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var myBullet = other.GetComponent<Bullet>();

        // enemy
        if (other.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            Debug.Log("Dead by enemy");
            enemy.GetDamage(_damage);
            Destroy(this.gameObject);
        }

        // invis wall
        if (other.gameObject.TryGetComponent<Wall>(out var wall))
        {
            Debug.Log("Dead by wall");
            Destroy(this.gameObject);
        }
    }
}
