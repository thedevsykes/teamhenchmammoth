using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public string m_CameraName = "camera";
    public float m_PlayerSpeed = 1.0f;

    private Camera m_Camera;
    private float m_Velocity;
    private PlayerTorch m_Torch;

	// Use this for initialization
	void Start () 
    {
        m_Camera = GameObject.Find(m_CameraName).camera;
        m_Camera.transform.position = new Vector3(this.transform.position.x,
                                                  m_Camera.transform.position.y,
                                                  m_Camera.transform.position.z);

        m_Velocity = m_PlayerSpeed;
        m_Torch = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTorch>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
	    // Update the position of the player. 
        handleInput();
	}

    // Consider making strong use of the Input Axes manager at some point. 
    // For the sake of the Alpha, leave as. 
    private void handleInput()
    {
        float value = Input.GetAxis("Horizontal");

        // Move Right
        if (value > 0)
        {
            this.transform.Translate(new Vector3(0, 0, Input.GetAxis("Horizontal")) * Time.deltaTime * m_Velocity);
        }
        if (value < 0)
        {
            this.transform.Translate(new Vector3(0, 0, Input.GetAxis("Horizontal")) * Time.deltaTime * m_Velocity);
        }

        // Get Direction of the player torch and move player accordingly.
        Vector3 direction = m_Torch.getLightDirection();

        transform.forward = new Vector3(direction.x, 0, 0);

        updateCamera(); 
    }

    // Updates the camera so it remains locked on the player.
    private void updateCamera()
    {
        m_Camera.transform.position = new Vector3(this.transform.position.x,
                                                  this.transform.position.y + 1.0f,
                                                  m_Camera.transform.position.z);
    }
}
