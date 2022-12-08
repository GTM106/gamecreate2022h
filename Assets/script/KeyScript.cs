using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] float keyRotate = 0;
    public bool isCatch;
    public GameObject[] keyArray = new GameObject[2];
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        isCatch = false;
        Hide();
        OffImage();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCatch == true)
        {
            Catch();
        }
    }

    void Catch()
    {
        goal.gameObject.SetActive(true); 
        this.gameObject.SetActive(false);
        OnImage();
        Debug.Log("keyŽæ“¾");
    }

    void Hide()
    {
        this.transform.Rotate(new Vector3(0, keyRotate * Time.deltaTime, 0));
        goal.gameObject.SetActive(false);
        Debug.Log("key‰ñ“]");
    }

    void OnImage()
    {
        keyArray[0].gameObject.SetActive(true);
        keyArray[1].gameObject.SetActive(false);
    }

    void OffImage()
    {
        keyArray[0].gameObject.SetActive(false);
        keyArray[1].gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            isCatch = true;
    }
}
