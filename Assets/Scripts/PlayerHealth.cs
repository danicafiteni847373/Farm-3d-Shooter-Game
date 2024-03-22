using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public Slider slider;
    public GameOverScreen gameOver;

    void Update()
    {
        slider.value = health;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health = health - 10f;
        }
        if (health <= 0)
        {
            Destroy(this.gameObject, 2f);
            Debug.Log("Game Over");
            slider.enabled = false;
            FindObjectOfType<GameOverScreen>().EndGame();

        }
    }

    public void Healths()
    {
        health = 100f;
        slider.value = health;
        Debug.Log("Working");
    }
}
