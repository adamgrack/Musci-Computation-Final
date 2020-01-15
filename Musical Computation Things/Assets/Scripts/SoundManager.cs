using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public int[] SoundCounts = new int[3];
    // Start is called before the first frame update
    void Start()
    {
        SoundCounts[0] = 0;
        SoundCounts[1] = 0;
        SoundCounts[2] = 0;
    }
}
