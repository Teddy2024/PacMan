using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    private PresentManager presentManager;
    private GameObject eToGift;
    private bool canTake = false;

    private void Awake() 
    {
        presentManager = GameObject.Find("=====Present==========").GetComponent<PresentManager>();
        eToGift = GameObject.Find("GiftCanvas").transform.GetChild(0).gameObject;;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E) && canTake)
        {
            presentManager.presentFindOne.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            canTake = true;
            eToGift.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            canTake = false;
            eToGift.SetActive(false);
        }
    }
}
