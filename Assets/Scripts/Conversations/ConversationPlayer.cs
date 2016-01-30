using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ConversationPlayer : MonoBehaviour
{
	public class ConversationState
	{
		public Topic[] _topics;
		public TopicName _currentTopicName;
		public Topic _currentTopic;
	}

	ConversationState _state = new ConversationState();

	public void StartConversation( Topic[] topics )
	{
		// Verify topics we gave us aren't bunk
		// need to have a start topic
		// and the start topic needs to have options
		Topic start = null;

		foreach ( Topic topic in topics )
		{
			if ( topic._topicName == TopicName.START )
			{
				start = topic;
				break;
			}
		}

		if ( start == null )
		{
			Debug.LogError("Topics don't contain a START topic!");
			return;
		}

		_state = new ConversationState
		{ 
			_topics = topics,
			_currentTopicName = TopicName.START,
			_currentTopic = start
		};
	}

	public string CurrentDialogue
	{
		get 
		{
			return _state._currentTopic._dialogue;
		}
	}

	// Player Responded, set the next topic
	public void ChooseOption( ConversationOption option )
	{
		TopicName next_topic_name = option._nextTopic;

		// Special Handling for END
		if ( next_topic_name == TopicName.END )
		{
			option.OnOptionChosen();

			// End Topic
			OnConversationEnd();
			_state = null;
			return;
		}

		// don't do anything, just a warning, if the topic they chose doesn't exist as a valid option
		bool found = false;
		foreach ( ConversationOption curr_option in _state._currentTopic._options )
		{
			if ( curr_option == option )
			{
				found = true;
				break;
			}
		}

		if ( ! found )
		{
			Debug.LogError("TOPIC IS NOT A VALID OPTION: " + next_topic_name);
			return;
		}

		// Make sure there is a mapping to this topic name in our topics collection
		Topic next_topic = null;

		foreach ( Topic topic in _state._topics )
		{
			if ( topic._topicName == next_topic_name )
			{
				next_topic = topic;
				break;
			}
		}

		if ( next_topic == null )
		{
			Debug.LogError("FAILED TO FIND FIND TOPIC IN TOPIC NAME: " + next_topic_name );
			return;
		}

		// Trigger Event
		option.OnOptionChosen();

		// Update State
		_state._currentTopicName = next_topic_name;
		_state._currentTopic = next_topic;
	} 

	// Used by the COnversation renderer to build all the 
	public ConversationOption[] GetOptions()
	{
		return _state != null && _state._currentTopic != null ? 
			_state._currentTopic._options : 
			new ConversationOption[0];
	}

	public event Action ConversationEnd = delegate{};

	protected void OnConversationEnd()
	{
		ConversationEnd();
	}
}
