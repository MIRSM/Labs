using UnityEngine;
/// <summary>
/// Pause play
/// </summary>
public class PausePlay : MonoBehaviour {

	/// <summary>
	/// Объект меню паузы
	/// </summary>
	public GameObject pauseMenu;
	//public AudioSource musik;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if (pauseMenu.activeInHierarchy)
			GetComponent<AudioSource> ().Pause ();
	}


}
