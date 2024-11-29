using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AudioSource menuMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        menuMusic = GetComponent<AudioSource>();
        menuMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playMusic()
    {
        menuMusic.Play();
    }

    public void stopMusic()
    {
        menuMusic.Stop();
    }
}
