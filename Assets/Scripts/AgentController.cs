using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private List<GameObject> _waypoints;
    private NavMeshAgent _agent;
    private Animator _anim;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _waypoints = new List<GameObject>();
        foreach (GameObject wp in GameObject.FindGameObjectsWithTag("Waypoints"))
        {
            _waypoints.Add(wp);
        }
        _agent.SetDestination(GetWaypoint());
        // _anim.SetBool("isWalking", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.remainingDistance == 0 && _agent.isStopped == false)
        {
            // _anim.SetBool("isWalking", false);
            _agent.isStopped = true;
            StartCoroutine(WaitToMove(UnityEngine.Random.Range(0, 5)));
        }
    }

    public IEnumerator WaitToMove(float duration)
    {
        yield return new WaitForSeconds(duration);
        _agent.SetDestination(GetWaypoint());
        //_anim.SetBool("isTalking", false);
        //_anim.SetBool("isWalking", true);
        _agent.isStopped = false;
    }



    private Vector3 GetWaypoint()
    {
        return _waypoints[UnityEngine.Random.Range(0, _waypoints.Count)].transform.position;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Cow")
        {
            //randomize a number            
            int randInt = UnityEngine.Random.Range(0, 15);
            //if it is a certain number and the agent is walking, start talking with the other agent            
            if (randInt == 4 && _agent.isStopped == false && c.gameObject.GetComponent<NavMeshAgent>().isStopped == false)
            {
                StartCoroutine(WaitToMove(5f));
                StartCoroutine(c.GetComponent<AgentController>().WaitToMove(5));
                _agent.isStopped = true;
                //_anim.SetBool("isWalking", false);
                //_anim.SetBool("isTalking", true);
                c.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                c.gameObject.GetComponent<Animator>().SetBool("isWalking", false);
                c.gameObject.GetComponent<Animator>().SetBool("isTalking", true);
                //rotating this agent                
                transform.LookAt(c.transform);
                //rotating the agent that it collided with                
                c.transform.LookAt(transform);
            }
            else
            {
                _agent.SetDestination(GetWaypoint());
                c.gameObject.GetComponent<NavMeshAgent>().SetDestination(GetWaypoint());
            }
        }
    }
}
