using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;//для работы с List;
[Serializable]
public class Animals
{

	public string nickname;
	public int Age;
	public Color color; 
	public bool sex;
}

[Serializable]
public class Dog:Animals
{
	public string speech;

} 

[Serializable]
public class Cat:Animals
{
	public string speech;
}


public class MyScript : MonoBehaviour {
	public List<Dog> dogs;
	public List<Cat> cats;
	public List<Animals> DomesticFem;
	void Start(){
		Dog dog1 = new Dog ();//созданoие экземпляра класса Dog;
		dog1.nickname="Franky";
		dog1.Age = 5;
		dog1.color = Color.yellow;
		dog1.sex = true;
		dog1.speech = "Hav-Hav";
		dogs.Add (dog1);

		Dog dog2 = new Dog ();
		dog2.nickname = "Kay";
		dog2.Age = 3;
		dog2.color = Color.red;
		dog2.sex = false;
		dog2.speech = "hav-hav";
		dogs.Add (dog2);

		Dog dog3 = new Dog ();
		dog3.nickname = "Pufik";
		dog3.Age = 2;
		dog3.color = Color.black;
		dog3.sex = false;
		dog3.speech = "Bark-bark";
		dogs.Add (dog3);

		Cat cat1= new Cat();
		cat1.nickname = "Vasily";
		cat1.Age = 5;
		cat1.color = Color.gray;
		cat1.sex = false;
		cat1.speech = "Meow";
		cats.Add (cat1);

		Cat cat2= new Cat();
		cat2.nickname = "Sato";
		cat2.Age = 6;
		cat2.color = Color.blue;
		cat2.sex = false;
		cat2.speech = "Meow-Meow";
		cats.Add (cat2);

		Cat cat3= new Cat();
		cat3.nickname = "Suzuki";
		cat3.Age = 4;
		cat3.color = Color.black;
		cat3.sex = false;
		cat3.speech = "Me-e-e-e-e-ow";
		cats.Add (cat3);

		Cat minAgecat= cats[0];
		for (int i = 0; i < cats.Count; i++) {
			if (cats [i].Age < minAgecat.Age) {
				minAgecat = cats[i];
				}

		}

		Dog minAgedog = dogs [0];
		for (int i = 0; i < dogs.Count; i++) {
			if (dogs [i].Age < minAgedog.Age) {
				minAgedog = dogs[i];
			}
			
		}
//		Debug.Log (minAgecat.nickname);
//		Debug.Log (minAgedog.nickname);

	    //List<Animals> DomesticFem=null;//присовили сущность "ничего";
		for (int i = 0; i < dogs.Count; i++) {
			if (dogs[i].sex==false) {
				DomesticFem.Add (dogs [i]);
			}
		}
//		Debug.Log (DomesticFem);
		for (int i = 0; i < cats.Count; i++) {
			if (cats[i].sex==false) {
				DomesticFem.Add (cats [i]);
			}
		}
		foreach (var item in DomesticFem) {
			if (item.color==Color.black) {
				//Debug.Log (item.nickname);
			}
		}
		Animals maxAnimal=new Animals();
		foreach (var item in DomesticFem) {
			if (item.color==Color.black) {
				maxAnimal = item;
				break;
			}

		}
		foreach (var item in DomesticFem) {
			if ((item.color==Color.black)&&(item.Age>maxAnimal.Age)) {
				maxAnimal = item;
			}
		}
			


		Debug.Log (maxAnimal.nickname);

	}

}
