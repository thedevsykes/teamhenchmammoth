using UnityEngine;
using System.Collections;

public class UIBattery : MonoBehaviour
{
    private int m_BatteryPercentage;
    private PlayerTorch m_Torch;

    // Use this for initialization
    void Start()
    {
        m_BatteryPercentage = 0;
        m_Torch = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTorch>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the health percentage. 
        m_BatteryPercentage = m_Torch.getBatteryPercent();
        drawUI();
    }

    private void drawUI()
    {
        guiText.text = "Battery: " + m_BatteryPercentage + "%";
    }
}
