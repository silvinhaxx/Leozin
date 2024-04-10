using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private string levelJogo;

    public void Jogar(string levelJogo)
    {
        SceneManager.LoadScene(levelJogo);
    }
   
}
