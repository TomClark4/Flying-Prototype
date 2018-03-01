using UnityEngine;
using System.Collections;

public class WindGusts : MonoBehaviour {

    [SerializeField]
    float windForce = 3f;


    void OnTriggerEnter (Collider other)
    {

        //prevents player flying down further than they should
        other.attachedRigidbody.velocity = Vector3.zero;

    }
	void OnTriggerStay (Collider other) {

        //pushes player up and recharges flap stamina
        other.attachedRigidbody.AddForce(Vector3.up * windForce);

        PlayerMovement scriptReference = other.GetComponent<PlayerMovement>();
        scriptReference.Recharge();



    }
}
