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
        //通行人破壊と同じ条件ならばドゥクシを鳴らす
        if (GameManager.destroyEnemy != null && GameManager.posDistance > 1.0f)
            audioSource.PlayOneShot(cutSound);
        else
            audioSource.PlayOneShot(cutEmptySound);
    }
}
