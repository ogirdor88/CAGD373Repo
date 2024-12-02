using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorHandler : MonoBehaviour
{
    [SerializeField]
    private Image cursor;

    // Start is called before the first frame update
    void Start()
    {
        cursor.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.inSpecial == true) 
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            cursor.GetComponent<Image>().enabled = true;
            cursor.transform.position = Input.mousePosition;
        }
        else
            cursor.GetComponent<Image>().enabled = false;
    }
}
