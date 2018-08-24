using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    #region Public Fields

    public float UpdateInterval = 0.5F;

    #endregion Public Fields

    #region Private Fields

    private float _accumulatedTime = 0;
    private int _frame;
    private float _timeLeft;

    #endregion Private Fields

    #region Private Methods

    private void Start()
    {
        _timeLeft = UpdateInterval;
    }

    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        _accumulatedTime += Time.timeScale / Time.deltaTime;
        ++_frame;

        if (_timeLeft <= 0.0)
        {
            float fps = _accumulatedTime / _frame;
            gameObject.GetComponent<Text>().text = System.String.Format("{0:F0} FPS", fps);

            if (fps < 30)
                gameObject.GetComponent<Text>().material.color = Color.yellow;
            else
                if (fps < 10)
                gameObject.GetComponent<Text>().material.color = Color.red;
            else
                gameObject.GetComponent<Text>().material.color = Color.green;

            _timeLeft = UpdateInterval;
            _accumulatedTime = 0.0F;
            _frame = 0;
        }
    }

    #endregion Private Methods
}