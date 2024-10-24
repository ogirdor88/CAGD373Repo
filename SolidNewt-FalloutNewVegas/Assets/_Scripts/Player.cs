using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject Loading;
    [SerializeField]
    private TMP_Text tip1;
    [SerializeField]
    private TMP_Text tip2;
    [SerializeField]
    private TMP_Text tip3;

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
