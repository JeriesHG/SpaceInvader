using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

		private Player player;
		private float lastFire;

		void Start ()
		{
				player = GameObject.Find ("Player").GetComponent<Player> ();
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				executeShoot ();
		}
	
		void executeShoot ()
		{
				if (Input.GetKey (player.shoot) && Time.time > lastFire) {
						Weapon selectedAmmo = ((GameObject)player.weapons [player.selectedWeapon]).GetComponent<Weapon> ();
						if (selectedAmmo.infinite || selectedAmmo.shotsLeft >= 1) {
								StartCoroutine (Fire (selectedAmmo));
						} else {
								//if there are no bullets it will look for a weapon with bullets
								LookForWeapon ();
								StartCoroutine (Fire (selectedAmmo));
						}
						lastFire = Time.time + selectedAmmo.fireRate;
				}
						
		}

		IEnumerator Fire (Weapon selectedAmmo)
		{
				float spreadRange = selectedAmmo.bulletSpread / 2f;
				for (int i = 0; i<selectedAmmo.bulletCount; i++) {
						yield return new WaitForSeconds (0);
//						float variance = Random.Range (-spreadRange, spreadRange);
//						Quaternion rotation = Quaternion.AngleAxis (variance, transform.up);
						Vector3 newVector = transform.position;
//						newVector.x += i / selectedAmmo.bulletSpread * 10;
						newVector.y = player.transform.position.y + player.GetComponent<BoxCollider2D> ().size.y;
						Bullet bullet = (Bullet)Instantiate (selectedAmmo.bullet, newVector, Quaternion.identity);
						bullet.rigidbody2D.velocity = bullet.bulletSpeed * Vector2.up;
						audio.PlayOneShot (selectedAmmo.shootSound);
				}
			
			
				if (!selectedAmmo.infinite) {
						selectedAmmo.shotsLeft--;
				}
				
				
		}

		public Weapon LookForWeapon ()
		{
				for (int i = 0; i<player.weapons.Count; i++) {
						if (player.weapons [i]) {
								Weapon curAmmo = player.weapons [i].GetComponent<Weapon> ();
								if (curAmmo.shotsLeft >= 1 || curAmmo.infinite) {
										player.selectedWeapon = i;
										return curAmmo;
								}
						}
				}
				return null;
		}


}
