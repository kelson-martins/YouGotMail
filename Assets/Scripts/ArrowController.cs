using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

	public Vector3 direction;
	public float speed;
	int hitIterator;
	public int hitCount;
	bool isBeingHit;

	// Use this for initialization
	void Start () {
		//Shoot forward 
		direction=transform.forward * speed;

		rigidbody.velocity=direction;
		hitIterator=0;
		isBeingHit=false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision collision){
		Debug.Log("Hit by "+gameObject.name);
		if(!isBeingHit){
			hitIterator++;
			
			//Destroy if reach hitcount
			if(hitIterator >= hitCount){
				Destroy(gameObject);
			}
			//Rotate to new forward vector
			transform.LookAt(rigidbody.velocity);
			isBeingHit=true;
		}

	}
	void OnCollisionExit(Collision collision){
		isBeingHit=false;
	}
}
