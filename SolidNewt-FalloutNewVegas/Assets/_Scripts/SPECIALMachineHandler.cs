using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SPECIALMachineHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject player, uiContainer, crosshair, itemDisplay, b1,b2,b3,b4,b5,b6,b7,b8,b9,b10;
    [SerializeField]
    private GameObject cameraS;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(true);
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
        b4.SetActive(false);
        b5.SetActive(false);
        b6.SetActive(false);
        b7.SetActive(false);
        b8.SetActive(false);
        b9.SetActive(false);
        b10.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.inSpecial == true)
        {
            player.SetActive (false);
            cameraS.SetActive(true);
            uiContainer.SetActive(true);
            Debug.Log("heheXD");
        }
        else
        {
            player.SetActive(true);
            cameraS.SetActive(false);
            uiContainer.SetActive(false);
        }
    }
}
