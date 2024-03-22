using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpaenEnemies : MonoBehaviour
{
    private GameObject _blueAgent;


    private GameObject _blueWaypoints;


    private List<GameObject> _blueAgents;


    // Start is called before the first frame update
    void Start()
    {
        _blueAgent = GameObject.Find("Zombie");


        _blueWaypoints = GameObject.Find("Farmer");

        SpawnAgent(1);
    }

    private void SpawnAgent(int amount)
    {
        _blueAgent.GetComponent<NavMeshAgent>().SetDestination(_blueWaypoints.transform.position);




        _blueAgents = new List<GameObject>();


        _blueAgents.Add(_blueAgent);

        //Spawn Agents
        for (int i = 0; i < amount + 1; i++)
        {
            //spawn blue agents
            GameObject newBlueAgent = Instantiate(_blueAgent, _blueAgent.gameObject.transform.position, Quaternion.identity,
            GameObject.Find("Enemy").transform);
            newBlueAgent.GetComponent<NavMeshAgent>().SetDestination(_blueWaypoints.transform.position);
            _blueAgents.Add(newBlueAgent);


        }

    }
}
