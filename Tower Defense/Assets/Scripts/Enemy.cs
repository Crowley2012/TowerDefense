using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Public Fields

    public GameObject BloodSplatter;
    public GameObject HealthText;
    public float MaxSpeed = 1.5f;
    public float RecoverySpeed = 1f;
    public float Damage;
    public float Health;

    #endregion Public Fields

    #region Private Fields

    private float _currentSpeed;

    #endregion Private Fields

    #region Unity Methods

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            //Decrement health
            Health -= 20;

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
        _currentSpeed = MaxSpeed;
        Health = Random.Range(100, 150);
        Damage = Random.Range(5f, 20f);
    }

    private void OnDestroy()
    {
        Global.Cash += 50;
    }

    private void Update()
    {
        //Move unit forward
        transform.Translate(Vector3.back * Time.deltaTime * _currentSpeed, Space.World);

        //Update text
        HealthText.GetComponent<TextMesh>().text = _currentSpeed.ToString();

        //Destroy unit when killed
        if (Health <= 0)
            Death();

        //Prevent backwards movement
        if (_currentSpeed <= 0f)
            _currentSpeed = 0.10f;
    }

    #endregion Unity Methods

    #region Private Methods

    private void Death()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        gameObject.GetComponent<Rigidbody>().mass = 2;
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 10f);
        _currentSpeed = 0;

        Destroy(gameObject, 3f);
    }

    private void Recover()
    {
        if (_currentSpeed < MaxSpeed)
        {
            //Increase speed exponentially
            _currentSpeed *= 1.5f;

            if (_currentSpeed > MaxSpeed)
                _currentSpeed = MaxSpeed;
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