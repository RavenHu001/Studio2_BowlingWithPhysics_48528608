using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;

    //refer ballcontroller
    [SerializeField] private BallController ball;
    //refer pinCollection
    [SerializeField] private GameObject pinCollection;
    //refer location to spaw pinCollection
    [SerializeField] private Transform pinAnchor;
    //refer input manager
    [SerializeField] private InputManager inputManager;

    //for refer the GUI object
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        //pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include,FindObjectsSortMode.None);
        //loop the arrya and add listener for each fall trigger
        //foreach (var pin in pins)
        //{
        //    pin.OnPinFall.AddListener(IncreamentScore);
        //}

        //add function for listener of pressReste
        inputManager.onResetPressed.AddListener(HandleReste);
        //set Pins in initial
        SetPins();

    }
    //method to handle reset
    private void HandleReste()
    { 
        ball.ResetBall();
        SetPins();
    }
    //method to destory old pins and set new
    private void SetPins()
    {
        //1. destory old pins
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                //destory falltriggers
                Destroy(child.gameObject);
            }
            //destory pins
            Destroy(pinObjects);
        }
        // Instantiate new set of pins
        pinObjects = Instantiate(pinCollection,pinAnchor.transform.position,Quaternion.identity,transform);
        // add increamentScore() to evey OnPinFall event
        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncreamentScore);
        }
    }
    private void IncreamentScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}
