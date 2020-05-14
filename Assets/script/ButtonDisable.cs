using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ButtonDisable : MonoBehaviour
{
    public Button pauseButton;
    private int count=0;

    void start()
    {
        pauseButton = GetComponent<Button>();
    }
    
	public void changeButton()
    {
        if(count== 0){
            pauseButton.image.rectTransform.sizeDelta = new Vector2(50, 50);
        }
        else{
            pauseButton.image.rectTransform.sizeDelta = new Vector2(0, 0);
        }
    }

    public void changeCount()
    {
        count = (count+1)%2;
        changeButton();
    }

    

}
