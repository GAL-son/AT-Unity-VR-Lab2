using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int charge = 0;

    public AudioClip collectSound;

    // HUD
    public Texture2D[] hudCharge;
    public RawImage chargeHudGUI;
        // Matches
    bool haveMatches = false;
    public RawImage matchesHudGUI;
        // Inventory Hint
    public Text textHints;

    // Fire
    bool fireLit = false;

    // Generator
    public Texture2D[] meterCharge;
    public Renderer meter;

    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name == "campfire")
        {
            if(haveMatches)
            {
                LightFire(hit.gameObject);
            }
            else if(!fireLit)
            {
                textHints.SendMessage("ShowHint", "Móg³bym rozpaliæ ognisko do wezwania pomocy.\nTylko czym...");
            }
        }
    }

    void LightFire(GameObject campfire)
    {
        fireLit = true;

        ParticleSystem[] fireEmitters;
        Light campfireLight;

        fireEmitters = campfire.GetComponentsInChildren<ParticleSystem>();
        campfireLight = campfire.GetComponentInChildren<Light>();
        
        foreach(ParticleSystem emitter in fireEmitters)
        {
            emitter.Play();
        }

        campfireLight.enabled = true;
        campfire.GetComponent<AudioSource>().Play();

        matchesHudGUI.enabled = false;
        haveMatches = false;

    }

    void CellPickup()
    {
        
        HUDon();        
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        charge++;
        chargeHudGUI.texture = hudCharge[charge];
        meter.material.mainTexture = meterCharge[charge];
    }

    void HUDon()
    {
        if(!chargeHudGUI.enabled) 
        {
            chargeHudGUI.enabled = true;
        }
    }

    void MatchPickup()
    {
        haveMatches = true;
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        matchesHudGUI.enabled = true;
    }
}


