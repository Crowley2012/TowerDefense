using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WavePool : MonoBehaviour
{
    #region Public Fields

    public GameObject Enemy;
    public int FirstWaveEnemies = 2;

    #endregion Public Fields

    #region Private Fields

    private List<GameObject> _pooled;
    private List<GameObject> _spawned;
    private bool _coolDown;

    #endregion Private Fields

    #region Unity Methods

    private void Start()
    {
        _spawned = new List<GameObject>();
        _pooled = new List<GameObject>();

        Global.Wave = 0;
        Global.WaveEnemyCount = FirstWaveEnemies;
    }

    private void Update()
    {
        //Pool all enemies for wave
        if (_pooled.Count == 0 && _spawned.Count == 0)
            NextWave();

        //Spawn enemies in pool
        if (_spawned.Count > 0 && _spawned.Count < Global.WaveEnemyCount && !_coolDown)
            SpawnEnemy();

        //Remove destroyed enemies
        _spawned = _spawned.Where(x => x != null).ToList();
    }

    #endregion Unity Methods

    #region Private Methods

    private void NextWave()
    {
        Global.Wave++;
        Global.WaveEnemyCount = Global.Wave * 2;

        //Populate pool with all wave enemies
        for (int i = 0; i < Global.WaveEnemyCount; i++)
            _pooled.Add(Enemy);

        //Start wave
        SpawnEnemy();
    }

    private IEnumerator CoolDown()
    {
        _coolDown = true;
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        _coolDown = false;
    }

    private void SpawnEnemy()
    {
        if (_pooled.Count == 0)
            return;

        //Instantiate enemy and remove from pool
        var enemy = _pooled[0];
        _spawned.Add(Instantiate(enemy, new Vector3(Random.Range(0f, 10f), 1f, 30f), Quaternion.identity));
        _pooled.Remove(enemy);

        //Spawn cool down
        StartCoroutine(CoolDown());
    }

    #endregion Private Methods
}