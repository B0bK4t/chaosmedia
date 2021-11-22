using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTemplate : MonoBehaviour
{
    /*Placer les éléments suivant dans le script qui génère l'action
    *   GameManager.cs pour les sons généraux
    *   Mouvement.cs pour les sons générés par le personnage
    *   Voir programmeurs pour savoir où mettre les appels exactements
    */
   
     public GameObject cuissonViande; 
     public GameObject Toaster;
     public GameObject deposerAssiette;
     public GameObject Frigo;
     public GameObject personnage;

         
    void Méthode()
 {
     //Utiliser la ligne suivant pour appeller un son
     cuissonViande.SendMessage("Jouer");
     Toaster.SendMessage("Jouer");
     deposerAssiette.SendMessage("Jouer");
     Frigo.SendMessage("Jouer");
     personnage.SendMessage("Jouer");
    }
}
