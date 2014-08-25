using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{

		public Camera mainCam;
		public BoxCollider2D topWall;
		public BoxCollider2D bottomWall;
		public BoxCollider2D leftWall;
		public BoxCollider2D rightWall;
		public Player player;
		bool isGameFinished = false;

		void Start ()
		{
				player = GameObject.Find ("Player").GetComponent<Player> ();
				createRandomEnemies ();
				InvokeRepeating ("createRandomEnemies", 3f, Random.Range (5, 15));
				
		}

		// Update is called once per frame
		void Update ()
		{
				setBoundaries ();
				setupKeys ();
				checkIfWon ();
				if (!player && !isGameFinished) {
						GameObject go = Instantiate (Resources.Load ("MessageText")) as GameObject;
						go.GetComponent<GUIText> ().text = "Defeat!";
						isGameFinished = true;
				}
		}

		void setBoundaries ()
		{
				//Move each to its edge location
				topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
				topWall.center = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height, 0f)).y + 0.5f);
			
				bottomWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
				bottomWall.center = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).y - 0.5f);
			
				leftWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
				leftWall.center = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x - 0.5f, 0f);
			
				rightWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
				rightWall.center = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x + 0.5f, 0f);
		}

		void createRandomEnemies ()
		{
				if (!isGameFinished) {
						for (int i = 0; i <Random.Range(3,8); i++) {
								Vector3 pos = new Vector3 (-6 + i, 5, 0) * 1;
								GameObject go = Instantiate (Resources.Load ("BasicEnemy"), pos, Quaternion.identity) as GameObject;
								Enemy enemy = go.GetComponent<Enemy> ();
								enemy.enemyName += "_" + i;
						}
				}
			
		}

		void setupKeys ()
		{
				if (Input.GetKey (KeyCode.Escape)) {
						Application.Quit ();
				}
				if ((Input.GetKey (KeyCode.Return) || Input.touchCount == 1) && isGameFinished) {
						Application.LoadLevel (0);
				}
		}

		void checkIfWon ()
		{
				if (GameObject.FindGameObjectsWithTag ("Enemy").Length <= 0 && !isGameFinished) {
						GameObject go = Instantiate (Resources.Load ("MessageText")) as GameObject;
						go.GetComponent<GUIText> ().text = "Victory!";
						isGameFinished = true;
				}
		}





}
