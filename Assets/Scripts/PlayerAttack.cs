using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public FadeOut _Flash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			_Flash.StartFadeOut ();
		}
	}
}
