
using UnityEngine;
using System.Collections;

public class CountdownTimer_CSHARP : MonoBehaviour 
{
	// For our timer we will use minutes and seconds
	public float Seconds = 40;
	public float Minutes = 0;

	void Start() {

	}

	void Update()
	{
		if(Seconds <= 0)
		{
			Seconds = 60;
			if(Minutes >= 1)
			{
				Minutes--;
			}
			else
			{
				Minutes = 0;
				Seconds = 0;
				// This makes the guiText show the time as X:XX. ToString.("f0") formats it so there is no decimal place.
				GameObject.Find("TimerText").guiText.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
				GameOver();
			}
		}
		else
		{
			Seconds -= Time.deltaTime;
		}

		// These lines will make sure the time is shown as X:XX and not X:XX.XXXXXX
		if(Mathf.Round(Seconds) <= 9)
		{
			GameObject.Find("TimerText").guiText.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
		}
		else
		{
			GameObject.Find("TimerText").guiText.text = Minutes.ToString("f0") + ":" + Seconds.ToString("f0");
		}

		if (Mathf.Round(Seconds) == 20) {
			GameManager.instance.speedup = true;
			Debug.Log("speed up");
		} 
	}

	void OnGUI () {
		
		//GUI.Label(new Rect(120, 10, 100, 20), GameObject.Find("TimerText").guiText.text);

	}

	void GameOver() {
	
	}
}