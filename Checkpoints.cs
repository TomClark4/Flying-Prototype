using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {


	public bool activated = false;

	public static GameObject[] checkpointsList;

	// Use this for initialization
	void Start () {
	
		checkpointsList = GameObject.FindGameObjectsWithTag("Checkpoint");

	}
	
	private void ActivatePoints (){

		foreach (GameObject check in checkpointsList) {

			check.SetActive(false);
			//activated = false;

		}


		activated = true;

	}

	void OnTriggerEnter (Collider other){

		if (other.tag == "Player") {

			ActivatePoints ();

		}

	}

	public static Vector3 GetActiveCPPosition(){

		Vector3 result = new Vector3 (0, 3, 0);

		if (checkpointsList != null) {


			foreach (GameObject check in checkpointsList) {

				if (check.activeSelf) {

					result = check.transform.position;
					break;

				}

			}

		}

		return result;

		}
}
