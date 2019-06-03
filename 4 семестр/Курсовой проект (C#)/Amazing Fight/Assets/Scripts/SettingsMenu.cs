using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Settings menu
/// </summary>
public class SettingsMenu : MonoBehaviour
{

    #region Variables

    /// <summary>
    /// Аудиомикшер
    /// </summary>
    public AudioMixer audioMixer;

    /// <summary>
    /// Слайдер громкости
    /// </summary>
    public Slider volumeSlider;

    /// <summary>
    /// Уровень громкости
    /// </summary>
    public float volume1;
    /// <summary>
    /// Тагл "Fullscreen"
    /// </summary>
    public Toggle fullScr;

    /// <summary>
    /// Выпадающий список с разрешениями экрана
    /// </summary>
    public Dropdown resolutionDropDown;

    /// <summary>
    /// Массив разрешений экрана
    /// </summary>
    Resolution[] resolutions;

    /// <summary>
    /// Индекс разрешения экрана на данный момент
    /// </summary>
    public int curRes;
 
    #endregion

    private void Start()
    {
        Cursor.visible = true;

        resolutions = new Resolution[5];

        resolutions[0].width = 800;
        resolutions[0].height = 600;
        resolutions[1].width = 1024;
        resolutions[1].height = 768;
        resolutions[2].width = 1280;
        resolutions[2].height = 720;
        resolutions[3].width = 1360;
        resolutions[3].height = 768;
        resolutions[4].width = 1366;
        resolutions[4].height = 768;

        using (BinaryReader br = new BinaryReader(new FileStream("Resoludion.dat", FileMode.Open)))
        {
            fullScr.isOn = br.ReadBoolean();
            
            int currentResolutionIndex = br.ReadInt32();
            resolutionDropDown.value = currentResolutionIndex;
            resolutionDropDown.RefreshShownValue();
            volumeSlider.value =br.ReadSingle();
            br.Close();
        }
        audioMixer.GetFloat("volume", out volume1);
        volumeSlider.value = volume1 * 3;
    }

    #region Functions

    /// <summary>
    /// Установка разрешения экрана
    /// </summary>
    /// <param name="resolutionIndex">Индекс элемента из выпадающего списка</param>
    public void SetResolution(int resolutionIndex)
    {
        curRes = resolutionIndex;
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, fullScr.isOn);
   
    }

    /// <summary>
    /// Сохранение настроек
    /// </summary>
    public void SaveSettings()
    {
        using (BinaryWriter bw = new BinaryWriter(new FileStream("Resoludion.dat", FileMode.Create, FileAccess.Write)))
        {
            bw.Write(fullScr.isOn);
            Debug.Log(fullScr.isOn);
            bw.Write(resolutionDropDown.value);
            bw.Write(volumeSlider.value);
            bw.Close();
        }
    }

    /// <summary>
    /// Изменение громкости
    /// </summary>
    /// <param name="volume">Уровень громкости</param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume / 3);
    }

    /// <summary>
    /// Установко полноэкранного режимы
    /// </summary>
    /// <param name="isFullscreen">Тагл "Fullscreen"</param>
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    /// <summary>
    /// Переход на игровую сцену
    /// </summary>
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    /// <summary>
    /// Переход на сцену Main Menu
    /// </summary>
    public void HelpButton()
    {
        SceneManager.LoadScene("Help");
    }

    /// <summary>
    /// Выход из игры
    /// </summary>
    public void QuitButton()
    {
        Application.Quit();
    }
    #endregion
}
