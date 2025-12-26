using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private Transform[] _enemySpawner;

    public void CreateEnemies()
    {
        foreach (Transform t in _enemySpawner)
        {
            Instantiate(_enemy, t.position, Quaternion.identity, transform);
        }
    }

    public void DeleteEnemies()
    {
        Enemy[] enemies = GetComponentsInChildren<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }

    public int CountEnemies()
    {
        Enemy[] enemies = GetComponentsInChildren<Enemy>();

        return enemies.Length;
    }
}