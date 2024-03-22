using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnCollisionFollow : MonoBehaviour
{
    public GameObject myTarget;
    public NavMeshAgent myAgent;
    public GameObject animalDrop;
    //public AudioClip collectSound;
    // Start is called before the first frame update
    void Update()
    {
        if (myTarget != null)
        {
            myAgent.destination = myTarget.transform.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //AudioSource.PlayClipAtPoint(collectSound, transform.position);
            myTarget = other.gameObject;
            Debug.Log("Collide");
        }
        if (other.tag == "Target")
        {
            Instantiate(animalDrop, transform.position, Quaternion.identity);
            Destroy(gameObject, .2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            myTarget = null;
        }
    }
}
