using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempAudio : MonoBehaviour
{
  /*Placer les éléments suivant sur des scripts pour les objets générant les sons
  */
   public AudioSource audioData; //Source du son

    void Start()
 {
   audioData = GetComponent<AudioSource>();
 }

  //Méthode appellée dans l'écouteur de son
   void Jouer() {
     audioData.Play(0);
   }

    void Pause()
    {
        audioData.Pause();
    }
}
