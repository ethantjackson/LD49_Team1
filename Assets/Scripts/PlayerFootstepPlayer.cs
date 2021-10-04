using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFootstepPlayer : MonoBehaviour
{

    public AudioSource Footsteps;
    public float footstepVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            Footsteps.volume = footstepVolume;
        } else
        {
            Footsteps.volume = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMovement>().getMovement() == 0)
        {
            Footsteps.Stop();
        }
    }

    public void playFootsteps()
    {
        Footsteps.Play();
    }
}
