using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Public Enums

    public enum FireModes { Single, Burst, Auto }

    #endregion Public Enums

    #region Public Fields

    public GameObject AmmoText;
    public GameObject Bullet;
    public Transform BulletSpawn;
    public float BulletSpeed = 500;
    public int BurstRounds = 3;
    public GameObject Casing;
    public Transform CasingSpawn;
    public int ClipSize = 30;
    public FireModes FireMode;
    public float FireRate = 0.1f;
    public GameObject Smoke;

    #endregion Public Fields

    #region Private Fields

    private int _burstCount = 3;
    private int _currentClip;
    private bool _fireable = true;

    #endregion Private Fields

    #region Unity Methods

    private void Start()
    {
        _currentClip = ClipSize;
        UpdateGunText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _currentClip != ClipSize)
            StartCoroutine(Reload());

        if (Input.GetKeyDown(KeyCode.F))
            ToggleFireModes();

        switch (FireMode)
        {
            case FireModes.Single:
                if (Input.GetMouseButtonDown(0))
                    Fire();
                break;

            case FireModes.Burst:
                if (Input.GetMouseButtonDown(0))
                {
                    float wait = 0f;

                    for (int i = 0; i < BurstRounds; i++)
                    {
                        Invoke("Fire", wait);
                        wait += 0.1f;
                    }
                }
                break;

            case FireModes.Auto:
                if (Input.GetMouseButton(0))
                    Fire();
                break;
        }
    }

    #endregion Unity Methods

    #region Public Methods

    public void Reset()
    {
        _currentClip = ClipSize;
        FireMode = FireModes.Single;
        UpdateGunText();
    }

    #endregion Public Methods

    #region Private Methods

    private void Fire()
    {
        if (_currentClip <= 0 || !_fireable)
            return;

        // Create the Bullet from the Bullet Prefab
        var bullet = Instantiate(Bullet, BulletSpawn.position, Bullet.transform.rotation);
        var smoke = Instantiate(Smoke, BulletSpawn.position, Smoke.transform.rotation);
        var casing = Instantiate(Casing, CasingSpawn.position, Casing.transform.rotation);

        // Get mouse position
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
            bullet.GetComponent<Rigidbody>().AddForce((hit.point - BulletSpawn.position).normalized * BulletSpeed);

        // Add force to casing
        casing.GetComponent<Rigidbody>().AddForce(-0.5f, 3f, 0, ForceMode.Impulse);

        // Destroy objects
        Destroy(bullet, 2.0f);
        Destroy(smoke, 3.0f);
        Destroy(casing, 3.0f);

        // Subtract round
        _currentClip--;
        UpdateGunText();

        // Increment Burst
        _burstCount++;

        // Reload if clip is empty
        if (_currentClip <= 0)
            StartCoroutine(Reload());

        // Fire rate
        else if (FireMode != FireModes.Burst || _burstCount == 3)
            StartCoroutine(Fireable());
    }

    private IEnumerator Fireable()
    {
        _fireable = false;

        // Add additional time to burst
        yield return new WaitForSeconds(FireMode == FireModes.Burst ? FireRate + 0.2f : FireRate);

        _burstCount = 0;
        _fireable = true;
    }

    private IEnumerator Reload()
    {
        _fireable = false;
        AmmoText.GetComponent<TextMesh>().text = "Reloading";

        yield return new WaitForSeconds(3);

        _fireable = true;
        _currentClip = ClipSize;
        _burstCount = 0;
        UpdateGunText();
    }

    private void ToggleFireModes()
    {
        FireMode = FireMode == FireModes.Auto ? FireModes.Single : ++FireMode;

        if (_fireable)
            UpdateGunText();
    }

    private void UpdateGunText()
    {
        AmmoText.GetComponent<TextMesh>().text = string.Format("{0}\n{1}/{2}", FireMode, _currentClip, ClipSize);
    }

    #endregion Private Methods
}