using UnityEngine;
using System.Collections;

public class PlayerConversation : MonoBehaviour 
{
	GameObject _currentNPCTarget;
	UnityStandardAssets._2D.Platformer2DUserControl _controls;
	ConversationPlayer _convoPlayer;

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

	void Start()
	{
		// Should only be one
		_convoPlayer = FindObjectOfType<ConversationPlayer>();

		_convoPlayer._conversationEnd.AddListener( () => OnConversationEnd() );

		_controls = GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>();
	}

	void Update()
	{
		// Wait for player input
		if ( Input.GetKeyDown( KeyCode.E ) && _currentNPCTarget != null )
		{
			// Switch to conversation state
			_controls.enabled = false;

			var topics = _currentNPCTarget.GetComponent<Topics>();

			_convoPlayer.StartConversation( topics._topics );
		}
	}

	public void OnConversationEnd()
	{
		// We should be the only ones who have a conversation going on
		_controls.enabled = true;
	}
}
