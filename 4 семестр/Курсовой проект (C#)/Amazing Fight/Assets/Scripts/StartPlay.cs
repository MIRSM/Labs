using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Start play
/// </summary>
public class BackToMenu : MonoBehaviour {

    /// <summary>
    /// Возвращает на сцену Main Menu
    /// </summary>
    public void BackBut()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
