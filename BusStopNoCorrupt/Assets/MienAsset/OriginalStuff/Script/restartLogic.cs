using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartLogic : MonoBehaviour
{
    public buttonToggleScript toggleSubmit;
    public gameLogic BusController;
    private gameLogic restartScript;
    private GameObject[] originalItem;
    private GameObject[] anomalyItem;
    private int gameLevel = 0;
    private bool EndHit = true;
    void Awake()
    {
        originalItem = GameObject.FindGameObjectsWithTag("origins");
        anomalyItem = GameObject.FindGameObjectsWithTag("anomalies");
        GameObject startObject = GameObject.Find("GameLogic");
        restartScript = startObject.GetComponent<gameLogic>();
    }

    private void OnTriggerEnter(Collider gameState){
        if(gameState.CompareTag("endGame") && EndHit){
            EndHit = false;
            toggleSubmit.submitInteractable(true);
            BusController.setBusScript(false);
            ReturnOriginal();
        }else if(gameState.CompareTag("startGame") && !EndHit){
            EndHit = true;
            startAnom();
        }
    }

    //Setting every anomaly off and every origin on
    private void ReturnOriginal(){
        Debug.Log("The level is restarted");
        foreach(GameObject org in originalItem){
            Debug.Log("Object " + org + " Activated");
            org.SetActive(true);
        }

        foreach(GameObject anom in anomalyItem){
            Debug.Log("Object " + anom + " Inactivated");
            anom.SetActive(false);
        }
    }

    //Start randomizing for new level
    private void startAnom(){
        if(gameLevel != 0){
            Debug.Log("The level anomaly is randomized");
            restartScript.randomAnom();
        }
    }

    //Get the submission result to set the next level
    public void getResult(bool value){
        if(value){
            gameLevel++;
        }else{
            gameLevel = 0;
        }
        Debug.Log("Current level = " + gameLevel);
    }
}
