using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool pause;
    public GameObject menu;
    public GameObject painel;
    public GameObject voltarPainel;
    [SerializeField] private string levelJogo;

    public static GameController instance;

    void Start()
    {
        instance = this;
        Time.timeScale = 1f;
        pause = false;
    }
    public void AbrirPainel()
    {
        if (pause == false)
        {
            Time.timeScale = 0f;
            pause = true;
            menu.SetActive(false);
            painel.SetActive(true);
        }
    }
    public void FecharPainel()
    {
        if (pause == true)
        {
            Time.timeScale = 1f;
            pause = false;
            menu.SetActive(true);
            painel.SetActive(false);
        }
    }

    public void AbrirVoltarPainel(string levelName)
    {
        SceneManager.LoadScene(levelJogo);
        Time.timeScale = 1f;
        pause = false;

    }
}
