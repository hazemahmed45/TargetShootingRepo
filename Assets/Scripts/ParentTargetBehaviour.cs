using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentTargetBehaviour : MonoBehaviour {

	Vector3 leftPos,rightPos;
	float xRange=10f;
	float lerpValue=1f;
	bool lerp=false;
	PlayerShootBehaviour playerShootBehaviour;
	void Start()
	{
		playerShootBehaviour=GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerShootBehaviour>();
		leftPos=new Vector3(transform.position.x-xRange,transform.position.y,transform.position.z);
		rightPos=new Vector3(transform.position.x+xRange,transform.position.y,transform.position.z);
	}

	void Update()
	{
		if(playerShootBehaviour.score>=1000)
		{

			if(lerp)
			{
				transform.position=Vector3.Lerp(transform.position,leftPos,lerpValue*Time.deltaTime);
				if(transform.position.x<=leftPos.x+0.5f)
				{
					lerp=false;
				}
			}
			else
			{
				transform.position=Vector3.Lerp(transform.position,rightPos,lerpValue*Time.deltaTime);
				if(transform.position.x>=rightPos.x-0.5f)
				{
					lerp=true;
				}
			}
		}
	}
}
