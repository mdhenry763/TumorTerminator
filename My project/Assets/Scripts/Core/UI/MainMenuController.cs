using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayClick()
    {
        //SceneManager.LoadScene("Level1");
    }

    public void OnExitGameClick()
    {
        Application.Quit();
    }

    public void OnCancerInfoClick()
    {
        //SceneManager.LoadScene("CancerInfo");
    }

    public void OnReferencesClick()
    {
        //SceneManager.LoadScene("References");
    }


}
