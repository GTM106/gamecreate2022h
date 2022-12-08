using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SevenSeconds : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            SceneManager.LoadScene("10secStage");
        }
    }
}
