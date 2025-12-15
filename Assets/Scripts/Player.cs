using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 3;
    private float _reloadTime = 0.5f;
    private float _speed = 10f;

    private float _currentReload = 0f;

    [SerializeField]
    private GameObject _bullet;

    void Update()
    {
        if (_currentReload != 0f)
        {
            _currentReload -= Time.deltaTime;
            if (_currentReload <= 0f)
            {
                _currentReload = 0f;
            }
        }

        // если нажал проблел » пушка готова выстрелить
        // то выстрели
        if (Input.GetKey(KeyCode.Space))
        {
            if (_currentReload == 0f)
            {
                Instantiate(_bullet, transform.position, Quaternion.identity);
                _currentReload = _reloadTime;
            }
        }

        // если игрок нажал стрелку направо
        // то подвинь объект направо на значение скорости
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }

        // если игрок нажал стрелку влево
        // то подвинь объект влево на значение скорости
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }
}
