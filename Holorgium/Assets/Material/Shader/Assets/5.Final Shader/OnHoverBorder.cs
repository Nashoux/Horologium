using UnityEngine;

public class OnHoverBorder : MonoBehaviour
{

	[SerializeField] Renderer rend;
	public Material border;
	public Material nonBorder;

	void OnMouseOver()
	{
		rend.material = border;
	}

	void OnMouseExit()
	{
		rend.material = nonBorder;
	}
}
