using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Public Fields

    public GameObject Bullet;
    public GameObject Smoke;
    public GameObject Casing;
    public Transform BulletSpawn;
    public Transform CasingSpawn;
    public float BulletSpeed = 500;

    #endregion Public Fields

    #region Private Methods

    private void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = Instantiate(Bullet, BulletSpawn.position, Bullet.transform.rotation);
        var smoke = Instantiate(Smoke, BulletSpawn.position, Smoke.transform.rotation);
        var casing = Instantiate(Casing, CasingSpawn.position, Casing.transform.rotation);

        // Get mouse position
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
            bullet.GetComponent<Rigidbody>().AddForce((hit.point - BulletSpawn.position).normalized * BulletSpeed);

        //Add force to casing
        casing.GetComponent<Rigidbody>().AddForce(-0.5f, 3f, 0, ForceMode.Impulse);

        // Destroy objects
        Destroy(bullet, 2.0f);
        Destroy(smoke, 3.0f);
        Destroy(casing, 3.0f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //TEENER
            Fire();
            Invoke("Fire", 0.05f);
            Invoke("Fire", 0.1f);
        }
    }

    #endregion Private Methods
}