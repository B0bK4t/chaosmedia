using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class narrateurAleatoire : MonoBehaviour
{
    private float timer = 0f;
    private float temps = 50f;
    private float voix = 0f;

    public AudioSource voix01;
    public AudioSource voix02;
    public AudioSource voix03;
    public AudioSource voix04;
    public AudioSource voix05;
    public AudioSource voix06;
    public AudioSource voix07;
    public AudioSource voix08;
    public AudioSource voix09;
    public AudioSource voix10;
    public AudioSource voix11;
    public AudioSource voix12;
    public AudioSource voix13;
    
    //Scene
    [Header("Général")]
    public Scene scene;
    string gameScene = "scene_beta"; 


    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.name == gameScene) {
            Timer();
            if (timer >= temps)
            {
                TempsAleatoire();
                timer = 0;
                voix = Mathf.Floor(Random.Range(0f, 14f));
                Play();
            }
        }
    }

    void Timer()
    {
        timer = timer + Time.deltaTime;
    }

    void TempsAleatoire()
    {
        temps = Random.Range(30.0f, 100.0f);
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
        else if (voix == 4)
        {
            voix04.Play(0);
        }
        else if (voix == 5)
        {
            voix05.Play(0);
        }
        else if (voix == 6)
        {
            voix06.Play(0);
        }
        else if (voix == 7)
        {
            voix07.Play(0);
        }
        else if (voix == 8)
        {
            voix08.Play(0);
        }
        else if (voix == 9)
        {
            voix09.Play(0);
        }
        else if (voix == 10)
        {
            voix10.Play(0);
        }
        else if (voix == 11)
        {
            voix11.Play(0);
        }
        else if (voix == 12)
        {
            voix12.Play(0);
        }
        else if (voix == 13)
        {
            voix13.Play(0);
        }
    }
}
