using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Denial");
    }
    
    public void ReturnToMenu ()
    {
        SceneManager.LoadScene("Menu");
    }
}
