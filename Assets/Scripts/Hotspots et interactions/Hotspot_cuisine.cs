using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot_cuisine : MonoBehaviour
{
    public Collider player;
    public Animator camera_zoom;

    void OnTriggerStay(Collider other)
    {

        Debug.Log(other.tag);

        if (other.tag == "Player")
        {
            Debug.Log("zoom la caméra");
            camera_zoom.GetComponent<Animator>().SetBool("zoomer", true);
        }
        else
        {
            // On entre jamais dans cette partie du code
            Debug.Log("dezoom la caméra");
            camera_zoom.GetComponent<Animator>().SetBool("zoomer", false);
        }
    }
}
