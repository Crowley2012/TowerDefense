using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Gun;
    public Text DeathScreen;
    public Text Cash;

    #region Private Methods

    public void Update()
    {
        Cash.text = "$" + Global.Cash;
    }

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