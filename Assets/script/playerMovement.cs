using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody Rb;
    public Transform Water;
    public static float forwardForce = 1200;
    //public float sidewayForce;
    //public float oppsidewayForce;
    public Transform player;
    public Transform Snow;
	//public Transform ground;
    //public Transform ground1;
    //public Transform ground2;
    public GameObject GameOver;
    public int jumpCnt=0;

	
	
    // Start is called before the first frame update
    void Start()
    {

    }

   void FixedUpdate()
    {

        int nbTouches = Input.touchCount;
        Rb.AddForce(0, 0, forwardForce * Time.deltaTime);

    }

    void Update () {
        GameOver.SetActive(false);
        //print(forwardForce);
        Water.transform.position = new Vector3(Water.transform.position.x,Water.transform.position.y,player.transform.position.z);
        Snow.transform.position = new Vector3(Snow.transform.position.x,player.transform.position.y+7,player.transform.position.z+5);
        /*float plY = player.transform.position.y;
        if(plY==1.0f && jumpCnt ==1)
        {
            jumpCnt=0;
        }*/
        int nbTouches = Input.touchCount;
        if (nbTouches > 0)
        {
            //print(nbTouches + " touch(es) detected");

            Touch touch = Input.GetTouch(0);

            //print("Touch index " + touch.fingerId + " detected at position " + touch.position);
            //print("Screen Width: "+Screen.width+"\n");
            //print("Screen height: "+Screen.height+"\n");
			if (touch.position.x >= Screen.width/2 && touch.position.y<=9*Screen.height/25){
                //print("left\n");
                //Rb.AddForce(new Vector3(0, 3 , 0),ForceMode.Impulse);
                player.transform.position = new Vector3(player.transform.position.x+0.5f,player.transform.position.y,player.transform.position.z);
            }
            else if (touch.position.x <Screen.width/2 && touch.position.y<=9*Screen.height/25){
                //print("right\n");
                player.transform.position = new Vector3(player.transform.position.x-0.5f,player.transform.position.y,player.transform.position.z);
            }
            else if(touch.position.x >= Screen.width/4 && touch.position.x <= 3*Screen.width/4 && touch.position.y>9*Screen.height/25){
                //print("up\n");
                forwardForce = 300.0f;
                Rb.AddForce(new Vector3(0, 0 , forwardForce * Time.deltaTime));
                Rb.AddForce(new Vector3(0, 2 , 0),ForceMode.Impulse);
                forwardForce = 1200.0f;
                Rb.AddForce(new Vector3(0, 0 , forwardForce * Time.deltaTime));
                //jumpCnt++;
            }
        }

     }
     
     
}
