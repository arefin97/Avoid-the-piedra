using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{

   public Transform player;
   public Text text;

    private int currentscore=0;
 
     // Use this for initialization
     void Start () {
         text = gameObject.GetComponent<Text>(); 
         text.text="SCORE : " + currentscore;
     }

    void Update()
    {
    	//print("TEXT");
        //scoreText.text=player.position.z.ToString("0");
        text.text="SCORE : " + currentscore;  
        currentscore = (int) player.transform.position.z; 
    }
}
