using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This class controls for: escape functions and menu controls. 
/// Author: Alex Turner
/// </summary>

public class UnityManager : MonoBehaviour
{
    UnityFunctions unityFunctions = new UnityFunctions();


    public class UnityFunctions
    {
        
        public void UserExit()
        {
            Application.Quit();
        }

        void DetectInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UserExit();

            }
        }

        public void ManagerUpdate()
        {
            DetectInput();
        }

    }
        




    void Update()
    {
        unityFunctions.ManagerUpdate();
    }

    public void StartPrototype()
    {
        SceneManager.LoadScene("Mtest"); 
    }

    public void CloseMenu()
    {
        unityFunctions.UserExit();
    }
}
