using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float playerSpeed;
    public float tempSpeed = 15;
    public float tempSlow = 5;

    private int currentLane = 1; //0:left, 1:middle, 2:right
    public float laneDistance = 4; //distance between lanes
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.z = playerSpeed;

        //if(Input.GetKeyDown(KeyCode.RightArrow)) {
        if(SwipeManager.swipeRight) {
            
            currentLane++;
            if(currentLane == 3)
            currentLane = 2;
        }

        //if(Input.GetKeyDown(KeyCode.LeftArrow)) {
        if(SwipeManager.swipeLeft) {
            currentLane--;
            if(currentLane == -1)
            currentLane = 0;
        }

        Vector3 newPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (currentLane == 0) 
        {
            newPosition += Vector3.left * laneDistance;
        } 
        else if (currentLane == 2)
        {
            newPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position,newPosition, 10f * Time.fixedDeltaTime);
        //fixes controller bug
        controller.center = controller.center;

        //player speed is increased when full health
        if (Hearts.health == 3) 
        {
            playerSpeed = tempSpeed;
        } else
            playerSpeed = 10;
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;

        //continuous movement
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Bomb")
        {
           
            PlayerManager.gameOver = true;
            //Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Wall")
        {
            //slow player temporarily when hitting wall
            playerSpeed = tempSlow;
            StartCoroutine(slowTimer());
        }
    }

    IEnumerator slowTimer()
    {
        yield return new WaitForSeconds(1);
        playerSpeed = 10;
    }
}
