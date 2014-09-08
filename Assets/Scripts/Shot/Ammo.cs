using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{

		public Shot shot;
		public int clipSize;
		public int shotsLeft;
		public bool infinite;
		

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
