using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCubeScript : MonoBehaviour
{
    [SerializeField] private Transform self;
    [SerializeField] private Transform target;
    [SerializeField] private Transform arrow;
    public float ballSpeed = 5.0f;

    float attack = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BallShot");
    }

    // Update is called once per frame
    void Update()
    {
        if (target.GetComponent<PlayerController2>().isArea == true)
        {
            self.LookAt(target);
        }
    }

    IEnumerator BallShot()
    {
        while (attack == 1)
        {
            var shot = Instantiate(arrow, transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * ballSpeed;
            yield return new WaitForSeconds(5.0f);
        }
    }
}
