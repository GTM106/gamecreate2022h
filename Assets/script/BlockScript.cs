using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] float destroyTime = 0;
    [SerializeField] float coolTime = 0;
    public bool isTouch;
    public bool isCoolTime;

    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        isCoolTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouch)
        {
            GameObject.Find("timerText").GetComponent<BlockTimerTextScript>().TextTimer();
            destroyTime -= Time.deltaTime;
            if (destroyTime < 0)
            {
                Destroy(gameObject);
                isCoolTime = true;
            }
        }
        if(isCoolTime == true)
        {
            CoolTime();
        }
    }

    void CoolTime()
    {
        coolTime -= Time.deltaTime;
        if(coolTime < 0)
        {
            isCoolTime = false;
            Debug.Log("ブロック：クールタイム終了");
        }

    }

    //void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        isTouch = true;
    //        Debug.Log("ブロック：プレイヤー接触");
    //    }
    //    else if (collision.gameObject.tag == "arrow")
    //    {
    //        Destroy(gameObject, 1.0f);
    //        Destroy(collision.gameObject);
    //        Debug.Log("Block : Arrow接触");
    //    }
    //}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouch = true;
            Debug.Log("ブロック：プレイヤー接触");
        }
        else if (other.gameObject.tag == "arrow")
        {
            isTouch = true;
            Destroy(other.gameObject);
            Debug.Log("Block : Arrow接触");
        }
    }
}
