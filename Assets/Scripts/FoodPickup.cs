using UnityEngine;
using System.Collections;

public class FoodPickup : MonoBehaviour
{
    private PlayerHealth m_Health; 

	// Use this for initialization
	void Start () 
    {
        m_Health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}

    public void OnMouseDown()
    {
        if (m_Health.getHealth() == m_Health.getMaxHealth())
        {
            // Just send a message. 

        }
        else // Destroy the object and add the health. 
        {
            DestroyObject(gameObject);

            // Add Random Health
            int rand = Random.Range(5, 20);

            if (!m_Health.isPlayerDead())
            {
                // Assure that we don't exceed the max health. 
                int healthToAdd = rand;

                if ((m_Health.getHealth() + healthToAdd) > m_Health.getMaxHealth())
                {
                    // Get the difference between the max health and health to add. 
                    healthToAdd = m_Health.getMaxHealth() - m_Health.getHealth();

                    // If negative, set to 0.
                    if (healthToAdd < 0) healthToAdd = 0;
                }


                m_Health.giveHealth(healthToAdd);
            }
        }
    }

	// Update is called once per frame
	void Update () 
    {
        
	}
}
