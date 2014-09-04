using UnityEngine;
using System.Collections;

public class PlayerTouchControl : MonoBehaviour {


	public Rect positionTop = new Rect (100f, 350f,70f,80f);
	public Rect positionBottom = new Rect (100f, 500f,70f,80f);
	public Rect positionLeft = new Rect (120f, 200f,70f,80f);
	public Rect positionRight = new Rect (100f, 350f,70f,80f);

	[HideInInspector]
	public Color color = new Color(92,92,92,0.5f);
	
	void OnGUI (){  
		DrawRectangle (positionTop, color); 
		DrawRectangle (positionBottom, color); 
		DrawRectangle (positionRight, color);   
		DrawRectangle (positionLeft, color);   
	}
	
	void DrawRectangle (Rect position, Color color)
	{    
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
