using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WoolSwap : MonoBehaviour
{

    private Renderer BallRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        BallRenderer=GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)

    {
        if(other.CompareTag("sco")){
            Debug.Log("Hit!!");
            BallRenderer.material = other.GetComponent<Renderer>().material;
            other.gameObject.SetActive(false);
            
        }
        
    }
}
