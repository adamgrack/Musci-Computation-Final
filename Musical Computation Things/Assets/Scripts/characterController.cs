using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterController : MonoBehaviour
{
    public float speed = 10f;
    Ray ray;
    RaycastHit rayHit;
    public SoundManager soundManager;
    public float strumSpeed = 0.03f;
    public Text UItext;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        UItext.text = "Strum Speed = " + ((int)(strumSpeed*100)+1);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        if(Input.GetKeyDown("p"))
        {
            StartCoroutine(PlayBoard());
        }
        else if(Input.GetKeyDown("i"))
        {
            if(strumSpeed < 0.1f)
                strumSpeed += 0.01f;
            else
                strumSpeed = 0.01f;  

            UItext.text = "Strum Speed = " + ((int)(strumSpeed*100)+1);
            Debug.Log(strumSpeed);
        }

        if(Input.GetMouseButtonDown(0))
        {
            PlaceSound();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            DestroySound();
        }

        if(Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void PlaceSound()
    {
        GameObject sound = GetComponent<InventoryManager>().currentSound;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out rayHit))
        {
            GameObject newSound = Instantiate(sound, new Vector3(rayHit.point.x, rayHit.point.y + sound.transform.lossyScale.y/2, rayHit.point.z), Quaternion.identity);
            if(sound.name == "Sound 1")
            {
                soundManager.SoundCounts[0] ++;
                //Debug.Log(soundManager.SoundCounts[0]);
            }
            else if(sound.name == "Sound 2")
            {
                soundManager.SoundCounts[1] ++;
                //Debug.Log(soundManager.SoundCounts[1]);
            }
            else if(sound.name == "Sound 3")
            {
                soundManager.SoundCounts[2] ++;
                //Debug.Log(soundManager.SoundCounts[2]);
            }
        }
    }

    void DestroySound()
    {
        GameObject sound = GetComponent<InventoryManager>().currentSound;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out rayHit) && rayHit.transform.gameObject.tag == "sound")
        {
            if(rayHit.transform.gameObject.name.Contains("Sound 1"))
            {
                soundManager.SoundCounts[0] --;
            }
            else if(rayHit.transform.gameObject.name.Contains("Sound 2"))
            {
                soundManager.SoundCounts[1] --;
            }
            else if(rayHit.transform.gameObject.name.Contains("Sound 3"))
            {
                soundManager.SoundCounts[2] --;
            }
            Destroy(rayHit.transform.gameObject);
        }
    }

    public IEnumerator PlayBoard()
    {
        GameObject strummer = GameObject.Find("Strummer");
        Vector3 startPosition = strummer.transform.position;
        Vector3 endPosition = GameObject.Find("EndOfPlayer").transform.position;
        while(strummer.transform.position.x > endPosition.x)
        {
            strummer.transform.Translate(-strumSpeed, 0, 0);
            if(Input.GetKeyDown("o"))
            {
                strummer.transform.position = startPosition;
                yield break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        strummer.transform.position = startPosition;
        yield return null;
    }
}
