using UnityEngine;
using System.Collections;

public class HoveringText : MonoBehaviour 
{
	void Start()
	{
		var text = GetComponent<MeshRenderer>();
		text.sortingLayerName = "Default";
		text.sortingOrder = 5;
	}
}
