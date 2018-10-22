using UnityEngine;

public class Weather : MonoBehaviour
{
    #region Public Fields

    public GameObject CloudGroup1;
    public GameObject CloudGroup2;
    public Transform EndPosition;
    public float Speed = 1.5f;

    #endregion Public Fields

    #region Private Fields

    private Vector3 _startPosition;

    #endregion Private Fields

    #region Unity Methods

    private void Start()
    {
        _startPosition = CloudGroup1.transform.position;
    }

    private void Update()
    {
        CloudGroup1.transform.Translate(Vector3.back * Time.deltaTime * Speed, Space.World);
        CloudGroup2.transform.Translate(Vector3.back * Time.deltaTime * Speed, Space.World);

        if (CloudGroup1.transform.position.z <= EndPosition.position.z)
            CloudGroup1.transform.position = _startPosition;

        if (CloudGroup2.transform.position.z <= EndPosition.position.z)
            CloudGroup2.transform.position = _startPosition;
    }

    #endregion Unity Methods
}