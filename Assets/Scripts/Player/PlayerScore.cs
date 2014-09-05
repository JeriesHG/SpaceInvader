using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour
{

		private Player player;
	
		void Start ()
		{
				player = GameObject.Find ("Player").GetComponent<Player> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnGUI ()
		{
				if (player.score < 1) {
						player.score = 0;
				}
				
				GUI.Label (new Rect (Screen.width / 2, 20, 100, 100), "Score: " + player.score);
		}
}
