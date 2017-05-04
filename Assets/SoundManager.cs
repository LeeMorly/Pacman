using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public PacScript Pacman;
	public AudioSource aud;



	public void PlayGhostDead(){
		aud.PlayOneShot (Pacman.GhostDead);
	} 
	public void PacmanDeath(){
		aud.PlayOneShot (Pacman.PacDeath);
	}

}
