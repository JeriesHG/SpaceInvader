using UnityEngine;
using System.Collections;

public class PlayerTouchControl : MonoBehaviour {

//	[HideInInspector]
//	public Rect positionTop;
//	[HideInInspector]
//	public Rect positionBottom;
//	[HideInInspector]
//	public Rect positionLeft;
//	[HideInInspector]
//	public Rect positionRight;
//
//	[HideInInspector]
//	public Color color = new Color(92,92,92,0.5f);
//	
//	void OnGUI (){  
//		positionTop = new Rect (75f, (Screen.height-180f),50f,50f);
//		positionBottom = new Rect (75f, (Screen.height-70f),50f,50f);
//		positionLeft = new Rect (20f, (Screen.height-125f),50f,50f);
//		positionRight = new Rect (130f, (Screen.height-125f),50f,50f);
//		DrawRectangle (positionTop, color,"touchUp"); 
//		DrawRectangle (positionBottom, color,"touchDown"); 
//		DrawRectangle (positionRight, color,"touchRight");   
//		DrawRectangle (positionLeft, color,"touchLeft");   
//	}
//	
//	void DrawRectangle (Rect position, Color color,string name)
//	{    
//		Texture2D texture = new Texture2D(1, 1);
//		texture.SetPixel(0,0,color);
//		texture.Apply();
//		texture.name = name;
//		GUI.skin.box.normal.background = texture;
//		GUI.Box(position, GUIContent.none);
//	}
}
