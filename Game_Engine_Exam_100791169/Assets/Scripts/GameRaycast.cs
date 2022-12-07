using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRaycast : MonoBehaviour
{
   public GameObject woahGameObject;

    public void raycast()
    {

        //Raycast from main camera to mouse position to detect if collision occurs
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GetComponent<Transform>().position = hit.point;
            Debug.Log("Collision with: "+ hit.transform.name);
            Debug.DrawLine(Camera.main.transform.position, hit.point);

            //Increment duck game logic 
            woahGameObject.GetComponent<GameTracker>().numberOfDucksHit += 1;

        }


    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            raycast();
        }
        

    }
}
