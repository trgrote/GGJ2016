using UnityEngine;
using System.Collections;

public class ScrollingTexture : MonoBehaviour 
{
	[SerializeField] float speed = 1.0f;
	
	private Renderer render;

	void Start()
	{
		render = GetComponent<Renderer>();

		render.sortingLayerName = "Default";
		render.sortingOrder = 4;
	}

	// Update is called once per frame
	void Update () 
	{
		Vector2 new_offset = render.material.mainTextureOffset;
		new_offset.y += Time.deltaTime * speed;
		render.sharedMaterial.mainTextureOffset = new_offset;
	}
}
