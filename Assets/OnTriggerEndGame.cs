using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnTriggerEndGame : MonoBehaviour
{
    public GameObject text;
    private ScoreManager manager;
    public bool Action = false;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        manager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && manager.score >= 7)
        {
            if (Action == true)
            {
                manager.score -= 1;
                Debug.Log("Press");
                SceneManager.LoadScene(2);
                text.SetActive(false);
                Action = false;
            }
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        text.SetActive(true);
        Action = true;
    }
}
