using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorUIScript : MonoBehaviour
{
    public LayerMask UIMask;
    public LayerMask defaultMask;
    public Camera playerCam;

    public void monitorInteractionOnly(bool open){
        if(open){
            playerCam.cullingMask = UIMask;
        }else{
            playerCam.cullingMask = defaultMask;
        }
    }
}
