using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealth : MonoBehaviour
{
    public PlayerHealth script;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            script.Healths();
            Debug.Log("Full Health");
        }

    }
}
