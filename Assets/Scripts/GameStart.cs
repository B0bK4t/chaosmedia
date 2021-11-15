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

    void startGame() {
        Invoke("hideThree", 1.0f);
    }

    void hideThree() {
        trois.enabled = false;
        Invoke("hideTwo", 1.0f);
    }

    void hideTwo() {
        deux.enabled = false;
        Invoke("hideOne", 1.0f);
    }

    void hideOne() {
        un.enabled = false;
        Invoke("hideActionBig", 1.0f);
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
