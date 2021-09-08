using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Mybuttonsclicked : MonoBehaviour
{
   
    public void Umstellershow()
    {
        SceneManager.LoadScene("Teilenumsteller");//, LoadSceneMode.Additive);
    }

    public void Chanshow()
    {
        SceneManager.LoadScene("Teilenchan");
    }
}
