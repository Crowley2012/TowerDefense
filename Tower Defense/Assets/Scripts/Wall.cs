using UnityEngine;

public class Wall : MonoBehaviour
{
    #region Public Fields

    public float MaxHealth = 100f;

    #endregion Public Fields

    #region Unity Methods

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (!collisionInfo.gameObject.name.Contains(Constants.ENEMY))
            return;

        Global.Health -= collisionInfo.gameObject.GetComponent<Enemy>().Damage;
        Destroy(collisionInfo.gameObject);

        if (Global.Health <= 0)
            Global.Dead = true;
    }

    private void Start()
    {
        Global.Health = MaxHealth;
    }

    #endregion Unity Methods
}