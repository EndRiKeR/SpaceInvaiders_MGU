using UnityEngine;

public class Boot : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner _spawner;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private Transform _playerPosition;

    private GameObject _actualPlayer;

    private void Awake()
    {
        _spawner.CreateEnemies();
        _actualPlayer = Instantiate(_player.gameObject, _playerPosition.position, Quaternion.identity);
    }

    private void Update()
    {
        CheckInput();
        CheckForWin();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.R))
        {
            _spawner.DeleteEnemies();
            _spawner.CreateEnemies();

            _actualPlayer.transform.position = _playerPosition.position;
        }
    }

    private void CheckForWin()
    {
        if (_spawner.CountEnemies() == 0)
        {
            Debug.Log("Ты не проиграл =(");
            Debug.Log("Пока что =)");
            _spawner.CreateEnemies();
        }
    }
}