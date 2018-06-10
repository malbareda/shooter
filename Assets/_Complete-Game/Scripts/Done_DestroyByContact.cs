using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
    public bool divisible;
    public GameObject smaller;
	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

        if (divisible)
        {
            print("ok");
            Vector3 spawnPosition = new Vector3(transform.position.x-1, transform.position.y, transform.position.z-1);
            Instantiate(smaller, spawnPosition, Quaternion.identity);
             spawnPosition = new Vector3(transform.position.x+1, transform.position.y, transform.position.z-1);
            Instantiate(smaller, spawnPosition, Quaternion.identity);
             spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
            Instantiate(smaller, spawnPosition, Quaternion.identity);
            Destroy(other.gameObject);
        }

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
            
        }

		if (other.tag == "Player")
		{
            
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.death();
            Destroy(gameObject);
            if (gameController.gameOver)
            {
                Destroy(other.gameObject);
            }
            return;
        }
		
		gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}