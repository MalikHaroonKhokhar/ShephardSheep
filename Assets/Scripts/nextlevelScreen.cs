using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevelScreen : MonoBehaviour
{
    // public GameObject sheep;
    // private levelswitcher switchh;
    public float levelcount;

    public float x = 1;

    private void Start()
    {
        levelcount = levelswitcher.counter;
    }

    private void Update() {
        levelcount = levelswitcher.counter;
    }

    
    public void nextlevel(){
        if(levelcount == 1){
            SceneManager.LoadScene("LEVEL2");
        }
        if(levelcount == 2){
            SceneManager.LoadScene("LEVEL3");
        }
        if(levelcount == 3){
            SceneManager.LoadScene("LEVEL4");
        }
        if(levelcount == 4){
            SceneManager.LoadScene("LEVEL5");
        }
        if(levelcount == 5){
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void menu(){
    SceneManager.LoadScene("MainMenu");

   }
}
