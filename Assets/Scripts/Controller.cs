using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Controller : MonoBehaviour
{
    [Header("Wool Score Text")]
    public static int score;
    public GameObject ScoreText;
    public TextMeshProUGUI gm1;

    [Header("Health Text")]
    public static int health;
    public GameObject healthtext;
    public TextMeshProUGUI gm2;

    [Header("Cash Score Text")]
    public static int cash;
    public GameObject CashText;
    public TextMeshProUGUI gm3;

    [Header("Key Score Text")]
    public static int key;
    public GameObject KeyText;
    public TextMeshProUGUI gm4;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        cash = 0;
        key = 0;
        health=100;
    
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Score: " + score);
        gm1.text = "x " + score;

        //Debug.Log("Cash: " + cash);
        gm3.text = "x " + cash;

        gm4.text = "x " + key;

        gm2.text= "Health: " + health;
       
        if(score<=-1){
            score=0;
        }
        if(health<=0){
            SceneManager.LoadScene("Gameover");
        }
       
       
    }
    
}
