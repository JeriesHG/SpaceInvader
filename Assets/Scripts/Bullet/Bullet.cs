using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

		public double damage = 1;
		public int bulletSpeed = 4;
		public bool enemyBullet = false;
		public AudioClip shootSound;

		// Use this for initialization
		void Start ()
		{
				Destroy (gameObject, 30);
		}
	
		void OnTriggerEnter2D (Collider2D entity)
		{
				switch (entity.gameObject.tag) {
				case "Shot":
						break;
				case "Enemy":
						if (!enemyBullet) {
								Enemy enemy = entity.gameObject.GetComponent<Enemy> ();
								if (enemy.Damaged (damage) && GameObject.Find ("Player")) {
										GameObject.Find ("Player").GetComponent<Player> ().score += enemy.pointsWorth;
										GameObject.Find ("Player").GetComponent<Player> ().updateScore ();
								}
								Destroy (gameObject);
						}
		
						break;
				case "Player":
						if (enemyBullet) {

								Player player = entity.gameObject.GetComponent<Player> ();
								player.TookDamage (damage);
								Destroy (gameObject);
						}
						break;
				}
				if (entity.gameObject.tag.ToLower ().Contains ("wall")) {
						Destroy (gameObject);
				}
		}

		void OnBecameInvisible ()
		{
				// Destroy the bullet 
				Destroy (gameObject);
		}


}
