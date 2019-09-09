using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
     public Transform obstacle;
     public Transform ground;
     public Transform player;
         void  Start(){
         	//print("start");
         	Debug.Log(player.transform.position.y);
         	Vector3 position = new Vector3(Random.Range(ground.position.x-(ground.localScale.x/2), ground.position.x+(ground.localScale.x/2)), obstacle.position.y, Random.Range(player.position.z+5F,player.position.z+5.5F));
     	//Vector3 position = new Vector3(4F, 0F, player.position.z);
     for(int i=0; i<5; i++){
     	//Debug.Log(i+"\n");
     	//var currentPosition =  GameObject.Find("player");
     	//for(int j=0;j<1000000000;j++);
        //Debug.Log(i+ " Position" + currentPosition.transform.position);
  
        // Debug.Log(i+" "+GameObject.Find("player").transform.position.y+"\n");
        //Instantiate (obstacle, position, Quaternion.identity);
     }
         	
 }
         void OnTriggerEnter(Collider collider){
         if (collider.gameObject.name == "player") {
             Destroy (this.gameObject);
            //SpawnCube();
             
         }
     }
}
