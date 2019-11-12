using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionPrev : MonoBehaviour
{
    private int SceneToLoad;

    private void Start()
    {
        SceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(SceneToLoad);
        
    }
}
