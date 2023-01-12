using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject monsterViewLocation;
    [SerializeField] private int monsterView;
    Transform viewTransform;
    Player player;

    [Header("看到玩家")]
    public UnityEvent seePlayer;
    // Start is called before the first frame update
   
    private void Awake() 
    {
        player = GameObject.Find("PlayerCapsule").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination (target.transform.position);
        RaycastHit hit;
        Transform viewTransform = monsterViewLocation.transform;
        Ray ray = new Ray(viewTransform.position, viewTransform.forward);
        Debug.DrawRay(viewTransform.position, viewTransform.forward * monsterView);
        if(Physics.Raycast(ray, out hit, monsterView))
        {
            if(hit.collider.tag == "Player")
            {
                seePlayer.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            player.ghostCatch.Invoke();
        }
    }
}
