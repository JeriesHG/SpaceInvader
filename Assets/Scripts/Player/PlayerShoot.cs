using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

		private Player player;
		private float lastFire;
		private Weapon selectedWeapon;

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
						selectedWeapon = ((GameObject)player.weapons [player.selectedWeapon]).GetComponent<Weapon> ();
						if (selectedWeapon.infinite || selectedWeapon.shotsLeft >= 1) {
								StartCoroutine (Fire ());
						} else {
								//if there are no bullets it will look for a weapon with bullets
								LookForWeapon ();
								StartCoroutine (Fire ());
						}
						lastFire = Time.time + selectedWeapon.fireRate;
				}
						
		}

		IEnumerator Fire ()
		{
				yield return new WaitForSeconds (0);
				switch (selectedWeapon.weaponType) {
				case Weapon.WeaponType.Default:
						doDefaultWeapon ();
						break;
				case Weapon.WeaponType.Shotgun:
						doShotgun ();
						break;
				}

				audio.PlayOneShot (selectedWeapon.shootSound);
				if (!selectedWeapon.infinite) {
						selectedWeapon.shotsLeft--;
				}
				
				
		}
		void doDefaultWeapon ()
		{
				for (int i = 0; i<selectedWeapon.bulletCount; i++) {
						Vector3 newVector = transform.position;
						newVector.y = player.transform.position.y + player.GetComponent<BoxCollider2D> ().size.y;
						Bullet bullet = (Bullet)Instantiate (selectedWeapon.bullet, newVector, Quaternion.identity);
						bullet.rigidbody2D.AddForce (bullet.transform.up * bullet.bulletSpeed);
			
				}
		}
		void doShotgun ()
		{
				for (int i = 0; i<selectedWeapon.bulletCount; i++) {
						Quaternion target = Quaternion.identity;
						target.eulerAngles = new Vector3 (-selectedWeapon.bullet.bulletSpeed, selectedWeapon.bulletSpread * (i - 1.8f));
						Vector3 newVector = transform.position;
						newVector.y = player.transform.position.y + player.GetComponent<BoxCollider2D> ().size.y;
						Bullet bullet = (Bullet)Instantiate (selectedWeapon.bullet, newVector, target);
						bullet.rigidbody2D.AddForce (bullet.transform.forward * bullet.bulletSpeed);
				}
		}
	
		public Weapon LookForWeapon ()
		{
				for (int i = 0; i<player.weapons.Count; i++) {
						if (player.weapons [i]) {
								Weapon curWeapon = player.weapons [i].GetComponent<Weapon> ();
								if (curWeapon.shotsLeft >= 1 || curWeapon.infinite) {
										player.selectedWeapon = i;
										return curWeapon;
								}
						}
				}
				return null;
		}

	
}
