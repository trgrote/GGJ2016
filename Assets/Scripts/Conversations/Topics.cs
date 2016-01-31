using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

public enum TopicName
{
	// Special Topics
	START,
	END,

	TEST1,

	ACTIVATE_WATER_PUMP,

	Deb_A,
	Deb_B,
	Deb_C,

	// Goddess of Life
	GOL_Continue1,
	GOL_Continue2,
	GOL_Continue3,

	// Goddess of War and Man
	GOW_Continue1,
	GOW_Continue2,
	GOW_Continue3,

	// Goddess of Balance ( Buddha )
	GOB_Continue1,
	GOB_Continue2,
	GOB_Continue3,

}

[Serializable]
public class Topic 
{
	public TopicName _topicName;

	[MultilineAttribute(4)]
	public string _dialogue;

	public ConversationOption[] _options = new ConversationOption[0];
}

[Serializable]
public class ConversationOption
{
	public string _option;
	public TopicName _nextTopic;
	public UnityEvent _optionChosen;

	public void OnOptionChosen()
	{
		if ( _optionChosen != null )
			_optionChosen.Invoke();
	}
}

public class Topics : MonoBehaviour
{
	public Topic[] _topics;

	void Reset()
	{
		_topics = new[]
		{
			new Topic
			{ 
				_topicName = TopicName.START, 
				_dialogue = "Hello Guv'na", 
				_options = new []
				{ 
					new ConversationOption{ _option = "Good Bye", _nextTopic = TopicName.END }
				} 
			}
		}; 
	}
}
