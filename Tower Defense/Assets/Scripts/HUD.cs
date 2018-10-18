using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    #region Public Fields

    public Text Cash;
    public Text DeathScreen;
    public Slider HealthSlider;
    public Text WaveText;
    public GameObject ShopPanel;

    #endregion Public Fields

    #region Public Methods

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Update()
    {
        Cash.text = $"${Global.Cash}";
        WaveText.text = $"Wave {Global.Wave}";
        HealthSlider.value = Global.Health;

        if (Global.Dead)
            ShowDeathScreen();

        if (Global.ShopOpen && !ShopPanel.activeSelf)
            ShopPanel.SetActive(true);
    }

    #endregion Public Methods

    #region Private Methods

    private void ShowDeathScreen()
    {
        Global.Dead = false;
        Time.timeScale = 0;
        DeathScreen.gameObject.SetActive(true);
    }

    #endregion Private Methods
}