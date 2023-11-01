using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private bool doorIsOpen = false;
    private float doorTimer = 0.0f;

    public float doorOpenTime = 3.0f;
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Can be moved to separate function later
        if (!doorIsOpen)
        {
            return;
        }
        doorTimer += Time.deltaTime;

        if (doorTimer <= doorOpenTime)
        {
            return;
        }
        Door(doorShutSound, false, "doorShut");
        doorTimer = 0.0f;
    }

    void DoorCheck()
    {
        if (!doorIsOpen)
        {
            Door(doorOpenSound, true, "doorOpen");
        }
    }

    private void ResetTimer()
    {
        doorTimer = 0.0f;
    }

    void Door(AudioClip aClip, bool openCheck, string animName)
    {
        doorIsOpen = openCheck;
        this.GetComponent<AudioSource>().PlayOneShot(aClip);
        this.transform.parent.GetComponent<Animation>().Play(animName);
    }
}
