using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    //for refer the GUI object
    [SerializeField] private TextMeshProUGUI scoreText;

    private FallTrigger[] pins;

    private void Start()
    {
        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include,FindObjectsSortMode.None);
        //loop the arrya and add listener for each fall trigger
        foreach (var pin in pins)
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
