using UnityEngine;
using System.Collections;

public class PlayerConversation : MonoBehaviour 
{
	GameObject _currentNPCTarget;
	UnityStandardAssets._2D.Platformer2DUserControl _controls;

	void OnTriggerEnter2D(Collider2D other)
	{
		// If we've entered the NPC's bubble, then that means there's probably a conversation
		if ( other.tag == "NPC" )
		{
			var topics = other.GetComponent<Topics>();

			// they have topics, store them
			if ( topics && _currentNPCTarget != other.gameObject )
			{
				_currentNPCTarget = other.gameObject;
			}
		}
	}

	void OnTriggerExit2D( Collider2D other )
	{
		if ( _currentNPCTarget == other.gameObject )
		{
			_currentNPCTarget = null;
		}
	}

	void Update()
	{
		// Wait for player input
		if ( Input.GetKeyDown( KeyCode.E ) && _currentNPCTarget != null )
		{
			// Switch to conversation state
			_controls.enabled = false;
		}
	}
}
