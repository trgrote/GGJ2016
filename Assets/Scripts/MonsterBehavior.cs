using UnityEngine;
using System.Collections;

using UnityStandardAssets._2D;

[RequireComponent(typeof (PlatformerCharacter2D))]
public class MonsterBehavior : MonoBehaviour 
{
	private PlatformerCharacter2D m_Character;
	private bool m_Jump;

	private bool _stunned = false;

	Transform _player = null;

	float _currentDirection = -1;

	public void Kill()
	{
		// kill Monster
	}

	public void Stun()
	{

	}

	private void Awake()
	{
		m_Character = GetComponent<PlatformerCharacter2D>();
	}

	private void Start()
	{
		_player = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	    // Read the inputs.
	    // Pass all parameters to the character control script.
	    m_Character.Move(_currentDirection, false, false);
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		if ( other.CompareTag("MonsterBoundary"))
		{
			_currentDirection = -_currentDirection;
		}
	}
}