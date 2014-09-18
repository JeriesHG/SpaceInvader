using UnityEngine;
using System.Collections;

public class PickableBehaviour : MonoBehaviour
{
		public float timeLast = 5;

		void Start ()
		{
				Destroy (gameObject, timeLast);
				gameObject.transform.position = new Vector2 (Random.Range (0, Camera.main.ScreenToWorldPoint (new Vector3 (0f, Screen.height, 0f)).y + 0.5f), Screen.height / 100);
				int randomNumber = Random.Range (0, 2);
				if (randomNumber <= 0.5) {
						rigidbody2D.AddForce (new Vector2 (Random.Range (0, 80), Random.Range (0, 10)));
				} else {
						rigidbody2D.AddForce (new Vector2 (-Random.Range (0, 80), -Random.Range (0, 10)));
				}
		}
		void Update ()
		{

		}
		void OnCollisionEnter2D (Collision2D colInfo)
		{
				
		}

}
