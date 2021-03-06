﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PacScript : MonoBehaviour {
	public bool IsAttack;//параметр Аниматора
	public float Speed;//скорость передвижения персонажа 
	public float MoveX;//переменная события нажатия от -1 до 1
	public float MoveY;
	public bool IDeath;
	public bool Border;
	public int count;
	public AudioSource aud;
	public AudioClip PacDeath;
	public AudioClip Pacman;
	public AudioClip PacmanEat;
	public AudioClip GhostDead;
	public GameObject BGMusic;
	public Text countText;
	public GameObject Rice;
	public Transform StartPos;
	public byte Life; 
	public bool Distract;
	public byte CountKill;
	public SoundManager soundManger;

	//public Vector2[] StartPos4Levels;
	private Animator anim;
	private SpriteRenderer sr;
	// Use this for initialization
	private float Timer; 
	public float UndestractableTime;
	public GameObject PanelYOUAREWIN;
	void Start () {
		anim=GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer> ();
		countText.text = "0";
//		countText.text = PlayerPrefs.GetInt ("MyRice").ToString();
//		count = PlayerPrefs.GetInt ("MyRice");
		aud =GetComponent<AudioSource>();// присвоение переменной aud;
		Distract=false;

		Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Distract =GameObject.FindWithTag("Kill");
		if (IDeath == false) {//условие включения управления - смерть персонажа
//			MoveX = Input.GetAxis ("Horizontal");//переменная события нажатия от -1 до 1  работа только с клавой 
//			MoveY = Input.GetAxis ("Vertical");
//			GetComponent<Rigidbody2D> ().velocity = new Vector2 (MoveX * Speed, MoveY*Speed);//обращение к компоненту твердого тела и изменение линейнойй скорости объекта
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, MoveY*Speed);
			//aud.PlayOneShot (Pacman);
			if (Mathf.Abs (MoveX) > 0 || Mathf.Abs (MoveY) > 0) {
				aud.enabled = true;
			//	aud.Play ();
			} else {
				aud.enabled = false;
						}
			if (MoveX < 0) {//условия для MoveX
				sr.flipX = false; //определение поворота спрайта
				anim.SetBool ("IsAttack", true);//запуск анимации атаки
				anim.SetBool ("IsIdle", false);
				anim.SetBool ("IsVertAttDown", false);
				anim.SetBool ("IsVertAttUp", false);

			} else if (MoveX > 0) {
				sr.flipX = true;//определение поворота спрайта
				anim.SetBool ("IsAttack", true);//запуск анимации атаки
				anim.SetBool ("IsIdle", false);
				anim.SetBool ("IsVertAttDown", false);
				anim.SetBool ("IsVertAttUp", false);
			}
			if (MoveX == 0) {//проверка стоим ли мы на месте( проверка нажатия на клавиши) 
				anim.SetBool ("IsIdle", true);//запуск анимации Idle
				anim.SetBool ("IsAttack", false);
				anim.SetBool ("IsVertAttDown", false);
				anim.SetBool ("IsVertAttUp", false);
			}
			if (MoveY < 0) {
				
				sr.flipX=false;
				anim.SetBool ("IsVertAttDown", true);
				anim.SetBool ("IsIdle", false);
				anim.SetBool ("IsVertAttUp", false);
				anim.SetBool ("IsAttack", false);

			}

			if (MoveY >0) {
				//GetComponent<SpriteRenderer> ().flipY = true;
				sr.flipX=false;
				anim.SetBool ("IsVertAttUp", true);
				anim.SetBool ("IsIdle", false);
				anim.SetBool ("IsVertAttDown", false);
				anim.SetBool ("IsAttack", false);

			}
			if (Distract == true) {
				Timer += Time.deltaTime;// Timer=Timer+Timer.deltaTime;
				if(Timer>=UndestractableTime){
					Distract = false;
					Timer = 0;

				}	
			}
				
		}
	} 
	public void MoveHor(int go){
		MoveX = go;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (MoveX * Speed,MoveY*1f);
	}
	public void MoveVert(int go){
		MoveY = go;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (MoveX * 1f, MoveY*Speed);
	}
	void OnCollisionEnter2D(Collision2D col){//метод для столкновений, col - это все объектвы, с которыми мы будем сталкиватся 
		Debug.Log(col.gameObject.name); 	
		if (col.gameObject.tag =="Border") {//если мы сталкиваемся с объектом Border
			Border = true;}//то мы столкнулись с Border 
	


	}


	public void Restart(){
		transform.position = StartPos.position; 
		GetComponent<Animator> ().SetBool ("IsDeath", false);
		Life--;
		if (Life==0) {
			Application.LoadLevel ("pacman_01");
		}

	}

public void CollectRice(GameObject Rice){
		Destroy (Rice);
		count++;
		int MyC= PlayerPrefs.GetInt ("MyRice");//запись состояния собранных монет
		MyC=MyC+1; 
		PlayerPrefs.SetInt ("MyRice", MyC);
		countText.text =count.ToString ();//выводимая надпись


	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Treasure") {
			CollectRice (col.gameObject);
		}
		if (col.gameObject.tag == "Kill") {
			Destroy (col.gameObject);
			count = count + 500;
			int MyC = PlayerPrefs.GetInt ("MyRice");
			MyC = MyC + 500; 
			PlayerPrefs.SetInt ("MyRice", MyC);
			countText.text = count.ToString ();
			Distract = true;
		}
		if (col.gameObject.tag == "Ghost") {
			if (Distract == true) {
				Destroy (col.gameObject);
				soundManger.PlayGhostDead ();
				CountKill++;
				ShowPanelWin ();
							} 
			else {
				anim.SetBool ("IsDeath", true);
				soundManger.PacmanDeath();
				Invoke ("Restart", 1f);
			}
			


		} 

	}



	public void ShowPanelWin(){
		if (CountKill==4) {
//			Youarewin t = FindObjectOfType<Youarewin> ();
			PanelYOUAREWIN.SetActive(true);
			PanelYOUAREWIN.GetComponent<Youarewin> ().countText.text = count.ToString();
			BGMusic.GetComponent<AudioSource>().enabled = false;
		
		}
//		if (Rice == null) {
//			PanelYOUAREWIN.SetActive(true);
//			PanelYOUAREWIN.GetComponent<Youarewin> ().countText.text = count.ToString();
//			BGMusic.GetComponent<AudioSource>().enabled = false;
//		}
	}

	}
		//	void CollectKills(GameObject.tag("Ghost")){}
//		
	

