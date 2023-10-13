using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneNames
{ 
    MainMenu,
    Intro,
    Game
}



public class LevelLoader : Singleton<LevelLoader>
{
    private SceneNames currentScene;

    public void LoadLevel(SceneNames sceneName)
    {
        Debug.Log(sceneName.ToString());
        currentScene = sceneName;
        SceneManager.LoadScene(sceneName.ToString());
    }

    public void LoadNextScene()
    {
        int sceneNum = (int)currentScene;
        sceneNum++;
        SceneManager.LoadScene(sceneNum);
    }
}
