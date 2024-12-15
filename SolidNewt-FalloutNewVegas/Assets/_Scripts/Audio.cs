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
    public AudioSource src;
    public AudioClip cont_locker1, cont_locker2, cont_locker3, cont_medpack1, cont_medpack2;
    //public AudioClip m_doorOpen;
    //public AudioClip m_doorClose;
    public float volume = 0.5f;

    //private bool falseOutside;


    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
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

    public void play_openLocker()
    {
        src.volume = 1f;
        src.pitch = 1f;
        src.clip = cont_locker1;
        src.Play();
    }

    public void play_closeLocker1()
    {
        src.volume = 1f;
        src.pitch = 1.8f;
        src.clip = cont_locker2;
        src.Play();
    }

    public void play_closeLocker2()
    {
        src.volume = 1f;
        src.pitch = 1.5f;
        src.clip = cont_locker3;
        src.Play();
    }

    public void play_openMedpack()
    {
        src.volume = .5f;
        src.pitch = 1.5f;
        src.clip = cont_medpack1;
        src.Play();
    }

    public void play_closeMedpack()
    {
        src.volume = 1f;
        src.pitch = 1f;
        src.clip = cont_medpack2;
        src.Play();
    }
}