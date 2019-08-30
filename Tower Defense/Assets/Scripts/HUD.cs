using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    #region Public Fields

    public Text Cash;
    public Slider HealthSlider;
    public Text WaveText;
    public GameObject DeathScreen;
    public GameObject ShopPanel;

    #endregion Public Fields

    #region Public Methods

    public void Update()
    {
        Cash.text = $"${Global.Cash}";
        WaveText.text = $"Wave {Global.Wave}";
        HealthSlider.value = Global.Health;

        if (Global.Dead)
            ShowDeathScreen();
        else if (Global.ShopOpen && !ShopPanel.activeSelf)
            ShopPanel.SetActive(true);
    }

    #endregion Public Methods

    #region Private Methods

    public void Restart()
    {
        Global.ShopOpen = false;
        Global.Cash = 0;
        Global.ShopOpen = false;
        ShopPanel.SetActive(false);
        Global.Dead = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void ShowDeathScreen()
    {
        Time.timeScale = 0;
        DeathScreen.gameObject.SetActive(true);
    }

    #endregion Private Methods
}