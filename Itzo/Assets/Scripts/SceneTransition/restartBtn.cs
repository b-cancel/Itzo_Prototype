using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartBtn : MonoBehaviour
{
    private void Update()
    {
        if(Input.anyKey)
            SceneManager.LoadScene("Title", LoadSceneMode.Single);

    }
    public void onReStartClick()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}