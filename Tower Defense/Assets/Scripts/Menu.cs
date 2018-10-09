using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    #region Public Fields

    public Text DeathScreen;
    public GameObject Gun;
    public GameObject Wall;

    #endregion Public Fields

    #region Private Methods

    public void Restart()
    {
        DeathScreen.gameObject.SetActive(false);
        Wall.GetComponent<Wall>().Reset();
        Gun.GetComponent<Gun>().Reset();
        gameObject.GetComponent<EnemyPool>().Reset();
        gameObject.GetComponent<Waves>().Reset();

        Time.timeScale = 1;
    }

    #endregion Private Methods
}