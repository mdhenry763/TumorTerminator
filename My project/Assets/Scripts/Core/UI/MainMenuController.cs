using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Testicle");
    }

    public void OnExitGameClick()
    {
        Application.Quit();
    }

    public void OnCancerInfoClick()
    {
        //SceneManager.LoadScene("CancerInfo");
    }

    public void OnCreditsClick()
    {
        //SceneManager.LoadScene("References");
    }


}
