using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    //�����u���b�N������
    public GameObject blockPrefab;
    public int MaxBlock;

    //�u���b�N�����ʒu
    public GameObject targetA, targetB, targetX, targetY;

    //�_���[�W
    public GameObject[] lifeArray = new GameObject[3];
    float lifeCount = 3;
    float coolTime;
    bool isCoolTime;
    float endTime;
    bool isGameend;

    //ArrowCube�͈�
    public bool isArea;

    //�A�j���[�V����
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        lifeCount = 3;
        coolTime = 0;
        isCoolTime = false;
        endTime = 0;
        isGameend = false;

        targetA = GameObject.Find("A");
        targetB = GameObject.Find("B");
    }

    // Update is called once per frame
    void Update()
    {
        //�u���b�N����
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.C))
        {
            if (targetA.GetComponent<BlockCreatScriptA>().isCreat == true && blockPrefab.GetComponent<BlockScript>().isCoolTime == false)
            {
                CreatBlockA();
                Debug.Log("A����");
            }
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.F))
        {
            if (targetB.GetComponent<BlockCreatScriptB>().isCreat == true && blockPrefab.GetComponent<BlockScript>().isCoolTime == false)
            {
                CreatBlockB();
                Debug.Log("B����");
            }       
        }

        //�A�j���[�V����
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        if(inputX >= 0.1 || inputX <= -0.1 || inputZ >= 0.1 || inputZ <= -0.1)
            animator.SetBool("toWalk", true);
        else if (inputX < 0.1 && inputX > -0.1 || inputZ < 0.1 && inputZ > -0.1)
            animator.SetBool("toWalk", false);

        //�N�[���^�C��
        if(isCoolTime == true)
        {
            CoolTime();
        }
        if(isGameend == true)
        {
            GameOver();
        }
    }

    //�N�[���^�C������
    void CoolTime()
    {
        coolTime += Time.deltaTime;
        Debug.Log("�_���[�W�N�[���^�C��");
        if(coolTime > 5)
        {
            isCoolTime = false;
            coolTime = 0;
            Debug.Log("�N�[���^�C���I��");
        }
    }
    void GameOver()
    {
        endTime += Time.deltaTime;
        if(endTime > 3)
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("GameOver");
        }
    }

    //�_���[�W����
    void Damage()
    {
        if (isCoolTime == true)
        {
            return;
        }
        lifeCount--;
        if (lifeCount == 3)
        {
            lifeArray[2].gameObject.SetActive(true);
            lifeArray[1].gameObject.SetActive(true);
            lifeArray[0].gameObject.SetActive(true);
            Debug.Log("HP�c��3");
        }
        if (lifeCount == 2)
        {
            lifeArray[2].gameObject.SetActive(false);
            lifeArray[1].gameObject.SetActive(true);
            lifeArray[0].gameObject.SetActive(true);
            Debug.Log("HP�c��2");
        }
        if (lifeCount == 1)
        {
            lifeArray[2].gameObject.SetActive(false);
            lifeArray[1].gameObject.SetActive(false);
            lifeArray[0].gameObject.SetActive(true);
            Debug.Log("HP�c��1");
        }
        if (lifeCount == 0)
        {
            lifeArray[2].gameObject.SetActive(false);
            lifeArray[1].gameObject.SetActive(false);
            lifeArray[0].gameObject.SetActive(false);
            isGameend = true;
        }
        isCoolTime = true; 
    }

    //�u���b�N����
    void CreatBlockA() //�O�΂߉�
    {
        int BlockCount = GameObject.FindGameObjectsWithTag("Block").Length;
        if (BlockCount < MaxBlock)
        {
            if (blockPrefab)
            {
                Instantiate(blockPrefab, targetA.transform.position, Quaternion.identity);
            }
        }
    }
    void CreatBlockB() //�O
    {
        int BlockCount = GameObject.FindGameObjectsWithTag("Block").Length;
        if (BlockCount < MaxBlock)
        {
            if (blockPrefab)
            {
                Instantiate(blockPrefab, targetB.transform.position, Quaternion.identity);
            }
        }
    }
    //void CreatBlockX()
    //{
    //    int BlockCount = GameObject.FindGameObjectsWithTag("Block").Length;
    //    if (BlockCount < MaxBlock)
    //    {
    //        if (blockPrefab)
    //        {
    //            Instantiate(blockPrefab, targetX.transform.position, Quaternion.identity);
    //        }
    //    }
    //}
    //void CreatBlockY()
    //{
    //    int BlockCount = GameObject.FindGameObjectsWithTag("Block").Length;
    //    if (BlockCount < MaxBlock)
    //    {
    //        if (blockPrefab)
    //        {
    //            Instantiate(blockPrefab, targetY.transform.position, Quaternion.identity);
    //        }
    //    }
    //}

    public void ArrayDamage()
    {
        if (lifeCount > 0)
        {
            Damage();
            Debug.Log("Enemy�ڐG");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //�G�ڐG����
        if (collision.gameObject.tag == "Enemy")
        {
            if(lifeCount > 0)
            {
                Damage();
                Debug.Log("Enemy�ڐG");
                Destroy(collision.gameObject);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "DangerArea")
        {
            isArea = true;
            Debug.Log("�U���͈͓�");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "DangerArea")
        {
            isArea = false;
            Debug.Log("�U���͈͊O");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bottom")
        {
            SceneManager.LoadScene("GameOver");
            Debug.Log("GameOver(fall)");
        }
        if (other.gameObject.tag == "GameOver")
        {
            SceneManager.LoadScene("GameOver2");
            Debug.Log("GameOver(fall)");
        }
        if (other.gameObject.tag == "Goal")
        {
            Goal();
        }

        //��ڐG����
        //if (other.gameObject.tag == "arrow")
        //{
        //    if (lifeCount > 0)
        //    {
        //        Damage();
        //        Debug.Log("Enemy�ڐG");
        //        Destroy(other.gameObject);
        //    }
        //}
    }

    void Goal()
    {
        SceneManager.LoadScene("GameClear");
        Debug.Log("GameClear");
    }
}
