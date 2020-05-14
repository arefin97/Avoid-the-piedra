using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
     public Transform obstacle;
     public Transform obstacle1;
     public Transform obstacle2;
     public Transform obstacle3;
     public Transform obstacle4;
     public Transform obstacle5;
     public Transform obstacle6;
     public Transform obstacle7;
     public Transform obstacle8;
     public Transform obstacle9;
     public Transform obstacle10;
     public Transform obstacle11;
     public Transform obstacle12;
     public Transform obstacle13;
     public Transform obstacle14;
     public Transform obstacle15;
     public Transform obstacle16;
     public Transform obstacle17;
     public Transform obstacle18;
     public Transform obstacle19;
     public Transform obstacle20;

     public Transform ground;
     public Transform ground1;
     public Transform ground2;
     public Transform ground3;
     public Transform ground4;
     public Transform ground5;
     public Transform ground6;
     public Transform ground7;
     public Transform ground8;
     public Transform ground9;
     public Transform ground10;

     public Transform player;
     public static float timer = 0.0f;
     public static int spawned = 0;
     public int preVal = 0;
     public int cnt = 1;
     public int cntobs=11;
     public int cntEach25 = 4;
     public int roadThinnerFlag=0;
     public int[] a ={0,0,0};

     public Queue<Transform>roadQueue = new Queue<Transform>();
     public Queue<Transform>obstacleStoreQueue = new Queue<Transform>();
     public Queue<Transform>obstacleCreateQueue = new Queue<Transform>();
     //public Queue<KeyValuePair<int,int>>preventObstacle = new Queue<KeyValuePair<int,int>>();//Key , Value
     public Queue<int>preventObstacle = new Queue<int>();
     public Transform road;
     public Transform testObstacle;
     public float playerPosition;


     void  Start(){
       
      timer = 0.0f;
      spawned = 0;
      //cnt = 1;
      cntEach25 = 4;
      enqueueRoad();
      enqueueObstacle();

    }

    void Update()
    {

      float p = player.transform.position.z;
      setPlayerPosition(p);
      instantiateRoad();
      if(p>cntEach25*25){
          print("Player:"+p+" "+cntEach25*25 +"\n");
          if(preventObstacle.Count>0)print("Obstacle:"+(cntobs+1)*25+" "+"Ground:"+preventObstacle.Peek()+"\n");
          //else print("Empty\n");
          if(preventObstacle.Count>0 && (cntobs+1)*25 >= preventObstacle.Peek())
          {
            cntobs++;
            preventObstacle.Dequeue();
          }
          else{
           cntobs++;
           instantiateObstacle();
           print("InstantiateObstacle:"+cntobs*25+"\n");
          }
          cntEach25++;
      }

    }

    void setPlayerPosition(float p)
    {
      playerPosition = p;
    }

    float getPlayerPosition()
    {
      return playerPosition;
    }

    void enqueueRoad()
    {
      roadQueue.Enqueue(ground1);
      roadQueue.Enqueue(ground);
      roadQueue.Enqueue(ground2);
      roadQueue.Enqueue(ground3);
      roadQueue.Enqueue(ground4);
      roadQueue.Enqueue(ground5);
      roadQueue.Enqueue(ground6);
      roadQueue.Enqueue(ground7);
      roadQueue.Enqueue(ground8);
      roadQueue.Enqueue(ground9);
      roadQueue.Enqueue(ground10);
    }

    void enqueueObstacle()
    {
      obstacleStoreQueue.Enqueue(obstacle);
      obstacleStoreQueue.Enqueue(obstacle1);
      obstacleStoreQueue.Enqueue(obstacle2);
      obstacleStoreQueue.Enqueue(obstacle3);
      obstacleStoreQueue.Enqueue(obstacle4);
      obstacleStoreQueue.Enqueue(obstacle5);
      obstacleStoreQueue.Enqueue(obstacle6);
      obstacleStoreQueue.Enqueue(obstacle7);

      obstacleCreateQueue.Enqueue(obstacle8);
      obstacleCreateQueue.Enqueue(obstacle9);
      obstacleCreateQueue.Enqueue(obstacle10);
      obstacleCreateQueue.Enqueue(obstacle11);
      obstacleCreateQueue.Enqueue(obstacle12);
      obstacleCreateQueue.Enqueue(obstacle13);
      obstacleCreateQueue.Enqueue(obstacle14);
      obstacleCreateQueue.Enqueue(obstacle15);
      obstacleCreateQueue.Enqueue(obstacle16);
      obstacleCreateQueue.Enqueue(obstacle17);
      obstacleCreateQueue.Enqueue(obstacle18);
      obstacleCreateQueue.Enqueue(obstacle19);
      obstacleCreateQueue.Enqueue(obstacle20);

    }

    void instantiateRoad()
    {
      float pr = getPlayerPosition();
      if(pr>cnt*50)
      {
        //print(cnt);
        cnt++;
        road = roadQueue.Dequeue();
        if(road.transform.localScale.x !=7)road.transform.localScale+= new Vector3(5f,0,0);
        int randomRoadThinner = Random.Range(1,12);
        if((cnt+8)*50>700 && randomRoadThinner==5 && roadThinnerFlag==0){
          road.transform.localScale+= new Vector3(-5f,0,0);
          float randX = Random.Range(-3,4);
          if(randX==-3)randX+=0.5f;
          else if(randX==3)randX+=-0.5f;
          road.transform.position = new Vector3(randX,0,((cnt+8)*50)+25);//Random.Range(-3,4)(-2.5,2.5)
          //preventObstacle.Enqueue(new KeyValuePair<int,int>(((cnt+8)*50),((cnt+9)*50)));
          int val = ((cnt+8)*50);
          if(val!=preVal)preventObstacle.Enqueue(val);
          preventObstacle.Enqueue(val+25);
          preventObstacle.Enqueue(val+50);
          preVal = val+50;
          roadThinnerFlag = 1;
        }
        else if((cnt+8)*50>700 && (randomRoadThinner==7 || randomRoadThinner==4)){
          road.transform.position = new Vector3(0,0,((cnt+8)*50)+25+5+10);
        }

        else{
          road.transform.position = new Vector3(0,0,((cnt+8)*50)+25);
          if(roadThinnerFlag==1)roadThinnerFlag=0;
        }
        roadQueue.Enqueue(road);
      }
    }

    void createObstacle(int x,int z)
    {
      testObstacle = obstacleCreateQueue.Dequeue();
      testObstacle.transform.position = new Vector3(x,1,z);
      obstacleStoreQueue.Enqueue(testObstacle);
    }

    void instantiateObstacle()
    {
      float plr = getPlayerPosition();
      print("Queue:"+obstacleStoreQueue.Peek().transform.position.z+"\n");
      print("Player:"+plr+"\n");
      print("Queue Elements:"+obstacleStoreQueue.Count+"\n");
      if(obstacleStoreQueue.Count>0 && plr>obstacleStoreQueue.Peek().transform.position.z)
      {
        print("Finally, "+cntobs*25+"\n");
        while(plr>obstacleStoreQueue.Peek().transform.position.z)
        {
          obstacleCreateQueue.Enqueue(obstacleStoreQueue.Dequeue());
          if(obstacleStoreQueue.Count == 0)break;
        }
      }
        //cntobs++;
        //int obspos = Random.Range(-3,4);
        //createObstacle(obspos,cntobs*25);
        if(cntobs*25<=300){
            int obspos = Random.Range(-3,4);
            createObstacle(obspos,cntobs*25);
        }
        else if(cntobs*25<=400){
          int numObs = Random.Range(0,3);
          if(numObs == 0 || numObs==1){
            int obspos = Random.Range(-3,4);
            createObstacle(obspos,cntobs*25);
          }
          else{
            int obspos1 = Random.Range(-3,4);
            int obspos2 = Random.Range(-3,4);
            if(obspos1 == obspos2)obspos2 = (obspos2+4)%7-3;
            createObstacle(obspos1,cntobs*25);
            createObstacle(obspos2,cntobs*25);
          }
        }
        else if(cntobs*25<=500){
          int numObs = Random.Range(0,5);
          if(numObs == 0 || numObs==1){
            int obspos = Random.Range(-3,4);
            createObstacle(obspos,cntobs*25);
          }
          else if(numObs == 2 || numObs == 4){
            int obspos1 = Random.Range(-3,4);
            int obspos2 = Random.Range(-3,4);
            if(obspos1 == obspos2)obspos2 = (obspos2+4)%7-3;
            createObstacle(obspos1,cntobs*25);
            createObstacle(obspos2,cntobs*25);
          }
          else{
            int obspos1 = Random.Range(-3,4);
            int obspos2 = Random.Range(-3,4);
            int obspos3 = Random.Range(-3,4);
            if(obspos1 == obspos2 && obspos2==obspos3){
              obspos2 = (obspos2+4)%7-3;
              obspos3 = (obspos3+5)%7-3;
            }
            else if(obspos1 == obspos2)obspos2 = (obspos2+4)%7-3;
            else if(obspos1 == obspos3)obspos3 = (obspos3+4)%7-3;
            else if(obspos2 == obspos3)obspos3 = (obspos3+4)%7-3;
            createObstacle(obspos1,cntobs*25);
            createObstacle(obspos2,cntobs*25);
            createObstacle(obspos3,cntobs*25);
          }
        }
        else{
          int numObs = Random.Range(0,11);
          if(numObs == 0 || numObs==1 || numObs==5){
            int obspos = Random.Range(-3,4);
            createObstacle(obspos,cntobs*25);
          }
          else if(numObs == 2 || numObs == 6 || numObs == 8 || numObs ==10){
            int obspos1 = Random.Range(-3,4);
            int obspos2 = Random.Range(-3,4);
            if(obspos1 == obspos2)obspos2 = (obspos2+4)%7-3;
            createObstacle(obspos1,cntobs*25);
            createObstacle(obspos2,cntobs*25);
          }
          else if(numObs == 3||numObs == 7){
            int obspos1 = Random.Range(-3,4);
            int obspos2 = Random.Range(-3,4);
            int obspos3 = Random.Range(-3,4);
            if(obspos1 == obspos2 && obspos2==obspos3){
              obspos2 = (obspos2+4)%7-3;
              obspos3 = (obspos3+5)%7-3;
            }
            else if(obspos1 == obspos2)obspos2 = (obspos2+4)%7-3;
            else if(obspos1 == obspos3)obspos3 = (obspos3+4)%7-3;
            else if(obspos2 == obspos3)obspos3 = (obspos3+4)%7-3;
            createObstacle(obspos1,cntobs*25);
            createObstacle(obspos2,cntobs*25);
            createObstacle(obspos3,cntobs*25);
          }
          else{
            int obspos1=0,obspos2=0,obspos3=0,obspos4=0;
            int type = Random.Range(0,7);
            if(type==0){obspos1=-3;obspos2=-2;obspos3=2;obspos4=3;}
            else if(type==1){obspos1=-3;obspos2=-2;obspos3=-1;obspos4=0;}
            else if(type==2){obspos1=0;obspos2=1;obspos3=2;obspos4=3;}
            else if(type==3){obspos1=-2;obspos2=-1;obspos3=0;obspos4=1;}
            else if(type==4){obspos1=-1;obspos2=0;obspos3=1;obspos4=2;}
            else if(type==5){obspos1=-3;obspos2=-1;obspos3=0;obspos4=3;}
            else if(type==6){obspos1=-3;obspos2=0;obspos3=1;obspos4=3;}
            createObstacle(obspos1,cntobs*25);
            createObstacle(obspos2,cntobs*25);
            createObstacle(obspos3,cntobs*25);
            createObstacle(obspos4,cntobs*25);
          }
        }
      
    }
        
}

