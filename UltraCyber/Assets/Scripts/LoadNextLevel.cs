using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNextLevel : MonoBehaviour
{
    public string levelToLoad;
    //when the player collides with me
    //load the given level
    private void OnTrigger2D()
    {
        if(gameObject.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
