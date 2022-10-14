using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameEnd : MonoBehaviour
{

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuJuegos");
    }

}
