using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class CoconutWin : MonoBehaviour
{
    public static int targets = 0;
    public static bool haveWon = false;

    public AudioClip winSound;
    public GameObject cellPrefab;
    public Vector3 cellPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(targets == 3 && !haveWon)
        {
            targets = 0;

            GetComponent<AudioSource>().PlayOneShot(winSound);
            GameObject winCell = transform.Find("powerCell").gameObject;

            winCell.transform.Translate(cellPosition);

            Instantiate(cellPrefab, winCell.transform.position, transform.rotation);

            Destroy(winCell);
            haveWon = true;
        }
    }
}
