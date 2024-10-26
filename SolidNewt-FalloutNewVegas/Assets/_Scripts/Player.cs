using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    //Loading screen variables
    [SerializeField]
    private GameObject Loading;
    [SerializeField]
    private TMP_Text tip1;
    [SerializeField]
    private TMP_Text tip2;
    [SerializeField]
    private TMP_Text tip3;

    private bool outside;
    private float loadDelay;

    // Interaction Variable 
    [SerializeField]
    private TMP_Text crosshair;
    [SerializeField] 
    private TMP_Text interactDisplay;
    [SerializeField]
    private float raycastDistance;




    // Start is called before the first frame update
    void Start()
    {
        outside = false;
        loadDelay = 15;
    }

    // Update is called once per frame
    void Update()
    {
        LeaveHouse();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // This creates a 'ray' at the centre of the users Screen
        RaycastHit hit; //This creates a Hit which is used to callback the object that was hit by the Raycast

        if (Physics.Raycast(ray, out hit, raycastDistance)) //Actively creates a ray using the predeterminded distance
        {
            // If the ray hits an Item change the crosshair and display that you can take the Item
            if (hit.collider.CompareTag("Item"))
            {
                crosshair.text = "[><]";
                interactDisplay.text = "E) Take\n" + hit.collider.gameObject.name;

                if (Input.GetKeyDown(KeyCode.E))//Check if the player has pressed the Interaction button
                {
                    Debug.Log("take the item");
                    Destroy(hit.collider.gameObject);
                }
            }


            if (hit.collider.CompareTag("Door"))
            {
                crosshair.text = "[><]";
                interactDisplay.text = "E) Open\n" + hit.collider.gameObject.name;
                if (Input.GetKeyDown(KeyCode.E))//Check if the player has pressed the Interaction button
                {
                    outside = true;
                }

            }

            if (hit.collider.CompareTag("Storage"))
            {
                crosshair.text = "[><]";
                interactDisplay.text = "E) Open\n" + hit.collider.gameObject.name;

            }
        }
        //if the ray is not hitting any of the taged objects reset the crosshair and the interaction text
        else
        {
            crosshair.text = "><";
            interactDisplay.text = "";
        }
    }

    private IEnumerator ScreenDelay()
    {
        loadDelay -= 1 * Time.deltaTime;
        yield return new WaitForSeconds(1f);
    }

    private void LeaveHouse()
    {
        if (outside)
        {
            Loading.SetActive(true);
            gameObject.GetComponent<FirstPersonController>().enabled = false;
            StartCoroutine(ScreenDelay());
            if (loadDelay > 10)
            {
                tip1.gameObject.SetActive(true);
                tip2.gameObject.SetActive(false);
                tip3.gameObject.SetActive(false);
            }
            if (loadDelay > 5 && loadDelay < 10)
            {
                tip1.gameObject.SetActive(false);
                tip2.gameObject.SetActive(true);
                tip3.gameObject.SetActive(false);
            }
            if (loadDelay > 0 && loadDelay < 5)
            {
                tip1.gameObject.SetActive(false);
                tip2.gameObject.SetActive(false);
                tip3.gameObject.SetActive(true);
            }
            if (loadDelay <= 0)
            {
                SceneManager.LoadScene("Goodsprings");
                outside = false;
            }
        }
    }
}
