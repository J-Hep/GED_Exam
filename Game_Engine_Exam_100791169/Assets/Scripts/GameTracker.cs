using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTracker : MonoBehaviour
{

    public int numberOfDucksHit, neededDuckHits = 0;
    private bool won, timeUp, start;
    private float startDelta;
    public float desiredTime;

   public GameObject panel, win, lose, intro;

    private void Start()
    {

        startDelta = 0;

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;

            panel.SetActive(false);
            intro.SetActive(false);

        }


        if (!timeUp && start)
        {

            startDelta += Time.deltaTime;

            if (numberOfDucksHit >= neededDuckHits && !won)
            {

                Debug.Log("Reached Win condition");
                won = true;
            }

            if ((startDelta - desiredTime) >= 0)
            {

                Debug.Log(" " + desiredTime + " seconds has elapsed");
                startDelta = 0;

                timeUp = true;
            }
        }

        if (!won && timeUp)
        {
            Debug.Log("Lose");
            panel.SetActive(true);
            lose.SetActive(true);
        }

        if (won && timeUp)
        {

            panel.SetActive(true);
            win.SetActive(true);
            Debug.Log("Win");
        }


    }


}
