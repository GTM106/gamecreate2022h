using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���j�p
public class ClockSwitchScript : MonoBehaviour
{
    public GameObject bigHand;

    // Start is called before the first frame update
    void Start()
    {
        bigHand = GameObject.Find("BigHand");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            bigHand.GetComponent<RotateScript>().isStop = true;
            Debug.Log("���j��~��");
        }
    }
}
