using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchingScript : MonoBehaviour
{
    public GameObject[]  cameraArray = new GameObject[2];
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        cameraArray[1]. gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraArray[0].gameObject.SetActive(false);
            cameraArray[1].gameObject.SetActive(true);
            //this.transform.position = target.position;
        }
    }
}
