using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMaster : MonoBehaviour
{
    public void Update()
    {
        Mainmenu();
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
