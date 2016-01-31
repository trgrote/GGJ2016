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

	BS_A,
	BS_B,
	BS_C,

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
