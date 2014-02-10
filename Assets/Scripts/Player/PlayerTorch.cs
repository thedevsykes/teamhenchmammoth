using UnityEngine;
using System.Collections;

public class PlayerTorch : MonoBehaviour 
{
    public Color m_LightColor;

    private GameObject m_LightObject;
    private Vector3 m_LightDirection;
    private int m_BatteryPercentage;
    private bool m_PowerOn;
    private float m_TimePassed;
    private float m_FlickerTimer; 

	// Use this for initialization
	void Start () 
    {
        m_BatteryPercentage = 15;
        m_PowerOn = true; 

	    // Create torch at player. 
        m_LightObject = new GameObject("Player Torch");
        m_LightObject.AddComponent<Light>();
        m_LightObject.light.color = m_LightColor;
        m_LightObject.transform.position = new Vector3(this.transform.position.x + 1.0f,
                                                       this.transform.position.y,
                                                       this.transform.position.z);

        m_LightObject.light.type = LightType.Spot;
        m_LightObject.light.renderMode = LightRenderMode.ForcePixel;
        m_LightObject.light.spotAngle = 45;

        m_LightObject.transform.Rotate(new Vector3(0, 90, 0));
	}
	
	// Update is called once per frame
	void Update () 
    {
	    m_TimePassed += Time.deltaTime;
        m_FlickerTimer += Time.deltaTime;
        
		if (m_PowerOn)
        {
            if (m_BatteryPercentage > 0)
            {
                // Drain battery life. 
                if (m_TimePassed > 2) // 2 Second
                {
                    m_TimePassed = 0;
                    m_BatteryPercentage--;
                }

            }

            // Give it a brief flicker before it completely dies out. 
            if (m_BatteryPercentage <= 5 && m_BatteryPercentage > 0)
            {
                if (m_FlickerTimer > 2)
                {
                    m_LightObject.light.enabled = false;
                }

                if (m_FlickerTimer > 4)
                {
                    m_FlickerTimer = 0;
                    m_LightObject.light.enabled = true;
                }
            }
        }
		
		if ( !m_PowerOn  && !m_LightObject.light.enabled) 
		{
			// Add power (temp) 
			if ( m_BatteryPercentage < 100 )
			{
				if ( m_TimePassed > 2 ) 
				{
					m_TimePassed = 0; 
					m_BatteryPercentage++;
				}
			}
		}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_PowerOn)
            {
                m_PowerOn = false;
                m_LightObject.light.enabled = false;
            }
            else
            {
                m_PowerOn = true;
                m_LightObject.light.enabled = true;
            }
        }
      
        m_LightObject.transform.position = new Vector3(this.transform.position.x,
                                                          this.transform.position.y,
                                                          this.transform.position.z);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        m_LightObject.transform.forward = new Vector3(ray.direction.x, ray.direction.y, 0) * Time.deltaTime;
        m_LightDirection = m_LightObject.transform.forward;
	}

    public Vector3 getLightDirection()
    {
        return m_LightDirection;
    }

    public void takeBattery(int amount)
    {
        if (m_BatteryPercentage > 0)
        {
            m_BatteryPercentage -= amount;
        }
    }

    public void giveBattery(int amount)
    {
        int newAmount = m_BatteryPercentage + amount;

        if (newAmount > 100)
        {
            amount = 100 - m_BatteryPercentage; 
        }

        m_BatteryPercentage += amount;
    }

    public int getBatteryPercent()
    {
        return m_BatteryPercentage;
    }
}
