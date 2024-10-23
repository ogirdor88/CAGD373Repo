using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject Loading;
    [SerializeField]
    private TMP_Text tip1;
    [SerializeField] 
    private TMP_Text tip2;
    [SerializeField] 
    private TMP_Text tip3;

    private bool loadingScreen;
    [SerializeField]
    private float loadDelay;

    // When the screen starts make sure the loading screen is off and the start screen is active
    private void Awake()
    {
        mainMenu.SetActive(true);
        Loading.SetActive(false);
        loadingScreen = false;
        loadDelay = 15;
    }

    // When the New Game button is pressed start the time and switch to the main game scene
    public void StartGame()
    {
        LoadingScreen();
    }

    // Close the game
    public void ExitGame()

    {
        Application.Quit();
    }

    // When loading screen happens turn off start screen, turn on loading screen.
    // start loading delay 
    // make the tips change
    private void LoadingScreen()
    {
        mainMenu.SetActive(false);
        Loading.SetActive(true);
        loadingScreen = true;
        //SceneManager.LoadScene("Doc's House");
    }

    private void Update()
    {
        Debug.Log(loadDelay);
        if (loadingScreen) 
        {
            StartCoroutine(ScreenDelay());
            if (loadDelay > 10)
            {
                tip1.gameObject.SetActive(true);
                tip2.gameObject.SetActive(false);
                tip3 .gameObject.SetActive(false);
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
                SceneManager.LoadScene("Doc's House");
                loadingScreen = false;
            }
        }
    }

    private IEnumerator ScreenDelay()
    {
        loadDelay -= 1 * Time.deltaTime;
        yield return new WaitForSeconds(1f);
    }
}
