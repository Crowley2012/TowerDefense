using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Unity Methods

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals(Constants.MID_WALL))
            Destroy(gameObject);
    }

    #endregion Unity Methods
}