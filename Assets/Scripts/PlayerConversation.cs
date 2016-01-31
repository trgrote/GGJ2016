using UnityEngine;
using System.Collections;

public class PlayerConversation : MonoBehaviour 
{
	GameObject _currentNPCTarget;
	UnityStandardAssets._2D.Platformer2DUserControl _controls;
	ConversationPlayer _convoPlayer;
	bool _inConversation = false;

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

				// Also, try to find Child named "HoveringText" and if it exists, start it up
				var hovering_text = _currentNPCTarget.transform.FindChild("HoveringText");

				if ( hovering_text )
				{
					hovering_text.gameObject.SetActive(true);
				}
			}
		}
	}

	void OnTriggerExit2D( Collider2D other )
	{
		if ( _currentNPCTarget == other.gameObject )
		{
			// Also, try to find Child named "HoveringText" and if it exists, start it up
			var hovering_text = _currentNPCTarget.transform.FindChild("HoveringText");

			if ( hovering_text )
			{
				hovering_text.gameObject.SetActive(false);
			}

			_currentNPCTarget = null;
		}
	}

	void Start()
	{
		// Should only be one
		_convoPlayer = FindObjectOfType<ConversationPlayer>();

		if ( _convoPlayer != null )
			_convoPlayer._conversationEnd.AddListener( () => OnConversationEnd() );

		_controls = GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>();
	}

	void Update()
	{
		// Wait for player input
		if ( ! _inConversation && Input.GetKeyDown( KeyCode.E ) && _currentNPCTarget != null )
		{
			// Switch to conversation state
			_controls.enabled = false;

			var topics = _currentNPCTarget.GetComponent<Topics>();

			_convoPlayer.StartConversation( topics._topics );

			// Also, try to find Child named "HoveringText" and if it exists, start it up
			var hovering_text = _currentNPCTarget.transform.FindChild("HoveringText");

			if ( hovering_text )
			{
				hovering_text.gameObject.SetActive(false);
			}

			_inConversation = true;
		}
	}

	public void OnConversationEnd()
	{
		// We should be the only ones who have a conversation going on
		_controls.enabled = true;
		_inConversation = false;
	}
}
