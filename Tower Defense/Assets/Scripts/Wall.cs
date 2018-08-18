using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    #region Public Fields

    public float Health = 100f;
    public Text HealthText;

    #endregion Public Fields

    #region Unity Methods

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (!collisionInfo.gameObject.name.Contains("EnemyPrefab"))
            return;

        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            Health -= collisionInfo.gameObject.GetComponent<Enemy>().Damage;

            HealthText.text = string.Format("Health: {0}", Health);

            Destroy(collisionInfo.gameObject);
        }
    }

    private void Start()
    {
        HealthText.text = string.Format("Health: {0}", Health);
    }

    #endregion Unity Methods
}