using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text Cash;

    public void Update()
    {
        Cash.text = $"${Global.Cash}";
    }
}