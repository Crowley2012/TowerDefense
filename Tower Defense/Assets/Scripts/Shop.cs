using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    #region Public Fields

    public Text Cash;
    public Slider HealthSlider;

    #endregion Public Fields

    #region Unity Methods

    private void OnEnable()
    {
        OpenShop();
    }

    #endregion Unity Methods

    #region Public Methods

    public void CloseShop()
    {
        Global.ShopOpen = false;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Heal()
    {
        if (Global.Cash < 1000)
            return;

        Global.Cash -= 1000;
        Global.Health += 25f;
        Cash.text = $"${Global.Cash}";
        HealthSlider.value = Global.Health;
    }

    public void OpenShop()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    #endregion Public Methods
}