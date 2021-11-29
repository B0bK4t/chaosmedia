using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public RawImage trois;
    public RawImage deux;
    public RawImage un;
    public RawImage actionBig;
    public RawImage actionSmall;

    public AudioSource decompte;
    public AudioSource alarmeDebut;
    public AudioSource voixNarrateur;

    void startGame() {
        Invoke("cinematique", 0f);
        decompte.Play(0);
    }

    void cinematique() {
        Invoke("hideThree", 1.0f);
        decompte.Play(0);
    }

    void hideThree() {
        trois.enabled = false;
        Invoke("hideTwo", 1.0f);
        decompte.Play(0);
    }

    void hideTwo() {
        deux.enabled = false;
        Invoke("hideOne", 1.0f);
        decompte.Play(0);
    }

    void hideOne() {
        un.enabled = false;
        Invoke("hideActionBig", 1.0f);
        alarmeDebut.Play(0);
    }

    void hideActionBig() {
        actionBig.enabled = false;
        Invoke("hideActionSmall", 0.5f);
        
    }

    void hideActionSmall() {
        actionSmall.enabled = false;
        Invoke("send", 0.5f);
    }

    void send() {
        this.GetComponent<GameManager>().SendMessage("debut");
        voixNarrateur.Play(0);
    }

    void bypass() {
        trois.enabled = false;
        deux.enabled = false;
        un.enabled = false;
        actionBig.enabled = false;
        actionSmall.enabled = false;
        this.GetComponent<GameManager>().SendMessage("debut");
    }
}
