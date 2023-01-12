using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject flashLight;
    private Light myLight;

    [Header("被鬼抓到")]
    public UnityEvent ghostCatch;

    [Header("手電筒開關")]
    public UnityEvent FlashLightOnOff;

    private void Awake() 
    {
        myLight = flashLight.GetComponent<Light>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            FlashLightOnOff.Invoke();
        }
    }

    public void FlashLightControl()
    {
        myLight.enabled = !myLight.enabled;
        //開關音效
    }
}
