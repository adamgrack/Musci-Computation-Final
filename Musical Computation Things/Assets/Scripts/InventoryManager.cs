using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] soundTypes;
    public GameObject currentSound;
    public GameObject UI;
    public Image[] invSprites;
    public Sprite[] selectedSprites;
    public Sprite[] emptySprites;
    // Start is called before the first frame update
    void Start()
    {
        currentSound = soundTypes[0];
        invSprites[0].sprite = selectedSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            currentSound = soundTypes[0];
            invSprites[0].sprite = selectedSprites[0];
            invSprites[1].sprite = emptySprites[1];
            invSprites[2].sprite = emptySprites[2];
        }
        else if(Input.GetKeyDown("2"))
        {
            currentSound = soundTypes[1];
            invSprites[0].sprite = emptySprites[0];
            invSprites[1].sprite = selectedSprites[1];
            invSprites[2].sprite = emptySprites[2];
        }
        else if(Input.GetKeyDown("3"))
        {
            currentSound = soundTypes[2];
            invSprites[0].sprite = emptySprites[0];
            invSprites[1].sprite = emptySprites[1];
            invSprites[2].sprite = selectedSprites[2];
        }
    }
}
