using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

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

    private bool outside;
    private float loadDelay;

    // Start is called before the first frame update
    void Start()
    {
        outside = false;
        loadDelay = 15;
    }

    // Update is called once per frame
    void Update()
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("in the door");

            if(Input.GetKey(KeyCode.E)) 
            {
                Debug.Log("Letsgo");
                outside = true;
            }
        }
    }

    private IEnumerator ScreenDelay()
    {
        loadDelay -= 1 * Time.deltaTime;
        yield return new WaitForSeconds(1f);
    }
}
