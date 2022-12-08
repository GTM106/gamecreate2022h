using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] float rotateX = 0;
    public bool isStop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isStop == false)
        {
            gameObject.transform.Rotate(new Vector3(rotateX * Time.deltaTime, 0, 0));
            //GetComponent<AudioSource>().Play();
        }
    }
}
