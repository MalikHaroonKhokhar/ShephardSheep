using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerSheep : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    GameObject confettiGameOject;

    [Header("Sheep Control Values")]
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float touchSensitivity = 0.005f;

    [Header("Movement Area Limit")]
    [SerializeField]
    private float minX = -4.1f;
    [SerializeField]
    private float maxX = 4.3f;

    [Header("Wool Properties")]
    [SerializeField]
    private SkinnedMeshRenderer bodyWool;
    [SerializeField]
    private float woolIncrease = 5f;

    [Header("Animation Properties")]
    [SerializeField]
    private Animator anim;

    private Touch touch;
    private float currentWool;
    public AudioSource winaudio;
    public bool flag = false;
    


    private void Start()
    {
       
        
        winaudio=GetComponent<AudioSource>();
        if (rb == null)
            rb = this.GetComponent<Rigidbody>();
        if (bodyWool == null)
            bodyWool = transform.Find("Wool").GetComponent<SkinnedMeshRenderer>();
        if (anim == null)
            anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        // Move sheep forward with constant speed
        if(!flag){
            this.transform.position += moveSpeed * Time.deltaTime * transform.forward;
        }
        if(flag){
            this.transform.position += moveSpeed * Time.deltaTime * (-transform.forward);
        }

        anim.SetFloat("Jump", Mathf.Clamp(rb.velocity.y, 0, 1));

        if (Input.touchCount > 0)
        {
           

            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {

                MoveSheep();
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 5f * Time.deltaTime);
        }
    }

    // Move sheep on touch
    private void MoveSheep()
    {
        RotateSheep();
        this.transform.position = new Vector3(Mathf.Clamp(transform.position.x + touch.deltaPosition.x * touchSensitivity, minX, maxX),
                    transform.position.y,
                    transform.position.z);
        
    }

    private void RotateSheep()
    {
        
        if (touch.deltaPosition.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 15f, 0f), 5f * Time.deltaTime);
        }
        if (touch.deltaPosition.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -15f, 0f), 5f * Time.deltaTime);
        }
        
    }

    private void IncreaseWool()
    {
        // Key1
        currentWool = bodyWool.GetBlendShapeWeight(0);
        bodyWool.SetBlendShapeWeight(0, Mathf.Clamp(currentWool - woolIncrease, 0f, 100f));

        // Key2
        currentWool = bodyWool.GetBlendShapeWeight(1);
        bodyWool.SetBlendShapeWeight(1, Mathf.Clamp(currentWool + woolIncrease, 0f, 100f));
    }

    private void ChangeWoolColour(Material newColour)
    {
        bodyWool.material = newColour;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("sco"))
        {
            
            IncreaseWool();
           
            Destroy(other.gameObject);
        }
        /*if (other.transform.CompareTag("furrr"))
        {
            ChangeWoolColour(other.GetComponent<Renderer>().material);
            Destroy(other.gameObject);
        }*/
        if (other.gameObject.CompareTag("LevelEnd"))
        {
            confettiGameOject.SetActive(true);
            winaudio.Play();
            anim.SetBool("Dance", true);
            
            
        }
        if (other.gameObject.CompareTag("goIdle"))
        {
            anim.SetBool("Dance", false);
            this.enabled = false;
        }
        if (other.gameObject.CompareTag("barrier"))
        {
            flag = true;
        }
        Invoke("Reset", 1.0f);
        //if(other.gameObject.CompareTag("destroy")){
        //    SceneManager.LoadScene("Gameover");
        //}
    }

    void Reset()
    {
        flag = false;
    }
}