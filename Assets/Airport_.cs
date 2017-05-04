using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;//для работы с List;

[Serializable]
public class Aerodrome
{
	public string Departure;
	public List<Airplane> planes;

	public void AddPlanes(string _name,string _Destination,int _FlightTime,int _PassengersAmount)
	{
		this.planes.Add (new Airplane(){name =_name, Destination=_Destination,FlightTime=_FlightTime, PassengersAmount=_PassengersAmount });
			
	}
	public Airplane FindPlane (string toDestination)
	{
		Airplane plane=new Airplane();
		for (int i = 0; i < this.planes.Count; i++) {
			if (this.planes[i].Destination==toDestination) {
				plane = this.planes [i];
				break;
			}
		}
		//Debug.Log (plane.name);
		foreach (var item in planes) {
			if (item.Destination==toDestination) {
				//Debug.Log (plane.name);
				if (item.PassengersAmount<plane.PassengersAmount) {
					//Debug.Log (plane.name);
					if (item.FlightTime<=plane.FlightTime ) {
						//Debug.Log (plane.name);
						plane = item;
					}
				}
			}	
		} 
			

		return plane;
	}

}

[Serializable]
public class Airplane
{
	public string name;
	public string Destination;
	public int FlightTime;
	public int PassengersAmount;

}



public class Airport_ : MonoBehaviour {

	public Aerodrome Kyiv;
	void Start () {
		Kyiv.Departure= "Borispol";
		Kyiv.AddPlanes ("Airbus", "Kharkiv", 1, 50);
		Kyiv.AddPlanes ("Boeing", "Kharkiv", 2, 45);
		Kyiv.AddPlanes ("Messerschmitt", "Berlin", 3, 80);
		Kyiv.AddPlanes ("Focke-Wulf", "Kharkiv", 1, 25);
		Kyiv.AddPlanes ("Mriya", "Kharkiv", 1, 1000);

		Debug.Log(Kyiv.FindPlane("Kharkiv").name);
	
	}
}
