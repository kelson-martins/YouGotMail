using UnityEngine;
using System.Collections;

public class ReflectObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
//		Debug.Log("Trigger hit");
		if(other.gameObject.tag.ToLower()=="arrow"){
//			Debug.Log("It's an arrow");
			Vector3 direction = other.gameObject.GetComponent<ArrowController>().direction;
			Vector3 newDirection=Vector3.Reflect(direction, gameObject.transform.position.normalized);

			other.gameObject.GetComponent<ArrowController>().direction=newDirection;
		}
	}
}
