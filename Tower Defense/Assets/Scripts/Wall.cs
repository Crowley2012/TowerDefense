using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    #region Public Fields

    public Text DeathScreen;
    public Slider HealthSlider;
    public float MaxHealth = 100f;

    #endregion Public Fields

    #region Private Fields

    private float _currentHealth;

    #endregion Private Fields

    #region Unity Methods

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (!collisionInfo.gameObject.name.Contains("EnemyPrefab"))
            return;

        _currentHealth -= collisionInfo.gameObject.GetComponent<Enemy>().Damage;

        if (_currentHealth <= 0)
            Death();
        else
            HealthSlider.value = _currentHealth / MaxHealth;

        Destroy(collisionInfo.gameObject);
    }

    private void Start()
    {
        _currentHealth = MaxHealth;
    }

    #endregion Unity Methods

    #region Private Methods

    public void Reset()
    {
        _currentHealth = MaxHealth;
        HealthSlider.value = _currentHealth / MaxHealth;
    }

    #endregion Private Methods

    #region Private Methods

    private void Death()
    {
        HealthSlider.value = 0;
        DeathScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    #endregion Private Methods
}