using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresentManager : MonoBehaviour
{
    [SerializeField] private GameObject[] present;
    private int presentNumber;

    [Header("拿到一個禮物")]
    public UnityEvent presentFindOne;
    [Header("拿完禮物")]
    public UnityEvent presentFindAll;

    private void Awake() 
    {
        for (int i = 0; i < present.Length; i++)
        {
            presentNumber++;
        }
    }

    private void Update() 
    {
        if(presentNumber <= 0)
        {
            presentFindAll.Invoke();
        }  
    }

    public void OneGiftFound()
    {
        presentNumber -= 1;
    }
}

    
