using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetect : MonoBehaviour
{
	public playerMovement movement;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisionInfo)    {
        if(collisionInfo.collider.tag=="Obstacle"){
        	print("paisi");
        	var currentPosition =  GameObject.Find("player");
        	 Debug.Log(" Position" + currentPosition.transform.position);
        	//movement.enable=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
