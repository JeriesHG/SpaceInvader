using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public int damage = 1;
	public int shotSpeed = 4;
	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 30);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D entity)
	{
		switch (entity.gameObject.tag) {
		case "Shot":
			Destroy (gameObject);
			break;
		case "Enemy":
			if(!isEnemyShot){
				Enemy enemy = entity.gameObject.GetComponent<Enemy>();
				if(enemy.Damaged()){
					GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().score+=enemy.pointsWorth;

				}
				Destroy (gameObject);
			}
		
			break;
		case "Player":
			Player player = entity.gameObject.GetComponent<Player>();
			player.TookDamage();
			Destroy (gameObject);
			break;
		}
		if(entity.gameObject.tag.ToLower().Contains("wall")){Destroy(gameObject);}
//		Destroy (gameObject);
	}


}
