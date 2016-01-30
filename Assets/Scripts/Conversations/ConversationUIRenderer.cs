using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(ConversationPlayer))]
public class ConversationUIRenderer : MonoBehaviour 
{

	// Transform showing where all the buttons can be placed
	[SerializeField] private RectTransform _buttonSection;
	[SerializeField] private Text _dialogueText;

	[SerializeField] private GameObject _conversationElements;

	[SerializeField] private GameObject _optionButtonPrefab; 

	private ConversationPlayer _convoPlayer;

#region Monobehavior

	void Start()
	{
		_convoPlayer = GetComponent<ConversationPlayer>();

		_convoPlayer._conversationStart.AddListener( () => OnConversationBegin() );
		_convoPlayer._conversationEnd.AddListener( () => OnConversationEnd() );
		_convoPlayer._topicChanged.AddListener( () => OnTopicChange() );

		KillAllButtons();
		_conversationElements.SetActive(false);
	}

#endregion

#region Conversation Event Handlers

	public void OnConversationBegin()
	{
		// enable ui popup
		_conversationElements.SetActive(true);

		_dialogueText.text = _convoPlayer.CurrentDialogue;

		// draw buttons
		KillAllButtons();
		BuildButtons();
	}

	public void OnConversationEnd()
	{
		// close ui popup
		KillAllButtons();

		_conversationElements.SetActive(false);
	}

	public void OnTopicChange()
	{
		_dialogueText.text = _convoPlayer.CurrentDialogue;

		// Re build buttons
		KillAllButtons();
		BuildButtons();
	}

#endregion

#region UI Event Handlers

	public void OnTopicButtonChosen( ConversationOption option )
	{
		// Tell the Conversation Player it's time to change
		_convoPlayer.ChooseOption( option );
	}

#endregion

	public struct OptionWrapper
	{
		public ConversationOption _option;
	}

	void KillAllButtons()
	{
		// foreach child in that section, put them under the curse of destruction
		foreach ( Transform child in _buttonSection )
		{
			Destroy( child.gameObject );
		}
	}

	void BuildButtons()
	{
		foreach ( ConversationOption option in _convoPlayer.GetOptions() )
		{
			// Instantiate new button, set parent as the button section
			var button = Instantiate(_optionButtonPrefab);
			button.transform.SetParent(_buttonSection, false);

			// Set Text
			var text = button.GetComponentInChildren<Text>();
			text.text = option._option;

			var button_comp = button.GetComponent<Button>();

			// Register to button down event
			var wrapper = new OptionWrapper
			{
				_option = option
			};
			// We have to wrap this guy I hope
			button_comp.onClick.AddListener( () => OnTopicButtonChosen( wrapper._option ) );
		}
	}

}
