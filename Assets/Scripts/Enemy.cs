using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _health = 100;

    public void GetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
