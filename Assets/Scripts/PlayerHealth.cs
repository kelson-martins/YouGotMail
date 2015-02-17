using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int health=1;
	public float angleToHit=100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag.ToLower()=="arrow"){
			float angleToArrow=Vector3.Angle(transform.forward,collision.gameObject.transform.forward);
			Debug.Log (angleToArrow.ToString()+" = angle");
			if(angleToArrow>angleToHit){
				PlayerHit();
			}
		}
	}
	void PlayerHit(){
		health--;
		audio.Play ();
		if(health<=0){
			Die();
		}
	}
	void Die(){
		GameManager.instance.TargetDestroyed ();
		Destroy(gameObject);
	}
}
