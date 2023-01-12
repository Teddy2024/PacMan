using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStart : MonoBehaviour
{
    [SerializeField] private GameObject monster;
  

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            monster.SetActive(true);
            this.enabled = false;
            Destroy(gameObject);
        }
    }
}
