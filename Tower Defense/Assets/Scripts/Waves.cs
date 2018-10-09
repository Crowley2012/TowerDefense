using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    #region Public Fields

    public int MaxSpawnedEnemies = 5;
    public int TotalWaveEnemies;
    public Text WaveText;

    #endregion Public Fields

    #region Private Fields

    private int _currentWave;

    #endregion Private Fields

    #region Public Methods

    public void NextWave()
    {
        _currentWave++;
        UpdateText();

        TotalWaveEnemies = _currentWave * 2;
        MaxSpawnedEnemies++;
    }

    public void Reset()
    {
        MaxSpawnedEnemies = 5;
        _currentWave = 0;
    }

    #endregion Public Methods

    #region Private Methods

    private void UpdateText()
    {
        WaveText.text = $"Wave {_currentWave}";
    }

    #endregion Private Methods
}