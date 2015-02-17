using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int level = 0;
	public int player1 = 0;
	public int player2 = 0;
	public int player3 = 0;
	public int player4 = 0;
	public int score;
	public int killPoints = 10;
	public bool speedup = false;

	//counts time passing since level start
	public float timer = 0.0f;
	// level ends after this many seconds
	public float timeLimit = 20.0f;
	public bool timesUp = false;

	public int targetsRemaining = 3;
	public bool win = false;


	private static GameManager _instance;

	public static GameManager instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<GameManager> ();
			}
			return _instance;
		}
	}

	void Awake() {
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else {
			if(this != _instance ){
				Destroy(this.gameObject);
			}
		}
	}
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (timer.ToString ());
		if (!timesUp && !win) {
			timer += Time.deltaTime;
			if (timer > timeLimit) {
				timesUp = true;
				Debug.Log ("Times Up");
			}
		} else {


		}
	}

	public void TargetDestroyed() {

		targetsRemaining--;

		if (targetsRemaining <= 0) {
			//Application.LoadLevel("UI");
		}
		updateScore (killPoints);
		//Debug.Log ("called from outside manager.");
	}

	public void updateScore(int points){
		score += points;
		// gui
		Debug.Log (score.ToString());
	}

	public void StartGame() {
		Application.LoadLevel ("Main");
	}


}
