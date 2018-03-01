using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    Rigidbody playerCharacter;

    CapsuleCollider playerColl;

    [SerializeField]
    float jumpHeight = 0f;
    [SerializeField]
    float movementSpeed = 10f;
    [SerializeField]
    float rotationSpeed = 10f;

    int controlMode;

    [SerializeField]
    int jumpStamina = 10;
    [SerializeField]
    int maxJumpStamina = 3;
    [SerializeField]
    float flyHeight = 4f;

    float distToGround;

    [SerializeField]
    Text staminaCounter;

	[SerializeField]
	Text instructions;


    // Use this for initialization
    void Start()
    {
        SpecifyControlMode(3);
        playerCharacter = GetComponent<Rigidbody>();

        playerColl = GetComponent<CapsuleCollider>();

        distToGround = playerColl.bounds.extents.y;

        staminaCounter.text = "Stamina: " + jumpStamina;

    }

    // Update is called once per frame
    void Update()
    {
        QuitApplication();
        //SwitchMode ();
        SwitchPlayerControl();

        float translation = Input.GetAxis("Vertical") * movementSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        

        if (IsGrounded())
        {
            jumpStamina = maxJumpStamina;
            staminaCounter.text = "Stamina: " + jumpStamina;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }

    public void Recharge()
    {

        jumpStamina = maxJumpStamina;

    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Switchs the player control.
    /// </summary>

    void SwitchPlayerControl()
    {
        switch (controlMode)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                {
                    playerCharacter.velocity = new Vector3(0, jumpHeight, 0);

                    

                    Physics.gravity = new Vector3(0, -9.81f, 0);
                    Debug.Log("walking");
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                {
                    playerCharacter.velocity = new Vector3(0, jumpHeight, 0);

                    

                    Physics.gravity = new Vector3(0, -9.81f, 0);
                    Debug.Log("gliding");
                }
                else if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded())
                {
                    Physics.gravity = new Vector3(0, -2.0f, 0);

                    
                }
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                {
                    playerCharacter.velocity = new Vector3(0, jumpHeight, 0);

                    

                    Physics.gravity = new Vector3(0, -9.81f, 0);
                }
                else if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded() && jumpStamina > 0)
                {
                    Physics.gravity = new Vector3(0, -5.0f, 0);
                    playerCharacter.velocity = new Vector3(0, flyHeight, 0);
                    jumpStamina -= 1;

                    staminaCounter.text = "Stamina: " + jumpStamina;
                }
                break;
        }
    }

    void SpecifyControlMode(int controlSpecify)
    {
        controlMode = controlSpecify;
    }

    //void SwitchMode()
    //{
    //	if (Input.GetKeyDown(KeyCode.Alpha1))
    //	{
    //		SpecifyControlMode (1);
    //	}
    //
    //	if (Input.GetKeyDown(KeyCode.Alpha2))
    //	{
    //		SpecifyControlMode (2);
    //	}
    //
    //	if (Input.GetKeyDown(KeyCode.Alpha3))
    //	{
    //		SpecifyControlMode (3);
    //	}
//}

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Walk Trigger")
        {
            SpecifyControlMode(1);
            Debug.Log("I Walk!");

			instructions.text = "Walking Enabled - Press Space to jump";
        }

        if (other.gameObject.tag == "Glide Trigger")
        {
            SpecifyControlMode(2);
            Debug.Log("I Glide!");

			instructions.text = "Gliding Enabled - Hold Space in air to glide";
        }
        if (other.gameObject.tag == "Fly Trigger")
        {
            SpecifyControlMode(3);
            Debug.Log("I Fly!");

			instructions.text = "Flying Enabled - Press Space in air to flap wings";
        }
        if (other.gameObject.tag == "Fly Better Trigger")
        {

            maxJumpStamina = 6;
            flyHeight = 5;

        }
		if (other.gameObject.tag == "Death") {

			this.transform.position = Checkpoints.GetActiveCPPosition ();
			Debug.Log (Checkpoints.GetActiveCPPosition ());

		}

    }


	void QuitApplication()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();

		}
	}


}
