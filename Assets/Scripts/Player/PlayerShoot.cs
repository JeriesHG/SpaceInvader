using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

		private Player player;

		void Start ()
		{
				player = GameObject.Find ("Player").GetComponent<Player> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				ShootBullet ();
		}
	
		void ShootBullet ()
		{
				if (Input.GetKeyDown (player.shoot) || Input.touchCount == 1) {
						int ammoIndex = 0;
						float playerPosY = player.transform.position.y + 0.7f;
						Vector3 newVector = new Vector3 (player.transform.position.x, playerPosY);
						GameObject shot = (GameObject)Instantiate (player.shots [ammoIndex], newVector, Quaternion.identity);
						shot.rigidbody2D.velocity = 5 * Vector3.up;
				}


		}
}
