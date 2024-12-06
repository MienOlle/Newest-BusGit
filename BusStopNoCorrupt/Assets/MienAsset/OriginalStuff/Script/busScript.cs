using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busScript : MonoBehaviour
{
    public float maxSpeed = 24f;
    public float minSpeed = 0f;
    public float defaultSpeed = 12f;
    public float changeSpeed = 2f;

    public GameObject goAudio;
    public GameObject stopAudio;
    private Coroutine currCoroutine;

    public Transform[] startPoints;
    public Transform[] endPoints;
    private int currPoint = 0;
    public float moveSpeed = 0.2f;
    private float moveT = 0f;
    public float rotateSpeed = 0.2f;
    private float rotateT = 0f;
    public float threshold = 8f; 
    private bool isTurning = false;
    private bool isMoving = true;

    public Rigidbody busRigid;
    void Awake(){
        stopAudio.SetActive(false);
        goAudio.SetActive(true);
    }
    void Update()
    {
        //Move forward if not turning
        if(isTurning == false && isMoving){
            transform.Translate(Vector3.forward * defaultSpeed * Time.deltaTime);
        }
        
        //Speed up or slow down the bus
        if(Input.GetKeyDown("w")){
            if(defaultSpeed < maxSpeed){
                defaultSpeed += changeSpeed;
            }
        }else if(Input.GetKeyDown("s")){
            if(defaultSpeed > minSpeed){
                defaultSpeed -= changeSpeed;
            }
       }

        //Turning the bus when it reached the turning point
        if(Vector3.Distance(transform.position,startPoints[currPoint].position) < threshold){
            isTurning = true;
            // Debug.Log("It is turning");
        }

        if(isTurning){
            if(rotateT < 1f){
                transform.rotation = Quaternion.Lerp(startPoints[currPoint].rotation, endPoints[currPoint].rotation, rotateT);
                rotateT += rotateSpeed * Time.deltaTime;

                if (rotateT >= 0.99f){
                    transform.rotation = endPoints[currPoint].rotation;
                }
            }

            if(moveT < 1f){
                transform.position = Vector3.Lerp(startPoints[currPoint].position, endPoints[currPoint].position, moveT);
                moveT += moveSpeed * Time.deltaTime;
            }

            if(rotateT >= 1f && moveT >= 1f){
                // Debug.Log("It stopped turning");
                moveT = 0f;
                rotateT = 0f;
                if(currPoint + 1 < startPoints.Length && currPoint + 1 < endPoints.Length){
                    currPoint++;
                    // Debug.Log(currPoint);
                }else{
                    currPoint = 0;
                }
                isTurning = false;
            }
        }
    }

    public void changeAudio(bool value){
        if(currCoroutine != null){
            StopCoroutine(currCoroutine);
        }
        currCoroutine = StartCoroutine(setAudio(value));
    }
    private IEnumerator setAudio(bool value){
        if(!value){
            goAudio.SetActive(value);
            yield return new WaitForSeconds(1);
            stopAudio.SetActive(!value);
        }else{
            stopAudio.SetActive(!value);
            yield return new WaitForSeconds(1);
            goAudio.SetActive(value);
        }

        currCoroutine = null;
    }

    public void setBusMovement(bool value){
        isMoving = value;
        changeAudio(value);
    }
}
