using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

   


public class playbutton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LEVEL1");
    }
    public void exitgame(){
    Application.Quit();
}
}
