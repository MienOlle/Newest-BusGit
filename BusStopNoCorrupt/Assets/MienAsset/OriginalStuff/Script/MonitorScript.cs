using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorScript : MonoBehaviour
{
    public GameObject monitorUI;
    public LayerMask monitorMask;
    public Camera playerCam;
    private bool monitorOpen = false;

    public MonitorUIScript canvasController;
    // Start is called before the first frame update
    void Start()
    {
        monitorUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //When the monitor is clicked using LMB, open the monitor. When ESC key is pressed, close the monitor
        if(Input.GetMouseButtonDown(0) && !monitorOpen){
            Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, monitorMask)){
                if(hit.collider != null && hit.collider.gameObject == gameObject){
                    ToggleMonitorUI();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && monitorOpen){
            ToggleMonitorUI();
        }
    }

    private void ToggleMonitorUI(){
        monitorOpen = !monitorOpen;
        monitorUI.SetActive(monitorOpen);

        canvasController.monitorInteractionOnly(monitorOpen);       //Set culling mask to only UI elements
    }
}
