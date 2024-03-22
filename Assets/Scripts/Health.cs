using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public ParticleSystem particles;
    public float health;
    public Slider slider;

    public static Health instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        slider.value = health;
    }

    public void ReduceHealth()
    {
        health = health - 50f;
        if (health <= 0)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(this.gameObject, 0.5f);
        }

    }


    public void ReduceHealthLvl2()
    {
        health = health - 20f;
        if (health <= 0)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(this.gameObject, 0.5f);
        }

    }






    //private void OnTriggerEnter(Collider other)
    //{
    //    //Check to see if the tag on the collider is equal to Enemy
    //    if (other.tag == "Bullet")
    //    {
    //        health = health - 50f;
    //        Debug.Log("Triggered by Enemy");
    //   }

    //    if (health == 0)
    //    {
    //        Destroy(this.gameObject);
    //    }
    // }
}
