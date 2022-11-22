using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Option : MonoBehaviour
{
    public GameObject optionpanel;
    private bool set;
    private void Start()
    {
        set = false;
    }


    public void Change()
    {
        set = !set;
        optionpanel.SetActive(set);
    }
}
