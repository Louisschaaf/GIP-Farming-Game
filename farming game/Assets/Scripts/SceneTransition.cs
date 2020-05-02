using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private int SceneToLoad;
    public Animator animator;
    

    private void Start()
    {
        SceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetTrigger("FadeOut");
      
        SceneManager.LoadScene(SceneToLoad);

    }

}
