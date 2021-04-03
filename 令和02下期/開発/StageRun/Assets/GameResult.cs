using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
	public GameObject resultUI;
	public Text resultTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Goal.goal) 
        {
	  resultUI.SetActive(true);
int result = Mathf.FloorToInt(Timer.time);
resultTime.text ="ResultTime:" + result;


        }
    }

    public void OnRetry()
    {
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 

}
