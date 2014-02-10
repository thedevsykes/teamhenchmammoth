using UnityEngine;
using System.Collections;

public class Highlight : MonoBehaviour
{
	public GameObject[] parts;
	private Color[] defaultColor;
	
	void Start()
	{
		defaultColor = new Color[parts.Length];
		
		if(parts.Length > 0)
		{
			for(int cnt = 0; cnt < defaultColor.Length; cnt++)
			{
				defaultColor[cnt] = parts[cnt].renderer.material.GetColor("_Color");
			}
		}
	}
	
	public void OnMouseEnter()
	{
		Glow(true);	
	}
	
	public void OnMouseExit()
	{
		Glow(false);	
	}
	
	private void Glow(bool glow)
	{
		if(glow)
		{
			if(parts.Length > 0)
			{
				for(int cnt = 0; cnt < defaultColor.Length; cnt++)
				{
					parts[cnt].renderer.material.SetColor("_Color", Color.yellow);
				}
			}
		}
		else
		{
			if(parts.Length > 0)
			{
				for(int cnt = 0; cnt < defaultColor.Length; cnt++)
				{
					parts[cnt].renderer.material.SetColor("_Color", defaultColor[cnt]);
				}
			}
		}
	}
	

}