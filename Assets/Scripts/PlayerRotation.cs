using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {
	public int playerNo;
	public float rotateSpeed = 5.0f;

	private Animator animator;

	Vector3 movement;
	public float movementSpeed=5.0f;
	Rigidbody playerRigidbody;
	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator> ();
		playerRigidbody=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Turn();
		Move();
	}
	void Turn(){
		string horizontalAxis = "R_XAxis_"+playerNo.ToString();
		string verticalAxis = "R_YAxis_"+playerNo.ToString();

		Vector3 aimDirection = Vector3.right * Input.GetAxis (horizontalAxis) + -1*Vector3.forward*Input.GetAxis(verticalAxis);
		if (aimDirection.sqrMagnitude > 0.0f) {
			Quaternion aimRotation = Quaternion.LookRotation (aimDirection, Vector3.up);
			transform.rotation = Quaternion.Slerp (transform.rotation, aimRotation, rotateSpeed * Time.deltaTime);
		}
	}
	void Move(){
		float h=Input.GetAxis("L_XAxis_"+playerNo.ToString());
		float v=Input.GetAxis("L_YAxis_"+playerNo.ToString());
		Debug.Log ("H: "+h.ToString()+" V: "+v.ToString());

		if (h > 0 || v > 0) {
			animator.SetBool ("Walking", true);
		} else {
			animator.SetBool ("Walking", false);
		}

		movement.Set(h,0f,-1f*v);
		movement=movement.normalized * movementSpeed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position+movement);
	}
}
