using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Gun;
    public Text DeathScreen;

    #region Private Methods

    public void Restart()
    {
        DeathScreen.gameObject.SetActive(false);
        Wall.GetComponent<Wall>().Reset();
        Gun.GetComponent<Gun>().Reset();
        gameObject.GetComponent<EnemyPool>().Reset();

        Time.timeScale = 1;
    }

    #endregion Private Methods
}