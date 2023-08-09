using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
