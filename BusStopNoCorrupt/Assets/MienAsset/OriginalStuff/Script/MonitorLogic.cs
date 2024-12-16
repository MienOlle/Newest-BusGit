using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorLogic : MonoBehaviour
{
    public buttonToggleScript unselectAnom;
    public busScript BusController;
    public restartLogic LevelController;
    private bool[] anomalySelected;
    private int numAnomalyType = 4;
    private bool[] anomalyActivated;
    private int numButton;
    void Start(){
        //Set all anomalyActivated to false
        anomalyActivated = new bool[numAnomalyType];
        setAllFalse(anomalyActivated, numAnomalyType);
    }

    //Links to the script buttonToggleScript to get numButton and set all anomalySelected to false
    public void getNumButton(int num){
        //Set all anomalySelected to false
        numButton = num;
        anomalySelected = new bool[numButton];
        setAllFalse(anomalySelected, numButton);
    }

    //Links to the script buttonToggleScript when a button is toggled
    public void buttonLogic(int index, bool value){
        anomalySelected[index] = value;
        Debug.Log("Button " + index + " is now " + value);
    }

    //Links to the script gameLogic for when an anomaly is activated
    public void setAnomActivated(int index, bool value){
        anomalyActivated[index] = value;
        Debug.Log("Anomaly State " + (index + 1) + " is set to " + value);
    }

    //Set all bool array given to false
    private void setAllFalse(bool[] array, int numIndex){
        for(int i = 0; i < numIndex; i++){
            array[i] = false;
        }
    }

    //submission checking
    public void submittedCheck(){
        //Do the checking first before setting every anomalyActivated to false

        //checking submission...
        bool checkRet = true;
        for(int i = 0;i < numButton;i++){
            if(anomalyActivated[i] != anomalySelected[i]){
                checkRet = false;
                break;
            }
        }
        if(checkRet){
            LevelController.getResult(true);                //Set level increase by 1
        }else{
            LevelController.getResult(false);               //Set level back to 0
        }

        //things to do after finish checking
        BusController.setBusMovement(true);                   //allow the bus to move after submission and checking
        unselectAnom.unselectButton();                      //set all anomaly selected to false
        setAllFalse(anomalyActivated, numAnomalyType);      //set all anomaly activated to false
    }
}
