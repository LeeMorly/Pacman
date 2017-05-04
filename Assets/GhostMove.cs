using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour {
	public float speed;
	public int CurrentWayPoint;
	public WaysForGhosts Ways;

	// Use this for initialization
	void Start () {
		Ways = GameObject.Find ("managerGhostMove").GetComponent<WaysForGhosts> ();

	}
	

	void FixedUpdate () {

		if (transform.position!=Ways.WayPoints[CurrentWayPoint].position) {
			transform.position = Vector3.MoveTowards (transform.position, new Vector3(Ways.WayPoints[CurrentWayPoint].position.x,Ways.WayPoints[CurrentWayPoint].position.y,0f), speed);
			//Debug.Log ("0000");
		} 
		else
		{ CurrentWayPoint= ( CurrentWayPoint + 1)% Ways.WayPoints.Count;
			
		}
	}
}
//Выход из Игры Application.Quit();
//rigidbody rb.MovePosition(vector2)(3);