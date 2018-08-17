using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private List<GameObject> Enemies;
    private List<GameObject> Pool;
    public GameObject Enemy;
    public int MaxEnemies = 10;

    void Start ()
    {
        Enemies = new List<GameObject>();
        Pool = new List<GameObject>();
    }
	
	void Update ()
    {
        //Spawn enemy
        if (Enemies.Count + Pool.Count < MaxEnemies)
            PoolEnemy();

        //Remove destroyed enemies
        Enemies = Enemies.Where(x => x != null).ToList();
    }

    void PoolEnemy()
    {
        Pool.Add(Enemy);
        InvokeRepeating("SpawnEnemy", Random.Range(2f, 10f), 0);
    }

    void SpawnEnemy()
    {
        var x = Random.Range(0f, 10f);
        var enemy = Pool.First();

        Enemies.Add(Instantiate(enemy, new Vector3(x, 1f, 20f), Quaternion.identity));
        Pool.Remove(enemy);
    }
}
