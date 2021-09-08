using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SliderMenuAnim : MonoBehaviour
{
    public GameObject Panel;
    
    public void ShowHidemenu()
    {
        if (Panel != null)
        {
            Animator anim = Panel.GetComponent<Animator>();
            if (anim != null)
            {
                bool isOpen = anim.GetBool("show");
                anim.SetBool("show", !isOpen);
            }

        }
    }
}