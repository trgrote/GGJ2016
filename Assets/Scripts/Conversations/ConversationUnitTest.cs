using UnityEngine;
using System.Collections;

public class ConversationUnitTest : MonoBehaviour 
{
	public ConversationPlayer _convoPlayer;
	public Topics _topics;

	// Use this for initialization
	void Start () 
	{
		_convoPlayer.ConversationEnd += () => Debug.Log("Conversation Ended");

		_convoPlayer.StartConversation( _topics._topics );

		Debug.Log("NPC: " + _convoPlayer.CurrentDialogue );

		ConversationOption next_option = null;

		foreach ( var option in _convoPlayer.GetOptions() )
		{
			Debug.Log( "OPTION: " + option._option + " => " + option._nextTopic );

			if ( option._nextTopic != TopicName.END )
			{
				next_option = option;
			}
		}

		// _convoPlayer.ChooseOption(TopicName.START);  // Error

		_convoPlayer.ChooseOption( next_option );

		next_option = null;

		foreach ( var option in _convoPlayer.GetOptions() )
		{
			Debug.Log( "OPTION: " + option._option + " => " + option._nextTopic );

			if ( option._nextTopic == TopicName.END )
			{
				next_option = option;
			}
		}

		_convoPlayer.ChooseOption( next_option );
	}

	public void SaidGoodBye()
	{
		Debug.Log("HE SAID GOODBYE!");
	}

	public void NotGoodbye()
	{
		Debug.Log("He said something nice");
	}
	
}
