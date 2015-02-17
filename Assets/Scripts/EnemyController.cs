using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int hitPoints;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision){
		Debug.Log("Hit by "+collision.gameObject.name);

		if(collision.gameObject.tag.ToLower()=="arrow"){
			Debug.Log("Damaged");
			Damage(1);
			//Destory the arrow;
			Destroy(collision.gameObject);
		}
	}
	void Damage(int damageAmount){
		hitPoints-=damageAmount;
		if(hitPoints <= 0 ){
			Die ();
		}
	}
	void Die(){
		GameManager.instance.TargetDestroyed ();
		Destroy(gameObject);
	}
}
