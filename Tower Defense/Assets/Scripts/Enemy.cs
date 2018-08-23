using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Public Fields

    public GameObject BloodSplatter;
    public float Damage = 3f;
    public GameObject HealthText;
    public float MaxSpeed = 1.5f;
    public float RecoverySpeed = 1f;

    #endregion Public Fields

    #region Private Fields

    private float _currentSpeed;
    private float _health;

    #endregion Private Fields

    #region Unity Methods

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            //Decrement health
            _health -= 20;

            //Show blood splatter
            var blood = Instantiate(BloodSplatter, collision.contacts[0].point, collision.transform.rotation);
            Destroy(blood, 2.0f);

            //Decrease speed of unit when hit
            _currentSpeed -= 0.5f;

            //Decrease max speed
            MaxSpeed -= 0.1f;

            //Start movement speed recovery
            if (!IsInvoking("Recover"))
                InvokeRepeating("Recover", 0, RecoverySpeed);
        }
    }

    private void Start()
    {
        //Set current speed
        _currentSpeed = MaxSpeed;

        //Choose a health level
        _health = Random.Range(100, 150);
    }

    private void Update()
    {
        //Move unit forward
        transform.Translate(Vector3.back * Time.deltaTime * _currentSpeed, Space.World);

        //Update text
        HealthText.GetComponent<TextMesh>().text = _currentSpeed.ToString();

        //Destroy unit when killed
        if (_health <= 0)
            Destroy(gameObject);

        //Prevent backwards movement
        if (_currentSpeed < 0f)
            _currentSpeed = 0.25f;
    }

    #endregion Unity Methods

    #region Private Methods

    private void Recover()
    {
        if (_currentSpeed < MaxSpeed)
        {
            //Increase speed exponentially
            _currentSpeed *= 2f;
        }
        else
        {
            //Prevent movement faster than max speed and cancel recovery
            _currentSpeed = MaxSpeed;
            CancelInvoke("Recover");
        }
    }

    #endregion Private Methods
}