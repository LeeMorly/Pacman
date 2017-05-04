using UnityEngine;
using System.Collections;

public class GhostMovePinky : MonoBehaviour {
	public float speed;
	public int CurrentWayPoint;
	public WaysForGhosts Ways;

	// Use this for initialization
	void Start () {
		Ways = GameObject.Find ("managerGhostMovePinky").GetComponent<WaysForGhosts> ();

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
