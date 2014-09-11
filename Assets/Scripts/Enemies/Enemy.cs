using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

		public string enemyName = "";
		public double hitpoints = 5f;
		public int pointsWorth = 0;
		public float moveSpeed = 2f;
		public GameObject[] shots;
		public int defaultAmmo = 0;
		public float startingXPosition = -6f;
		public float startingYPosition = 5f;
		public float maxShotInterval = 1f;

		float moveDirection = 1.0f;
		Vector3 moveAmount;

		// Use this for initialization
		void Start ()
		{
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
				float playerPosY = gameObject.transform.position.y - 0.5f;
				GameObject shot = (GameObject)Instantiate (gameObject.GetComponent<Enemy> ().shots [defaultAmmo], new Vector3 (gameObject.transform.position.x, playerPosY), Quaternion.identity);
				Bullet bullet = shot.GetComponent<Bullet> ();
				bullet.enemyBullet = true;
				shot.rigidbody2D.velocity = bullet.bulletSpeed * Vector3.down;
		}
}
