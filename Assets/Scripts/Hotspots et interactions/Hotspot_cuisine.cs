using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot_cuisine : MonoBehaviour
{
    public Collider player;
    public Animator camera_zoom;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            camera_zoom.GetComponent<Animator>().SetBool("zoomer", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        camera_zoom.GetComponent<Animator>().SetBool("zoomer", false);
    }
}
