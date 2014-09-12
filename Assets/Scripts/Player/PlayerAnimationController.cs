using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

	
	private Player player;
	private Animator playerAnim;
	private float x;
	
	void Start ()
	{
		player = GameObject.Find ("Player").GetComponent<Player> ();
		playerAnim = GetComponent<Animator> ();
		//Getting Sprite localScale
		x = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		RunAnimation ();
	}
	
	
	void RunAnimation ()
	{
		if (Input.GetKey (player.moveLeft)) {
			transform.localScale = new Vector3 (x, x, x);
			playerAnim.SetFloat ("Move", 1.0f);
		} else if (Input.GetKey (player.moveRight)) {
			transform.localScale = new Vector3 (-x, x, x);
			playerAnim.SetFloat ("Move", 1.0f);
		} else {
			playerAnim.SetFloat ("Move", 0.0f);
		}
	}
}
