using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class gameLogic : MonoBehaviour
{
    public MonitorLogic anomalyChecker;
    private GameObject[] anomalyItem;
    public GameObject anomaly1Origin;
    public GameObject anomaly1V2Changed;
    public GameObject anomaly1Changed;
    public GameObject anomaly2Origin;
    public GameObject anomaly2Changed;
    public GameObject anomaly3Origin;
    public GameObject anomaly3Changed;
    public GameObject anomaly4Origin;
    public GameObject anomaly4Changed;
    bool anomaly1State;
    bool anomaly2State;
    bool anomaly3State;
    bool anomaly4State;

    void Awake()
    {
        anomalyItem = GameObject.FindGameObjectsWithTag("anomalies");
    }

    void Start(){
        //initially set all anomalies gameObject to false
        foreach(GameObject anom in anomalyItem){
            anom.SetActive(false);
        }
    }

    //randomize the anomalyActivated
    public void randomAnom(){
        //begin by resetting all state to false
        anomaly1State = false;
        anomaly2State = false;
        anomaly3State = false;
        anomaly4State = false;
        
        //randomize number of anomaly activated
        int numAnomaly = Random.Range(0,5);
        while(numAnomaly > 0){
            //randomize which anomaly got activated
            int activateAnomaly = Random.Range(1,5);
            if(activateAnomaly == 1 && anomaly1State == false){
                anomaly1State = true;
                anomalyChecker.setAnomActivated(0, true);       //Setting the anomActivated in the MonitorLogic for checking

                anomaly1();
            }else if(activateAnomaly == 2 && anomaly2State == false){
                anomaly2State = true;
                anomalyChecker.setAnomActivated(1, true);

                anomaly2();
            }else if(activateAnomaly == 3 && anomaly3State == false){
                anomaly3State = true;
                anomalyChecker.setAnomActivated(2, true);

                anomaly3();
            }else if(activateAnomaly == 4 && anomaly4State == false){
                anomaly4State = true;
                anomalyChecker.setAnomActivated(3, true);

                anomaly4();
            }
            else{
                continue;
            }

            numAnomaly--;
        }
    }

    void anomaly1(){
        anomaly1Origin.SetActive(false);
        if(Random.Range(0,2) == 0){
            anomaly1Changed.SetActive(true);
            Debug.Log("Anomaly 1 Activated");
        }else{
            anomaly1V2Changed.SetActive(true);
            Debug.Log("Anomaly 1 V.2 Activated");
        }
    }

    void anomaly2(){
        anomaly2Origin.SetActive(false);
        anomaly2Changed.SetActive(true);
        Debug.Log("Anomaly 2 Activated");
    }

    void anomaly3(){
        anomaly3Origin.SetActive(false);
        anomaly3Changed.SetActive(true);
        Debug.Log("Anomaly 3 Activated");
    }

    void anomaly4(){
        anomaly4Origin.SetActive(false);
        anomaly4Changed.SetActive(true);
        Debug.Log("Anomaly 4 Activated");
    }
}
