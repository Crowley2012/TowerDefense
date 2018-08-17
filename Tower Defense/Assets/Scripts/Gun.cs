using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletSpawn;

    public float test = 10000;

	void Start ()
    {
		
	}

	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
            Fire();
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);

        // Get mouse position
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
            bullet.GetComponent<Rigidbody>().AddForce((hit.point - BulletSpawn.position).normalized * test);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
