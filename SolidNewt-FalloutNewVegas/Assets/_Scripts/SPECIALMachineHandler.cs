using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPECIALMachineHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject player, uiContainer, crosshair, itemDisplay;
    [SerializeField]
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera.GetComponent<Camera>().enabled = false;
        camera.GetComponent<AudioListener>().enabled = false;
        player.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.inSpecial == true)
        {
            player.SetActive(false);
            camera.SetActive(true);
            crosshair.SetActive(false);
            itemDisplay.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))//Check if the player has pressed the Interaction button
            {
                Player.inSpecial = false;
            }
        }
        else
        {
            player.SetActive(true);
            crosshair.SetActive(true);
            itemDisplay.SetActive(true);
            camera.SetActive(false);
        }
    }
}
