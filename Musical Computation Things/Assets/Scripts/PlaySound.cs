using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.name == "Strummer")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
