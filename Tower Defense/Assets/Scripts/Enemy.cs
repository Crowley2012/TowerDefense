using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Public Fields

    public float Damage = 0.01f;
    public GameObject HealthText;
    public float WalkSpeed = 1.5f;

    #endregion Public Fields

    #region Private Fields

    private float Health = 100;

    #endregion Private Fields

    #region Unity Methods

    private void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.name.Contains("Bullet"))
            return;

        Health -= 20;
        HealthText.GetComponent<TextMesh>().text = Health.ToString();
    }

    private void Start()
    {
        Health = Random.Range(100, 150);
        HealthText.GetComponent<TextMesh>().text = Health.ToString();
    }

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * WalkSpeed, Space.World);

        if (Health <= 0)
            Destroy(gameObject);
    }

    #endregion Unity Methods
}