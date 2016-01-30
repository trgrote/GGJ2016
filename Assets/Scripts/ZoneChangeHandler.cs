using UnityEngine;
using System.Collections;

public class ZoneChangeHandler : MonoBehaviour {

	public Transform CameraCenter;
	public Transform PeaceCenter;
	public Transform DangerCenter;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "PeaceZone") {
			CameraCenter.position = PeaceCenter.position;
			Debug.Log ("PeaceZone");
		} else if (other.tag == "DangerZone") {
			CameraCenter.position = DangerCenter.position;
			Debug.Log ("DangerZone");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
