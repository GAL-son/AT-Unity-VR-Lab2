using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowTrigger : MonoBehaviour
{
    public RawImage crosshair;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleWeapon")) {
            ToggleThrow();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SetThrow(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetThrow(false);
        }
    }

    void ToggleThrow()
    {
        CoconutThrower.canThrow = !CoconutThrower.canThrow;
        crosshair.enabled = !crosshair.enabled;
    }

    void SetThrow(bool canThrow)
    {
        CoconutThrower.canThrow = canThrow;
        crosshair.enabled = canThrow;
    }
}
