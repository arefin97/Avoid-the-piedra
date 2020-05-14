using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlManager : MonoBehaviour
{
    public playerMovement movement;

    public AudioClip crash;
    public AudioClip drop;
    
    private AudioSource source;

    public TextMeshProUGUI textOutside;
    public TextMeshProUGUI waitingText;

    public GameObject GameOver;
    public GameObject GamePanel;
    public GameObject PausePanel;

    public GameObject player;
    public GameObject Obstacle;
    public int n;
    public int f = 0;

    //public TextMeshProUGUI textOutside;
    //public TouchDetect touchDetect;
    public Button pauseButton;
    //public float speedUpSeconds = 5f;


    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 0;
        n = 3;
        //waitingAndStart();  
    }

    // Update is called once per frame
    void Update()
    {
        if(f==0){
            waitingAndStart(n);
            n--;
            if(n<-1){
                n=3;f=1;
            }
        }

       // floating object will called game over
        float py = player.transform.position.y;
        if(py<-2)
        {
            gameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseButton.onClick.Invoke();
            //PauseGame();
        }
    }

    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.collider.tag=="Obstacle"){
            //source.PlayOneShot(crash,0.7f);
        	print("paisi");
        	var currentPosition =  GameObject.Find("player");
        	 Debug.Log(" Position" + currentPosition.transform.position);
             //ControlMang.gameOver();
             //ControlMang cm = new ControlMang();
             gameOver();
             source.PlayOneShot(crash,0.7f);
        	//movement.enable=false;
        }
    }

    void gameOver()
    {
        Time.timeScale = 0;
        textOutside.text = "SCORE "+(int)player.transform.position.z;
        textOutside.text = "SCORE "+(int)player.transform.position.z;
        player.SetActive(false);
        //Obstacle.SetActive(false);
        GamePanel.SetActive(false);
        GameOver.SetActive(true);
    }

    public void onClickMainManu()
    {
        SceneManager.LoadScene("startMenu");
        Time.timeScale = 1;
    }

    
    public void PauseGame()
    {
        print("paused\n");
        Time.timeScale = 0;
        //touchDetect.setPaused(true);
        //pauseButton.setVisibility(false);
        PausePanel.SetActive(true);

    }

    public void ResumeGame()
    {
        f=0;
        //Time.timeScale = 1;
        //Invoke("setPaused", .1f);
        PausePanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void setPaused()
    {
        //touchDetect.setPaused(false);
    }

    public void waitingAndStart(int num)
    {
        print(num);
        if(num==0){
            waitingText.text = "GO!";
            Thread.Sleep(1000);
            //waitingText.text = "";
            //Time.timeScale = 1;
        }
        if(num!=0){
            waitingText.text = ""+num;
            Thread.Sleep(1000);
        }
        if(num==-1){
            waitingText.text = "";
            Time.timeScale = 1;
        }
    }
    

}
