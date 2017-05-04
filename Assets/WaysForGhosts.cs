using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaysForGhosts : MonoBehaviour {
	public List<Transform> WayPoints;// динамически изменяемый массив;

	void Start(){//foreach -  посмотреть; 
		foreach (Transform item in transform) {
			WayPoints.Add (item);
		}
	}

}
