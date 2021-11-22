using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class narrateurAleatoire : MonoBehaviour
{
    private float timer = 0f;
    private float temps = 60f;
    private float voix = 0f;

    public AudioSource voix01;
    public AudioSource voix02;
    public AudioSource voix03;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Timer();
        if (timer >= temps)
        {
            TempsAleatoire();
            timer = 0;
            voix = Mathf.Floor(Random.Range(0f, 4f));
            Play();
        }

    }

    void Timer()
    {
        timer = timer + Time.deltaTime;
    }

    void TempsAleatoire()
    {
        Debug.Log("Temps" + temps);
        temps = Random.Range(60.0f, 200.0f);
    }

    void Play()
    {
        if (voix == 0)
        {
            voix01.Play(0);
        }
        else if (voix == 1)
        {
            voix02.Play(0);
        }
        else if (voix == 2)
        {
            voix03.Play(0);
        }
        else if (voix == 3)
        {
            voix03.Play(0);
        }
    }
}
