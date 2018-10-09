using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text Cash;

    private void Start()
    {

    }

    public void Update()
    {
        Cash.text = "$" + Global.Cash;
    }
}