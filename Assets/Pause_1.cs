using UnityEngine;
using System.Collections;

public class Pause_1 : MonoBehaviour {
	public bool paused;
	public GameObject Music;
	public GameObject PanelPAUSE;
	public GameObject PanelYOUAREWIN;

	void Start () {
		paused = false;

	}
	public void Pause(){
		if(!paused){ 
			Time.timeScale = 0; 
			paused=true; 
			Music.GetComponent<AudioSource>().Pause();
			PanelPAUSE.SetActive (true);
		}
		else
		{ 
			Time.timeScale = 1; 
			paused=false; 
			Music.GetComponent<AudioSource>().Play();
		    PanelPAUSE.SetActive (false);
		} 
	}
	public void Home(){
		Application.LoadLevel ("MainMenu");
		PanelYOUAREWIN.SetActive (false);
		PanelPAUSE.SetActive (false);
	}

	public void Restart(){
		Application.LoadLevel ("pacman_01");
		PanelYOUAREWIN.SetActive (false);
		PanelPAUSE.SetActive (false);
	}

	public void ExitGame(){
		Application.Quit();	
	}
	void Update () {
		
	}
}
