using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

		//PlayerHandling
		public float speed = 4;
		public int hitpoints = 3;
		public GameObject[] shots;

		//Player Controls
		public KeyCode moveRight;
		public KeyCode moveLeft;
		public KeyCode moveUp;
		public KeyCode moveDown;
		public KeyCode sprint;
		public KeyCode shoot;
		public float startingXPosition = 0;
		public float startingYPosition = -5;
		public int score = 0;

		public void TookDamage ()
		{
				if (hitpoints > 1) {
						this.transform.position = new Vector3 (startingXPosition, startingYPosition, 0);
						hitpoints--;
						score -= 8;
				} else {
						GameObject.FindGameObjectWithTag ("GameManager").gameObject.GetComponent<GameManager> ().playerCurrentScore = score;
						Destroy (gameObject);
				}
		}
}
