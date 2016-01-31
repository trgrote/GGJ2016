using UnityEngine;
using System.Collections;

public class ZoneChangeHandler : MonoBehaviour {

	public Transform CameraCenter;
	public Transform PeaceCenter;
	public Transform DangerCenter;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "PeaceZone") {
			CameraCenter.position = PeaceCenter.position;
		} else if (other.tag == "DangerZone") {
			CameraCenter.position = DangerCenter.position;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
