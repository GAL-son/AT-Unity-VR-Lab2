using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]


public class DeathMenuGUI : MonoBehaviour
{
    public AudioClip beep;
    public GUISkin menuSkin;
    public Rect menuArea;

    Rect goToMenuBtn;
    float buttonHeight = 40;

    bool isVisible = false;

    private void Start()
    {
        menuArea.x -= menuArea.width / 2;
        goToMenuBtn = new Rect(0, 0, menuArea.width, buttonHeight);
    }

    private void OnGUI()
    {
        GUI.skin = menuSkin;

        if (isVisible)
        {
            GUI.BeginGroup(menuArea);

            if (GUI.Button(goToMenuBtn, "Wróæ do menu"))
            {
                
                StartCoroutine("ButtonAction");
            }

            GUI.EndGroup();
        }
    }

    public void ShowMenu()
    {
        Debug.Log("SHOW MENU");
        isVisible = true;
    }

    IEnumerator ButtonAction()
    {
        Debug.Log("SHOW BUTTON");
        GetComponent<AudioSource>().PlayOneShot(beep);
        yield return new WaitForSeconds(0.35f);
        SceneManager.LoadScene("Menu");
    }

}
