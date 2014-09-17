using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

		public string enemyName = "";
		public double hitpoints = 5f;
		public int pointsWorth = 0;
		public float moveSpeed = 2f;
		public List<GameObject> weapons;
		public int defaultAmmo = 0;
		public float startingXPosition = -6f;
		public float startingYPosition = 5f;
		public float maxShotInterval = 1f;

		float moveDirection = 1.0f;
		Vector3 moveAmount;

		private Weapon currentWeapon;
		[HideInInspector]
		public int
				selectedWeapon = 0;

		// Use this for initialization
		void Start ()
		{
				weapons = new List <GameObject> ();
				weapons.Add ((GameObject)Instantiate (Resources.Load ("Weapons/weapon_enemyBasic1") as GameObject));
				InvokeRepeating ("EnemyShoot", Random.Range (0f, 1f), Random.Range (0.5f, maxShotInterval));
		}
	
		// Update is called once per frame
		void Update ()
		{
				moveAmount.x = moveDirection * moveSpeed * Time.deltaTime;
				transform.Translate (moveAmount);
		}

		void OnCollisionEnter2D (Collision2D Entity)
		{
				Vector3 curPosition = gameObject.transform.position;
				curPosition.y -= 0.8f;
				if (Entity.gameObject.tag.Contains ("Wall")) {
						gameObject.transform.position = curPosition;
				}
				switch (Entity.gameObject.tag) {
				case "Player":
						Player player = Entity.gameObject.GetComponent<Player> ();
						player.TookDamage (1);
						Damaged (1);
						break;
				case "LeftWall":
						moveDirection = 1f;
						break;
				case "RightWall":
						moveDirection = -1f;
						break;
				case "BottomWall":
						Destroy (gameObject);
						break;
				}
		}

		public bool Damaged (double damage)
		{
				hitpoints -= damage;
				if (hitpoints < 1) {
						Destroy (gameObject);
						return true;
				}
				return false;
		}

		void EnemyShoot ()
		{
				currentWeapon = ((GameObject)weapons [selectedWeapon]).GetComponent<Weapon> ();
				for (int i = 0; i<currentWeapon.bulletCount; i++) {
						Quaternion target = Quaternion.identity;
						target.eulerAngles = new Vector3 (currentWeapon.bullet.bulletSpeed, currentWeapon.bulletSpread * (i - 1.8f));
						Vector3 newVector = transform.position;
						newVector.y = transform.position.y - GetComponent<BoxCollider2D> ().size.y;
						Bullet bullet = (Bullet)Instantiate (currentWeapon.bullet, newVector, target);
						bullet.enemyBullet = true;
						bullet.rigidbody2D.AddForce (bullet.transform.forward * bullet.bulletSpeed);
				}
		}
}
