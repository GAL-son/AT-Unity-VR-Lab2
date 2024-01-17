using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerDeath : MonoBehaviour
{
    public Image bloodImage;
    public Text textHints;
    public DeathMenuGUI showMenu;
    public float menuDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void KillPlayer()
    {        
        StartCoroutine("ShowDeathMenu");
    }

     IEnumerator ShowDeathMenu()
     {
        bloodImage.enabled = true;
        GetComponent<FirstPersonController>().enabled = false;
        textHints.SendMessage("ShowHint", "Zginπ≥eú zagryüiony przez wilka");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        yield return new WaitForSeconds(menuDelay);
        Debug.Log("SHOW MENU");
        showMenu.SendMessage("ShowMenu");
    }
}
