using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSound : MonoBehaviour
{
    public SoundManager soundManager;
    public AudioSource thisSound;
    // Start is called before the first frame update
    void Start()
    {
        
        if(gameObject.name.Contains("Sound 1"))
        {
            thisSound.pitch = (1f + ((soundManager.SoundCounts[0] % 8) / 8f));
            //Debug.Log((1f + ((soundManager.SoundCounts[0] % 5) / 5f)));
            //ChangePitch(thisSound, soundManager.SoundCounts[0]);
        }
        else if(gameObject.name.Contains("Sound 2"))
        {
            thisSound.pitch = (1f + ((soundManager.SoundCounts[1] % 8) / 8f));
            //ChangePitch(thisSound, soundManager.SoundCounts[1]);
        }
        else if(gameObject.name.Contains("Sound 3"))
        {
            thisSound.pitch = (1f + ((soundManager.SoundCounts[2] % 8) / 8f));
            //ChangePitch(thisSound, soundManager.SoundCounts[2]);
        }
    }

    void ChangePitch(AudioSource thisSound, int numSounds)
    {
        thisSound.pitch = 1 + (numSounds % 5) / 5f;
        Debug.Log(thisSound.pitch);
    }
}
