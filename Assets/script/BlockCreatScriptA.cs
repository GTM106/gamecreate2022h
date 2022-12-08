using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreatScriptA : MonoBehaviour
{
    public bool isCreat;

    // Start is called before the first frame update
    void Start()
    {
        isCreat = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isCreat = false;
            Debug.Log("•Ç‚É‹ß‚¢");
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isCreat = true;
            Debug.Log("•Ç‚©‚ç—£‚ê‚½");
        }
    }
}
