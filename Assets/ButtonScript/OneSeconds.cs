using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneSeconds : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("1secStage");
        }
        else if(Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            SceneManager.LoadScene("10secStage");
        }
    }
}
