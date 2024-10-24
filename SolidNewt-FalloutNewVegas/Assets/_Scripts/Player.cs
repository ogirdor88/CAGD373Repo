using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("in the door");

            if(Input.GetKey(KeyCode.E)) 
            {
                Debug.Log("Letsgo");
            }
        }
    }
}
