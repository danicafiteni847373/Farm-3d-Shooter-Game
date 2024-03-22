using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAnimalGate : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject AnimeObject2;

    public bool Action = false;

    void Start()
    {
        Instruction.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Action == true)
            {
                Instruction.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("animalGateClose");
                AnimeObject2.GetComponent<Animator>().Play("animalGate2Close");
                AnimeObject.GetComponent<Animator>().Play("animalGateOpen");
                AnimeObject2.GetComponent<Animator>().Play("animalGate2Open");
                //ThisTrigger.SetActive(false);
                //DoorOpenSound.Play();
                Action = false;
            }
        }

    }
}
