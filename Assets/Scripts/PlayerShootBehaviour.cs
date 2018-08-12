using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootBehaviour : MonoBehaviour {

	public GameObject bullet,bulletRespawn;
	public LayerMask layerMask;
	// Use this for initialization
	public Text scoreText;
	public int score;
	public AudioSource gunShotAudio;
	void Start()
	{
		score=0;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			//Instantiate(bullet,bulletRespawn.transform.position,bulletRespawn.transform.rotation);
			if(score>3000)
			{
				scoreText.text="YOU WON";
			}
			else
			{
				RaycastHit hit;
				gunShotAudio.Play();
				if(Physics.Raycast(bulletRespawn.transform.position,bulletRespawn.transform.forward,out hit,1000f,layerMask))
				{
					
					GameObject bullObject= Instantiate(bullet,hit.point,hit.collider.transform.rotation);
					StartCoroutine(waitForBulletToDestroy(bullObject));
					GameObject target=hit.collider.gameObject;
					score +=target.GetComponent<TargetBehaviour>().targetScore;
					scoreText.text="your score: "+score;
					Debug.Log("Score increased by "+score);
					//Debug.Log(hit.collider.name+" "+hit.collider.transform.position);
				
				}
			}
		}
		//or
		// if(Input.GetMouseButtonDown(0))
		// {
		// 	Debug.Log("HERE");
		// }
	}
	IEnumerator waitForBulletToDestroy(GameObject bull)
	{
		yield return new WaitForSeconds(5);
		Destroy(bull);
	}
}
