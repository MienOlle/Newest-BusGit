using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonToggleScript : MonoBehaviour
{
    public MonitorLogic toggleLogic;
    public Button[] anomalyButtons;
    public Button submitButton;
    private int numButton;
    private Color[] originalColor;
    private Color[] selectedColor;
    private bool[] isSelected;
    public float selectedDarkness = 0.7f;
    
    // Start is called before the first frame update
    void Start()
    {
        numButton = anomalyButtons.Length;
        originalColor = new Color[numButton];
        selectedColor = new Color[numButton];
        isSelected = new bool[numButton];
        toggleLogic.getNumButton(numButton);            //give the numButton to MonitorLogic

        //Set the original color and selected color for each button
        //Set onClickListener to be called when the button is clicked
        for(int i = 0;i < numButton;i++){
            originalColor[i] = anomalyButtons[i].image.color;
            selectedColor[i] = originalColor[i] * selectedDarkness;
            isSelected[i] = false;

            int index = i;
            anomalyButtons[i].onClick.AddListener(() => ToggleButton(index));           //add listener to each button
        }

        submitButton.onClick.AddListener(() => submitPressed());                        //add listener to submit button
        submitInteractable(false);          //initially set submit button uninteractable
    }

    //Setting the button state to selected or unselected state
    private void ToggleButton(int index){
        isSelected[index] = !isSelected[index];
        toggleLogic.buttonLogic(index, isSelected[index]);
        
        if(isSelected[index]){
            anomalyButtons[index].image.color = selectedColor[index];
        }else{
            anomalyButtons[index].image.color = originalColor[index];
        }
    }

    public void submitInteractable(bool value){
        submitButton.interactable = value;
    }

    private void submitPressed(){
        //submission checking and setting the submit button back to uninteractable
        toggleLogic.submittedCheck();
        submitInteractable(false);
    }

    //Links to buttonToggleScript to unselect all button
    public void unselectButton(){
        for(int i = 0;i < numButton;i++){
            if(isSelected[i] == true){
                ToggleButton(i);
            }
        }
    }
}
