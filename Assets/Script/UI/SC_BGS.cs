using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_BGS : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("GameScene");
    }
}
