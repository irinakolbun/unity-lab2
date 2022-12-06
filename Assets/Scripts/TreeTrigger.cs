using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TreeTrigger : MonoBehaviour
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
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered trigger, loading second scene");
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            DontDestroyOnLoad(PlayerController.instance.gameObject);
        }
    }
}
