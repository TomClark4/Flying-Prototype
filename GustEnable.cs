using UnityEngine;
using System.Collections;

public class GustEnable : MonoBehaviour {

	GameObject windGusts;

	// Use this for initialization
	void Start () {

		windGusts = GameObject.FindGameObjectWithTag ("Wind Gusts");
		windGusts.SetActive (false);

	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
	
		//if (other == GameObject.FindGameObjectWithTag ("Player")) {

			windGusts.SetActive (true);

		//}

	}
}
