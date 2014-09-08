using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

		private Player player;
	
		void Start ()
		{
				player = GameObject.Find ("Player").GetComponent<Player> () as Player;
		}

		void FixedUpdate ()
		{
				Move ();
//				changeWeapon ();
		}
	
		void Move ()
		{
				float movementSpeed = player.speed;
				if (Input.GetKey (player.sprint)) {
						movementSpeed = player.speed * 2;		
				}
				if (Input.GetKey (player.moveLeft) || Input.GetKey (player.moveRight)) {
						transform.Translate (Input.GetAxisRaw ("Horizontal") * movementSpeed * Time.deltaTime, 0, 0);
				}
				if (Input.GetKey (player.moveUp) || Input.GetKey (player.moveDown)) {
						transform.Translate (0, Input.GetAxisRaw ("Vertical") * movementSpeed * Time.deltaTime, 0);
				}

		}

//		void changeWeapon ()
//		{
//				if (Input.GetKeyUp (player.changeWeapon)) {
//						if (player.shots [(player.selectedAmmo + 1)] != null) {
//								player.selectedAmmo += 1;
//						} else {
//								player.selectedAmmo = (player.selectedAmmo > 0) ? player.selectedAmmo -= 1 : 0;
//						}
//				}
//		}


}
