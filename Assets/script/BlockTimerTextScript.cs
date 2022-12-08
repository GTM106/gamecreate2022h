using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockTimerTextScript : MonoBehaviour
{
    public GameObject blockPrefab;
    [SerializeField] float destroyTime = 0;
    [SerializeField] float time = 0;
    public Text timerText;
    int seconds;
    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("timerText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TextTimer()
    {
        //秒数をテキストで表示
        timerText.enabled = true;
        destroyTime -= Time.deltaTime;
        seconds = (int)destroyTime;
        this.timerText.text = seconds.ToString();
        Debug.Log("Block：タイマー起動");
        if (seconds <= 0)
        {
            timerText.enabled = false;
            destroyTime = time;
        }
    }
}
