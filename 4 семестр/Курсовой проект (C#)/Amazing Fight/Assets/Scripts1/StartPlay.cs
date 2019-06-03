using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPlay : MonoBehaviour {

    /// <summary>
    /// Возвращает на сцену Main Menu
    /// </summary>
    public void BackBut()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
