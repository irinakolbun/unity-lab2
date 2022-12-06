using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SphereTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered trigger");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered trigger, loading second scene");
            SceneManager.LoadScene("Scene 2");
        }
    }
}
