using UnityEngine;
using System.Collections;

public class IntervalTimer : MonoBehaviour {

    public float delay = 5;
	public bool isActive = false;
	public WebCamPhotoCamera WBCPC;

	private float currentDelay = 0;

	// Use this for initialization
	void Start () {
		currentDelay = delay;
	}
	
	// Update is called once per frame
	void Update () {

		if (isActive) {

			currentDelay -= 1*Time.deltaTime;

			if (currentDelay <= 0){
				takePic();
			}

		}	
	}

	public void changeActiveState (bool state){
		isActive = state;
	}

	public void changeDelay (string cdelay){
		float ndelay = float.Parse (cdelay);
		delay = ndelay;
	}

	void takePic(){
		WBCPC.Snap();
		currentDelay = delay;
	}
}
