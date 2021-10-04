using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public List<string> charactersLeft;
    public Animator transition;
    public float transitionTime = 1f;

    //public float whiteTransitionTime = 3f;
    //public Animator whiteTransition;

    // Update is called once per frame
    void Start()
    {
    }

    public void LoadNextLevel() {
        if (charactersLeft.Count == 0) StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //public void specialLoadNextLevel()
    //{
    //    if(charactersLeft.Count == 0) StartCoroutine(specialLoadLevel());
    //}

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex); 
    }

    //IEnumerator specialLoadLevel()
    //{
    //    whiteTransition.SetTrigger("specialStart");
    //    yield return new WaitForSeconds(whiteTransitionTime);
    //    SceneManager.LoadScene(13);
    //}

}
