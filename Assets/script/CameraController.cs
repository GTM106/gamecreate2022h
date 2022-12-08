using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject center;
    [SerializeField] private Transform self;
    [SerializeField] private Transform target;
    [SerializeField] Vector3 RotateAxis = Vector3.up;
    [SerializeField] float SpeedFactor = 0.1f;
    [SerializeField] float SpeedZoom = 0.1f;
    [SerializeField] float minDistance = 10;
    [SerializeField] float maxDistance = 30;


    private Vector3 gapVec;
    Vector3 dir;
    float length;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("R_Horizontal");
        float inputZ = Input.GetAxis("R_Vertical");

        //ズーム
        gapVec = center.transform.position - transform.position;
        dir = gapVec.normalized;
        length = gapVec.magnitude;

        if (Input.GetKey(KeyCode.I) || inputZ <= -0.1)
        {
            if (length > minDistance)
            {
                transform.position += dir * SpeedZoom * Time.deltaTime;
                Debug.Log("カメラ：前");
            }
        }
        else if (Input.GetKey(KeyCode.K) || 0.1 <= inputZ)
        {
            if (length < maxDistance)
            {
                transform.position -= dir * SpeedZoom * Time.deltaTime;
                Debug.Log("カメラ：後ろ");
            }
        }

        //回転
        self.LookAt(target);
        if (center == null) return;

        if (Input.GetKey(KeyCode.J) || inputX <= -0.1)
        {
            this.transform.RotateAround(
            center.transform.position,
            RotateAxis,
            360.0f / (1.0f / SpeedFactor) * Time.deltaTime
            );
            Debug.Log("カメラ：左");
        }
        else if (Input.GetKey(KeyCode.L) || 0.1 <= inputX)
        {
            this.transform.RotateAround(
            center.transform.position,
            RotateAxis,
            360.0f / (-1.0f / SpeedFactor) * Time.deltaTime
            );
            Debug.Log("カメラ：右");
        }

    }
}
