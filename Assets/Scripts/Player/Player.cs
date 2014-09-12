using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

		//PlayerHandling
		public float speed = 4;
		public double hitpoints = 3;
		public List<GameObject> weapons;

		//Player Controls
		public KeyCode moveRight = KeyCode.RightArrow;
		public KeyCode moveLeft = KeyCode.LeftArrow;
		public KeyCode moveUp = KeyCode.UpArrow;
		public KeyCode moveDown = KeyCode.DownArrow;
		public KeyCode sprint = KeyCode.LeftShift;
		public KeyCode shoot = KeyCode.Space;
		public KeyCode changeWeapon = KeyCode.E;
		public float startingXPosition = 0;
		public float startingYPosition = -5;
		public int score = 0;
		public AudioClip deathSound;
		bool playerInvulnerability;

		[HideInInspector]
		public int
				selectedWeapon = 0;


		void Awake ()
		{
				weapons = new List <GameObject> ();
				weapons.Add ((GameObject)Instantiate (Resources.Load ("Weapons/weapon_default") as GameObject));
				weapons.Add ((GameObject)Instantiate (Resources.Load ("Weapons/weapon_basic1") as GameObject));
		}

		public void TookDamage (double damage)
		{
				if (!playerInvulnerability) {
						playerInvulnerability = true;
						if (hitpoints > 1) {
								hitpoints -= 1;
								score -= (int)damage;
								updateScore ();
								StartCoroutine (Die (false));
						} else {
								StartCoroutine (Die (true));
						}
				}

				
		}

		public void updateScore ()
		{
				GameObject.FindGameObjectWithTag ("GameManager").gameObject.GetComponent<GameManager> ().playerCurrentScore = score;
		}



		IEnumerator Die (bool destroyObject)
		{
				gameObject.GetComponent<Animator> ().SetBool ("Destroy", true);
				ImmobilizePlayer ();
				audio.PlayOneShot (deathSound);
				yield return new WaitForSeconds (deathSound.length); 
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
