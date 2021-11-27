using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class voixPersonageAleatoire : MonoBehaviour
{

    private float timer = 0f;
    private float temps = 45f;
    private float voix = 0f;

    public AudioSource voix01;
    public AudioSource voix02;
    public AudioSource voix03;
    public AudioSource voix04;
    public AudioSource voix05;

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
                voix = Mathf.Floor(Random.Range(0f, 5f));
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
        temps = Random.Range(10.0f, 60.0f);
    }

    void Play()
    {
        if (voix == 0)
        {
            voix01.Play(0);
        }
        else if(voix == 1)
        {
            voix02.Play(0);
        }
        else if (voix == 2)
        {
            voix03.Play(0);
        }
        else if (voix == 3)
        {
            voix04.Play(0);
        }
        else if (voix == 4)
        {
            voix05.Play(0);
        }
    }
}
