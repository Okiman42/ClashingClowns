using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMaster : MonoBehaviour
{
        

    public void Update()
    {
        Mainmenu();
        restart();
    }


    private void restart()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string SceneName = currentScene.name;

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(currentScene.name);
        }
    }


    public void Mainmenu()
    {
        if (Input.GetKey(KeyCode.Tab))
            SceneManager.LoadScene(0);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
