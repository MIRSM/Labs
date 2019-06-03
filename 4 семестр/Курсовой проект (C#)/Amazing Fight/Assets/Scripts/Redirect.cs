using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Redirect.
/// </summary>
public class Redirect : MonoBehaviour {

	/// <summary>
	/// Продолжительность показа лого
	/// </summary>
    public float logoDuration = 0;
    
	/// <summary>
	/// Максимальная продолжительность показа лого
	/// </summary>
	public float maxLogoDuration = 1f;

    // Use this for initialization
    void Start () {
        using (BinaryReader br = new BinaryReader(new FileStream("Resoludion.dat", FileMode.Open)))
        {
            Screen.fullScreen= br.ReadBoolean();

            int currentResolutionIndex = br.ReadInt32();
            br.Close();
            //resolutionDropDown.value = currentResolutionIndex;
            //resolutionDropDown.RefreshShownValue();
        }
    }
    private void Update()
    {
        logoDuration += Time.deltaTime;
        if (logoDuration > maxLogoDuration)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
            
    }

}
