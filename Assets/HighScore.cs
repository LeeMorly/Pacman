using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {
	public Text countText;
	public int count;
	void Start () {
		countText.text = PlayerPrefs.GetInt ("MyRice").ToString();
	}
	public void High_Score(){
		countText.text =count.ToString ();
	}
	void Update () {
	
	}
}
