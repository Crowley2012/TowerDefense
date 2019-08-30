using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    #region Private Fields

    private float _accumulatedTime = 0;
    private int _frame;
    private float _timeLeft = 0.5F;

    #endregion Private Fields

    #region Private Methods

    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        _accumulatedTime += Time.timeScale / Time.deltaTime;
        ++_frame;

        if (_timeLeft <= 0.0)
        {
            gameObject.GetComponent<Text>().text = $"{_accumulatedTime / _frame:0}";

            _timeLeft = 0.5F;
            _accumulatedTime = 0.0F;
            _frame = 0;
        }
    }

    #endregion Private Methods
}