using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

       // _agent.SetDestination(GetRandomWaypoint().transform.position);
       // _agent = GameObject.FindWithTag("Zombie").transform.GetComponent<NavMeshAgent>();
        // _agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_agent !=null)
        _agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
        
    }
}
