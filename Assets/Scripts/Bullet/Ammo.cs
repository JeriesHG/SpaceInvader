using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{

		public Bullet bullet;
		public int clipSize;
		public int shotsLeft;
		public bool infinite;
		public int bulletCount = 2;
		public float bulletRandomness;
		public float bulletSpread;
		public float bulletSpacing;
		public float fireRate;
		

		// Use this for initialization
		void Start ()
		{
				clipSize = shotsLeft;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
