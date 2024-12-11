using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//Jackson, Katherine
//12/03/24
//A script that handles audio.

public class Audio : MonoBehaviour
{
    public GameObject player;
    public Animator m_Animator;

    //Audio variables (Added by KJ)
    public AudioSource aud;
    //public AudioClip m_doorOpen;
    //public AudioClip m_doorClose;
    public float volume = 0.5f;

    //private bool falseOutside;


    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        //falseOutside = player.GetComponent<Player>().doorInteract;
    }

    // Update is called once per frame
    void Update()
    {
        /*falseOutside = player.GetComponent<Player>().doorInteract;

        if (falseOutside == true)
        {
            //falseOutside = false;
            audioSource.PlayOneShot(m_doorOpen, 1.0F);
        }*/
    }

    public void play_sound()
    {
        aud.Play();
    }
}