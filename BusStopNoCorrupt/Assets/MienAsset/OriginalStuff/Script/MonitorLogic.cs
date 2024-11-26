using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorLogic : MonoBehaviour
{
    public buttonToggleScript unselectAnom;
    public gameLogic BusController;
    public restartLogic LevelController;
    private bool[] anomalySelected;
    private int numAnomalyType = 3;
    private bool[] anomalyActivated;
    private int numButton;
    void Start(){
        //Set all anomalyActivated to false
        anomalyActivated = new bool[numAnomalyType];
        setAllFalse(anomalyActivated, numAnomalyType);
    }
    public void getNumButton(int num){
        //Set all anomalySelected to false
        numButton = num;
        anomalySelected = new bool[numButton];
        setAllFalse(anomalySelected, numButton);
    }

    public void buttonLogic(int index, bool value){
        anomalySelected[index] = value;
        Debug.Log("Button " + index + " is now " + value);
    }

    public void setAnomActivated(int index, bool value){
        anomalyActivated[index] = value;
        Debug.Log("Anomaly State " + (index + 1) + " is set to " + value);
    }
    private void setAllFalse(bool[] array, int numIndex){
        for(int i = 0; i < numIndex; i++){
            array[i] = false;
        }
    }
    public void submittedCheck(){
        //Do the checking first before setting every anomalyActivated to false

        //checking submission...
        bool checkRet = true;
        for(int i = 0;i < numButton;i++){
            if(anomalyActivated[i] != anomalySelected[i]){
                LevelController.getResult(false);
                checkRet = false;
                break;
            }
        }
        if(checkRet){
            LevelController.getResult(true);
        }

        //things to do after finish checking
        BusController.setBusScript(true);
        unselectAnom.unselectButton();
        setAllFalse(anomalyActivated, numAnomalyType);
    }
}
