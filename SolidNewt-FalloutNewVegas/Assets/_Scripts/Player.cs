using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

//Updated by KJ 11/03/24

public class Player : MonoBehaviour
{
    //Animation variables (Added by KJ)
    public Animator m_Animator;
    public bool doorInteract;

    //Audio variables (Added by KJ)
    public AudioSource audioSource;
    //public AudioSource audioSource2;
    public AudioClip m_doorOpen;
    public AudioClip m_doorClose;
    public float volume = 0.5f;

    //Loading screen variables
    [SerializeField]
    private GameObject Loading;
    [SerializeField]
    private TMP_Text tip1;
    [SerializeField]
    private TMP_Text tip2;
    [SerializeField]
    private TMP_Text tip3;

    public bool outside; //Made public so audio script can access the outside bool (updated by KJ)
    private float loadDelay;

    // Interaction Variable 
    [SerializeField]
    private TMP_Text crosshair;
    [SerializeField] 
    private TMP_Text interactDisplay;
    [SerializeField]
    private float raycastDistance;


    // Storage Variables
    [SerializeField]
    private GameObject StorageDisplay;
    [SerializeField]
    private TMP_Text containerName;
    [SerializeField]
    private TMP_Text itemList;
    [SerializeField]
    private TMP_Text boxContent;

    private bool inStorage;
    public static bool inSpecial;
    public bool testing;

    [SerializeField]
    private GameObject inventManager;
    InventoryManager inventory;
    private bool InventUpdate;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Goodsprings")
        {
            audioSource.PlayOneShot(m_doorClose, 1.0F);
        }

        doorInteract = false;
        outside = false;
        inStorage = false;
        loadDelay = 15;
        StorageDisplay.gameObject.SetActive(false);
        Loading.gameObject.SetActive(false);
        inventory = inventManager.GetComponent<InventoryManager>();
        itemList.text = "";
        InventUpdate = false;
        inSpecial = false;
    }

    // Update is called once per frame
    void Update()
    {
        testing = inSpecial;
        LeaveHouse();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // This creates a 'ray' at the centre of the users Screen
        RaycastHit hit; //This creates a Hit which is used to callback the object that was hit by the Raycast

        if (!inStorage || !inSpecial)
        {
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
                        inventory.AddToInvent(hit.collider.gameObject.name.ToString());
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
                        audioSource.PlayOneShot(m_doorOpen, 1.0F);
                    }

                }

                /*if (hit.collider.CompareTag("Caps"))
                {
                    crosshair.text = "[><]";
                    interactDisplay.text = "E) Take\n" + hit.collider.gameObject.name;
                    if (Input.GetKeyDown(KeyCode.E))//Check if the player has pressed the Interaction button
                    {
                        ;
                    }

                }*/

                if (hit.collider.CompareTag("Storage"))
                {
                    crosshair.text = "[><]";
                    interactDisplay.text = "E) Open\n" + hit.collider.gameObject.name;

                    if (Input.GetKeyDown(KeyCode.E))//Check if the player has pressed the Interaction button
                    {
                        ToggleStorage();
                    }

                    if (inStorage)
                    {
                        // Disable walking, running and camera moving and spawn in cursor
                        this.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
                        this.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 0;
                        this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                        this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                        this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;

                        // Disable crosshair UI
                        crosshair.gameObject.SetActive(false);
                        interactDisplay.gameObject.SetActive(false);

                        // Enable StorageUI
                        StorageDisplay.SetActive(true);
                        StartCoroutine(InventUpdates());

                        // Update the container Name
                        containerName.text = hit.collider.gameObject.name;
                    }
                    else
                    {
                        // Disables Storage UI
                        StorageDisplay.SetActive(false);

                        // Enable walking, running and camera moving and despawn cursor
                        this.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
                        this.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 10;
                        this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
                        this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
                        this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;

                        // Enable Crosshair
                        crosshair.gameObject.SetActive(true);
                        interactDisplay.gameObject.SetActive(true);

                        InventUpdate = false;
                        itemList.text = "";

                    }

                }

                // If the ray hits The Special Machine
                if (hit.collider.CompareTag("SPECIAL"))
                {
                    crosshair.text = "[><]";
                    interactDisplay.text = "E) Activate\n" + hit.collider.gameObject.name;

                    if (Input.GetKeyDown(KeyCode.E))//Check if the player has pressed the Interaction button
                    {
                        inSpecial = !inSpecial;
                        Debug.Log("SpecialMachine");
                        if(inSpecial) 
                        {
                            // Disable crosshair UI
                            crosshair.gameObject.SetActive(false);
                            interactDisplay.gameObject.SetActive(false);

                            // Disable walking, running and camera moving and spawn in cursor
                            this.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
                            this.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 0;
                            this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                            this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                            this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;
                        }
                        else
                        {
                            // Disables Storage UI
                            StorageDisplay.SetActive(false);

                            // Enable walking, running and camera moving and despawn cursor
                            this.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
                            this.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 10;
                            this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
                            this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
                            this.gameObject.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;

                            // Enable Crosshair
                            crosshair.gameObject.SetActive(true);
                            interactDisplay.gameObject.SetActive(true);

                        }
                    }
                }
            }
            //if the ray is not hitting any of the taged objects reset the crosshair and the interaction text
            else
            {
                crosshair.text = "><";
                interactDisplay.text = "";
            }
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
            m_Animator.SetBool("DoorOpen", true);
            StartCoroutine(WaitToLoad());
        }
    }

    private void ToggleStorage()
    {
        inStorage = !inStorage;
    }

    public void ModDisplayInvent()
    {
        List<string> invent = inventory.GetInventory();

        for (int i = 0; i < invent.Count; i++)
        {
            Debug.Log(invent[i]);
        }
    }

    private IEnumerator InventUpdates()
    {
        if (!InventUpdate)
        {
            List<string> invent = inventory.GetInventory();
            Debug.Log(invent.Count);

            for (int i = 0; i < invent.Count; i++)
            {
                itemList.text = itemList.text + invent[i] + "\n";
            }
            InventUpdate = true;
        }
        yield return new WaitForSeconds(1f);

    }

    private IEnumerator WaitToLoad()
    {
        //audioSource.PlayOneShot(m_doorOpen, 1.0F);
        yield return new WaitForSeconds(2f);
        crosshair.gameObject.SetActive(false);
        interactDisplay.gameObject.SetActive(false);
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
            //audioSource.PlayOneShot(m_doorClose, 1.0F);
            SceneManager.LoadScene("Goodsprings");
            outside = false;
        }
    }
}
