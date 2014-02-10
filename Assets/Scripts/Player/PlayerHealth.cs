using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
    public int m_MaxHealth = 100; 
    private int m_Health = 0;

	// Use this for initialization
	void Start () 
    {
	    m_Health = 80;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public int getHealth()
    {
        return m_Health; 
    }

    public int getMaxHealth()
    {
        return m_MaxHealth; 
    }

    public void takeHealth(int amount)
    {
        if (!isPlayerDead())
        {
            m_Health -= amount; 
        }
    }

    public void giveHealth(int amount)
    {
        if (!isPlayerDead())
        {
            m_Health += amount;
        }
    }

    public bool isPlayerDead()
    {
        if (m_Health <= 0) return true;
        else return false; 
    }
}
