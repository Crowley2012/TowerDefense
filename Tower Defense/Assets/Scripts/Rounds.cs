using UnityEngine;
using UnityEngine.UI;

public class Rounds : MonoBehaviour
{
    #region Public Fields

    public int RoundEnemies;
    public Text RoundText;

    #endregion Public Fields

    #region Private Fields

    private int _currentRound;

    #endregion Private Fields

    #region Public Methods

    public void NextRound()
    {
        _currentRound++;
        UpdateText();

        RoundEnemies = _currentRound * 2;
    }

    #endregion Public Methods

    #region Private Methods

    private void UpdateText()
    {
        RoundText.text = string.Format("Round {0}", _currentRound);
    }

    #endregion Private Methods
}