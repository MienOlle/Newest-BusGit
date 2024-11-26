using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class gameLogic : MonoBehaviour
{
    public MonitorLogic anomalyChecker;
    public busScript BusController;
    private GameObject[] anomalyItem;
    public GameObject anomaly1Origin;
    public GameObject anomaly1V2Changed;
    public GameObject anomaly1Changed;
    bool anomaly1State;
    bool anomaly2State;

    // Start is called before the first frame update
    void Awake()
    {
        //find game object anomalies
        anomalyItem = GameObject.FindGameObjectsWithTag("anomalies");
    }

    void Start(){
        //set all anomalies gameObject to false
        foreach(GameObject anom in anomalyItem){
            anom.SetActive(false);
        }
    }

    //randomize the anomalyActivated
    public void randomAnom(){
        //begin by resetting all state to false
        anomaly1State = false;
        anomaly2State = false;
        
        //randomize number of anomaly activated
        int numAnomaly = Random.Range(0,3);
        while(numAnomaly > 0){
            //randomize which anomaly got activated
            int activateAnomaly = Random.Range(1,3);
            if(activateAnomaly == 1 && anomaly1State == false){
                anomaly1State = true;
                anomalyChecker.setAnomActivated(0, true);       //Setting the anomActivated in the MonitorLogic for checking

                if(Random.Range(0,2) == 1){
                    anomaly1Second();
                    Debug.Log("Anomaly 1 V.2 Activated");
                }else{
                    anomaly1();
                    Debug.Log("Anomaly 1 Activated");
                }
            }else if(activateAnomaly == 2 && anomaly2State == false){
                anomaly2State = true;
                anomalyChecker.setAnomActivated(1, true);

                anomaly2();
                Debug.Log("Anomaly 2 Activated");
            }else{
                continue;
            }

            numAnomaly--;
        }
    }

    public void setBusScript(bool value){
        BusController.setBusMovement(value);
    }

    void anomaly1(){
        anomaly1Origin.SetActive(false);
        anomaly1Changed.SetActive(true);
    }

    void anomaly1Second(){
        anomaly1Origin.SetActive(false);
        anomaly1V2Changed.SetActive(true);
    }

    void anomaly2(){
        
    }
}
