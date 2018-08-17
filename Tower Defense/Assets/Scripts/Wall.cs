using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    #region Game Objects
    public Text HealthText;
    #endregion

    #region Public Variables
    public float Health = 100f;
    #endregion

    #region Unity Methods
    void Start ()
    {
        HealthText.text = string.Format("Health: {0}", Health);
    }

    void OnCollisionStay(Collision collisionInfo)
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
    #endregion
}
