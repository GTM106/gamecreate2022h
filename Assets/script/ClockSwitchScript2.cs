using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//íZêjóp
public class ClockSwitchScript2 : MonoBehaviour
{
    public GameObject littleHand;

    // Start is called before the first frame update
    void Start()
    {
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
            littleHand.GetComponent<RotateScript2>().isStop = true;
            Debug.Log("íZêjí‚é~íÜ");
        }
    }
}
