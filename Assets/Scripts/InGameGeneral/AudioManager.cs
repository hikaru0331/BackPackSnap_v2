using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip cutEmptySound;
    public AudioClip cutSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCutSound()
    {
        if (GameManager.destroyEnemy != null)
            audioSource.PlayOneShot(cutSound);
        else
            audioSource.PlayOneShot(cutEmptySound);
    }
}
