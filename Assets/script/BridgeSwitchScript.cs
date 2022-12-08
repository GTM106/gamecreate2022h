using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitchScript : MonoBehaviour
{
    public GameObject[] bridgeArray = new GameObject[3];
    //public GameObject bridge1, bridge2, bridge3;
    bool isAppear;
    GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        isAppear = false;
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (block == null && isAppear)
        {
            Hide();
            isAppear = false;
            Debug.Log("スイッチOFF");
        }
    }

    void Appear()
    {
        for (int i = 0; i < bridgeArray.Length; i++)
        {
            if (!bridgeArray[i].activeInHierarchy)
            {
                bridgeArray[i].gameObject.SetActive(true);
            }
        }
    }

    void Hide()
    {
        for (int i = 0; i < bridgeArray.Length; i++)
        {
            if (bridgeArray[i].activeInHierarchy)
            {
                bridgeArray[i].gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
            isAppear = true;
            Appear();
            block = other.gameObject;
            Debug.Log("スイッチON");
        }
    }
}
