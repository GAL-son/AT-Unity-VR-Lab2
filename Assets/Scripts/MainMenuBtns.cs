using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class MainMenuBtns : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string LevelToLoad;
    public Sprite normalTexture;
    public Sprite rollOverTexture;
    public AudioClip clickSound;

    public bool exitButton = false;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = rollOverTexture;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = normalTexture;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<AudioSource>().PlayOneShot(clickSound);
        if (exitButton)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        else
        {
            
            SceneManager.LoadScene(LevelToLoad);
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
