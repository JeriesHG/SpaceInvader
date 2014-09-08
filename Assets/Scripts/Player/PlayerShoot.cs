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
						Ammo selectedAmmo = ((GameObject)player.weapons [player.selectedAmmo]).GetComponent<Ammo> ();
						if (selectedAmmo.infinite || selectedAmmo.shotsLeft >= 1) {
								Fire (selectedAmmo);
						} else {
								LookForAmmo ();
						}

				}
						
		}

		void Fire (Ammo selectedAmmo)
		{
				float playerPosY = player.transform.position.y + 0.7f;
				Vector3 newVector = new Vector3 (player.transform.position.x, playerPosY);
				Shot shot = (Shot)Instantiate (selectedAmmo.shot, newVector, Quaternion.identity);
				shot.rigidbody2D.velocity = shot.shotSpeed * Vector3.up;
				selectedAmmo.shotsLeft--;
		}

		void LookForAmmo ()
		{
				for (int i = 0; i<player.weapons.Count; i++) {
						if (player.weapons [i]) {
								Ammo curAmmo = player.weapons [i].GetComponent<Ammo> ();
								if (curAmmo.shotsLeft >= 1) {
										player.selectedAmmo = i;
										Fire (curAmmo);
										break;
								}
						}
				}
		}


}
