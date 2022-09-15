using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelswitcher : MonoBehaviour
{
    public float count;
    public static float counter;
    public static levelswitcher instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake(){
        instance = this;
       // DontDestroyOnLoad(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("finish1"))
        {
            count = 1;
            counter = 1;
            Debug.Log("Count updated to 1");
        }
        if (other.CompareTag("finish2"))
        {
            count = 2;
            counter = 2;
            Debug.Log("Count updated to 2");
        }
        if(other.CompareTag("finish3")){
            count = 3;
            counter= 3;
            Debug.Log("Count updated to 3");
        }
        if(other.CompareTag("finish4")){
            count = 4;
            counter= 4;
            Debug.Log("Count updated to 4");
        }
        if(other.CompareTag("finish5")){
            count = 5;
            counter= 5;
            Debug.Log("Count updated to 5");
        }
    }
}
