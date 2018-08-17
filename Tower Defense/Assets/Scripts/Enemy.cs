using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Public Variables
    public float WalkSpeed = 1.5f;
    public float Damage = 0.01f;
    private float Health = 100;
    #endregion

    #region Unity Methods

    void Start()
    {
        Health = Random.Range(100f, 150f);
    }

    void Update ()
    {
        transform.Translate(Vector3.back * Time.deltaTime * WalkSpeed, Space.World);

        if (Health <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Bullet"))
            Health -= 20;
    }
    #endregion
}
