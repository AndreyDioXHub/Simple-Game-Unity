using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.HiHitMe += SpawnEnemy;
    }

    public void SpawnALotOfEnemy()
    {
        Instantiate(_player, new Vector3(0, 1.71f,0), Quaternion.identity);

        for (int i = 0; i < _spawnPoints.Count / 2; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count - 1);
        var newEnemy = Instantiate(_enemy, _spawnPoints[randomIndex].position, _spawnPoints[randomIndex].rotation);
        newEnemy.GetComponent<Enemy>().Power = Random.Range(2, 4);
    }

    
}
