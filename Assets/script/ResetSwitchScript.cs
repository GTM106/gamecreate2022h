using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSwitchScript : MonoBehaviour
{
    public GameObject bigHand;
    public GameObject littleHand;

    // Start is called before the first frame update
    void Start()
    {
        bigHand = GameObject.Find("BigHand");
        littleHand = GameObject.Find("LittleHand");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            bigHand.GetComponent<RotateScript>().isStop = false;
            littleHand.GetComponent<RotateScript2>().isStop = false;
            Debug.Log("óºêjçƒãNìÆ");
        }
    }
}
