using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Public Variables
    public float WalkSpeed = 1.5f;
    public float Damage = 0.01f;
    #endregion

    #region Unity Methods
    void Update ()
    {
        transform.Translate(Vector3.right * Time.deltaTime * WalkSpeed, Space.World);
    }
    #endregion
}
