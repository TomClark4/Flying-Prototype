using UnityEngine;
using System.Collections;

public class FlyingScript : MonoBehaviour {
	Rigidbody playerCharacter;

	CapsuleCollider playerColl;

	[SerializeField]
	float jumpHeight = 3f;
	[SerializeField]
	float movementSpeed = 4f;
	[SerializeField]
	float rotationSpeed = 120f;
	//int controlMode;
	[SerializeField]
	int jumpStamina = 10;
	[SerializeField]
	float flyHeight = 3;



	//	bool isGrounded = false;

	float distToGround;

	// Use this for initialization
	void Start()
	{
		//controlMode = 1;
		playerCharacter = GetComponent<Rigidbody>();

		playerColl = GetComponent<CapsuleCollider> ();

		distToGround = playerColl.bounds.extents.y;
	}

	void FixedUpdate()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && IsGrounded())
		{
			playerCharacter.velocity = new Vector3 (0, jumpHeight, 0);

			Physics.gravity = new Vector3(0, -9.81f, 0);
		}
		else if (Input.GetKeyDown (KeyCode.Space) && !IsGrounded() && jumpStamina > 0)
		{
			Physics.gravity = new Vector3(0, -5.0f, 0);
			playerCharacter.velocity = new Vector3 (0, flyHeight, 0);
			jumpStamina -= 1;
		}

		if (IsGrounded())
		{
			jumpStamina = 10;
		}



		float translation = Input.GetAxis ("Vertical") * movementSpeed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;

		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
	}

	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
	}

}
