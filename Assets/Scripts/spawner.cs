using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	
	public GameObject arrow;
	public Transform[] players;
	public Transform target;
	public int spawnRate=2;
	int spawn = 0;

	// Use this for initialization
	void Start () {
		transform.LookAt (target);
	}
	
	// Update is called once per frame
	void Update () {

		spawn++;
		if (spawn == 60/spawnRate) {
			spawnArrow();
			spawn = 0;
		}
	}

	void spawnArrow() {
		GameObject clone;
		Transform playerToHit = players [Random.Range (0, players.Length)];
		//while (playerToHit!=null) {
		//	playerToHit = players [Random.Range (0, players.Length - 1)];
		//}
		transform.LookAt (playerToHit);
		clone = Instantiate(arrow, 
		                    this.transform.position, 
		                 	this.transform.rotation) as GameObject;
	}
}
