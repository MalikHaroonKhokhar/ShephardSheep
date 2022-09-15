using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreIsTrigger : MonoBehaviour
{
    public GameObject upscale;
    public Vector3 scaleChange;
    public Vector3 impulse = new Vector3(10.0f, 0.0f, 15.0f);
    public float upscalelimit = 120;
    public GameObject skin1;
    public GameObject firstwool;
    public GameObject skin2;

    Animator anim;


    void Start()
    {
        scaleChange = new Vector3(3f, 3f, 3f);
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("sco"))
        {
            Controller.score += 1;
            Destroy(collision.gameObject);
            //Debug.Log("Wool.");
        }
        if (collision.gameObject.CompareTag("Cash"))
        {
            Controller.cash += 1;
            Destroy(collision.gameObject);
            //Debug.Log("Cash.");
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            Controller.key += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("obs"))
        {
            Controller.score -= 1;
            Controller.health -= 10;
            upscale.transform.localScale -= scaleChange;

            //Debug.Log("Downscale");

        }

        if (collision.gameObject.CompareTag("LevelEnd"))
        {
            anim.SetBool("Dance", true);
        }

        if (collision.gameObject.CompareTag("goIdle"))
        {
            anim.SetBool("Dance", false);
            SceneManager.LoadScene("LevelWon");
        }

        if (collision.gameObject.CompareTag("destroy"))
        {
            SceneManager.LoadScene("Gameover");

        }
    }
}
