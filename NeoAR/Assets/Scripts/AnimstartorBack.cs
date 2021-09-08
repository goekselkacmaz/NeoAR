using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimstartorBack : MonoBehaviour
{
    public GameObject player;
    Animator otherAnimator;
    void Awake()
    {
        otherAnimator = player.GetComponent<Animator>();
    }
    public void Animationsplay()
    {
        otherAnimator.Play("RISING_P");
    }

    public void Animationsplay2()
    {
        otherAnimator.Play("Hikick");
    }

    public void BacktoBegin()
    {
        SceneManager.LoadScene("mehrereObjecte");//, LoadSceneMode.Additive);
    }

}
