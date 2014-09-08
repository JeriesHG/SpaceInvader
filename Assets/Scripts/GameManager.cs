using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
		public int playerCurrentScore;
		Player player;
		bool isGameFinished = false;

		void Start ()
		{
				player = GameObject.Find ("Player").GetComponent<Player> ();
//				createRandomEnemies ();
//				InvokeRepeating ("createRandomEnemies", 3f, Random.Range (5, 15));
		}
	
		// Update is called once per frame
		void Update ()
		{
				initiateKeys ();
				checkGameState ();
			
		}
		void OnGUI ()
		{
				if (playerCurrentScore < 1) {
						playerCurrentScore = 0;
				}
		
				GUI.Label (new Rect (Screen.width / 2, 20, 100, 100), "Score: " + playerCurrentScore);
		}

		void checkGameState ()
		{
				if (GameObject.FindGameObjectsWithTag ("Enemy").Length <= 0 && !isGameFinished) {
						GameObject go = Instantiate (Resources.Load ("Text/MessageText")) as GameObject;
						go.GetComponent<GUIText> ().text = "Victory!";
						isGameFinished = true;
				}
				if (!player && !isGameFinished) {
						GameObject go = Instantiate (Resources.Load ("Text/MessageText")) as GameObject;
						go.GetComponent<GUIText> ().text = "Defeat!";
						isGameFinished = true;
				}
		}

		void createRandomEnemies ()
		{
				if (!isGameFinished) {
						for (int i = 0; i <Random.Range(3,8); i++) {
								Vector3 pos = new Vector3 (-6 + i, 5, 0) * 1;
								GameObject go = Instantiate (Resources.Load ("Enemies/BasicEnemy"), pos, Quaternion.identity) as GameObject;
								Enemy enemy = go.GetComponent<Enemy> ();
								enemy.enemyName += "_" + i;
						}
				}
		
		}

		void initiateKeys ()
		{
				if ((Input.GetKey (KeyCode.Return) || Input.touchCount == 1) && isGameFinished) {
						Application.LoadLevel (0);
				}
		}

}
