using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//íZêj
public class RotateScript2 : MonoBehaviour
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
        if (isStop == false)
        {
            gameObject.transform.Rotate(new Vector3(rotateX * Time.deltaTime, 0, 0));
        }
    }
}
