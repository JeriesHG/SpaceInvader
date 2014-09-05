using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

		//PlayerHandling
		public float speed = 4;
		public int hitpoints = 3;
		public GameObject[] shots;

		//Player Controls
		public KeyCode moveRight = KeyCode.RightArrow;
		public KeyCode moveLeft = KeyCode.LeftArrow;
		public KeyCode moveUp = KeyCode.UpArrow;
		public KeyCode moveDown = KeyCode.DownArrow;
		public KeyCode sprint = KeyCode.LeftShift;
		public KeyCode shoot = KeyCode.Space;
		public float startingXPosition = 0;
		public float startingYPosition = -5;
		public int score = 0;
		bool playerInvulnerability;


		public Player ()
		{
		}

		public void TookDamage (int damage)
		{
				if (!playerInvulnerability) {
						playerInvulnerability = true;
						if (hitpoints > 1) {
				
								hitpoints--;
								score -= damage;
								GameObject.FindGameObjectWithTag ("GameManager").gameObject.GetComponent<GameManager> ().playerCurrentScore = score;
								StartCoroutine (Die (false));
						} else {
								StartCoroutine (Die (true));
						}
				}

				
		}



		IEnumerator Die (bool destroyObject)
		{
				gameObject.GetComponent<Animator> ().SetBool ("Destroy", true);
				ImmobilizePlayer ();
				yield return new WaitForSeconds (1); 
				if (destroyObject) {
						Destroy (this.gameObject); 
				} else {
						StartCoroutine (RespawnPlayer ());
				}
				gameObject.GetComponent<Animator> ().SetBool ("Destroy", false);
		}

		void ImmobilizePlayer ()
		{
				Destroy (gameObject.GetComponent<PlayerMovement> ());
				Destroy (gameObject.GetComponent<PlayerShoot> ());
		}

		IEnumerator RespawnPlayer ()
		{
				gameObject.GetComponent<Animator> ().SetBool ("Invulnerable", true);
				this.transform.position = new Vector3 (startingXPosition, startingYPosition, 0);
				gameObject.AddComponent ("PlayerMovement");
				gameObject.AddComponent ("PlayerShoot");
				yield return new WaitForSeconds (2);
				gameObject.GetComponent<Animator> ().SetBool ("Invulnerable", false);
				playerInvulnerability = false;

		}


}
