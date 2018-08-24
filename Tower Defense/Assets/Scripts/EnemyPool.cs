using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    #region Public Fields

    public GameObject Enemy;

    #endregion Public Fields

    #region Private Fields

    private bool _coolDown;
    private List<GameObject> _pooled;
    private List<GameObject> _spawned;

    #endregion Private Fields

    #region Unity Methods

    private void Start()
    {
        _spawned = new List<GameObject>();
        _pooled = new List<GameObject>();
    }

    private void Update()
    {
        //Pool all enemies for wave
        if (_pooled.Count == 0 && _spawned.Count == 0)
        {
            gameObject.GetComponent<Waves>().NextWave();
            PoolEnemies();
        }

        //Spawn enemies in pool
        if (_spawned.Count > 0 && _spawned.Count < gameObject.GetComponent<Waves>().MaxSpawnedEnemies && !_coolDown)
            SpawnEnemy();

        //Remove destroyed enemies
        _spawned = _spawned.Where(x => x != null).ToList();
    }

    #endregion Unity Methods

    #region Public Methods

    public void Reset()
    {
        CancelInvoke();

        //Destroy all spawned enemies
        _spawned.ForEach(x => Destroy(x.gameObject));

        _spawned = new List<GameObject>();
        _pooled = new List<GameObject>();
    }

    #endregion Public Methods

    #region Private Methods

    private IEnumerator CoolDown()
    {
        _coolDown = true;
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        _coolDown = false;
    }

    private void PoolEnemies()
    {
        //Populate pool for all wave enemies
        for (int i = 0; i < gameObject.GetComponent<Waves>().TotalWaveEnemies; i++)
            _pooled.Add(Enemy);

        //Start off the wave
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (_pooled.Count == 0)
            return;

        //Instantiate enemy and remove from pool
        var enemy = _pooled.First();
        _spawned.Add(Instantiate(enemy, new Vector3(Random.Range(0f, 10f), 1f, 30f), Quaternion.identity));
        _pooled.Remove(enemy);

        //Spawn cool down
        StartCoroutine(CoolDown());
    }

    #endregion Private Methods
}