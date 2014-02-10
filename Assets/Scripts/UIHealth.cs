using UnityEngine;
using System.Collections;

public class UIHealth : MonoBehaviour
{
    private int m_HealthPercentage;
    private PlayerHealth m_Health; 

	// Use this for initialization
	void Start () 
    {
        m_HealthPercentage = 0;
        m_Health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    // Update the health percentage. 
        m_HealthPercentage = m_Health.getHealth(); 
        drawUI(); 
	}

    private void drawUI()
    {
        guiText.text = "Health: " + m_HealthPercentage + "%";
    }
}
