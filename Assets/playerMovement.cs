using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody Rb;
    public float forwardForce;
	public float sidewayForce;
    //public ground gground = GameObject.getGameObject("ground");
	//public GameObject gground;
	public Transform ground;
	
	
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        int nbTouches = Input.touchCount;
		//gground =GameObject.Find("Ground");
		//float gSizex = gground.gameObject.GetComponent<Renderer>().bounds.size.x;

        if (nbTouches > 0)
        {
            print(nbTouches + " touch(es) detected");

            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);

                print("Touch index " + touch.fingerId + " detected at position " + touch.position);
               // if (touch.position.x >= ((gground.transform.position.x+gSizex)/2))
				    if (touch.position.x >= ((ground.position.x+ground.localScale.x)/2))
                    Rb.AddForce(sidewayForce * nbTouches, 0, forwardForce * Time.deltaTime);
                else
                    Rb.AddForce(-sidewayForce * nbTouches, 0, forwardForce * Time.deltaTime);
            }
        }
        else
            Rb.AddForce(0, 0, forwardForce * Time.deltaTime);


    }
}
