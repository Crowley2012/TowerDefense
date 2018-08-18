using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    #region Public Variables
    public float WalkSpeed = 1.5f;
    public float Damage = 0.01f;
    private float Health = 100;
    public GameObject HealthText; 
    #endregion

    #region Unity Methods

    void Start()
    {
        Health = Random.Range(100, 150);
        HealthText.GetComponent<TextMesh>().text = Health.ToString();
    }

    void Update ()
    {
        transform.Translate(Vector3.back * Time.deltaTime * WalkSpeed, Space.World);

        if (Health <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.name.Contains("Bullet"))
            return;

        Health -= 20;
        HealthText.GetComponent<TextMesh>().text = Health.ToString();
    }
    #endregion
}
