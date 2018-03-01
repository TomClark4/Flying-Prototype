using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	void OnTriggerEnter (Collider other)
    {

        SceneManager.LoadScene("Main");

    }
}
