using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countDown1 : MonoBehaviour {
	
	float timerRemaining =10f;//******************
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timerRemaining -= Time.deltaTime;//******************
	}
	void onGUI()//******************
	{
		if (timerRemaining > 0) {
			GUI.Label (new Rect (0,35,100,100), "Time Remaining: " +(int) timerRemaining);
		}
		else
		{
			GUI.Label(new Rect(100,100,100,100), "Time up " );

		}
	}//******************
}
