using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> TextToDisplay;

    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;

    void Start()
    {
        TextToDisplay = new List<string>();

        TimeToNextText = 0.0f;
        CurrentText = 0;

        RotatingSpeed = 1.0f;

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[0];

        SparksParticles.Play();
    }

    void Update()
    {
        transform.Rotate(0, RotatingSpeed, 0);

        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;

            CurrentText++;

            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }

            Text.text = TextToDisplay[CurrentText];
        }
    }
}