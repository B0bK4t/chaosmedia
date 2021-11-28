using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class affichageRecettes : MonoBehaviour
{
    [Header("Général")]
    public GameObject GameManager;
    private List<RawImage> all = new List<RawImage>();
    private string repas;

    [Header("Plat de viande")]
    [Header("Recettes")]
    public RawImage platViandeBon;
    public RawImage platViandeSalade;
    public RawImage platViandeSteak;

    [Header("Burger")]
    public RawImage burgerBon;
    public RawImage burgerPain;
    public RawImage burgerFromage;
    public RawImage burgerViande;
    public RawImage burgerLaitue;
    public RawImage burgerTomate;

    [Header("Brochette")]
    public RawImage brochetteBon;
    public RawImage brochetteViande;
    public RawImage brochetteLaitue;
    public RawImage brochetteTomate;

    [Header("Jello")]
    public RawImage jelloBon;
    public RawImage jelloJus;
    
    [Header("Sandwich")]
    public RawImage sandwichBon;
    public RawImage sandwichPain;
    public RawImage sandwichViande;
    public RawImage sandwichLaitue;
    public RawImage sandwichTomate;
    
    [Header("Salade")]
    public RawImage saladeBon;
    public RawImage saladeFromage;
    public RawImage saladeLaitue;
    public RawImage saladeTomate;
    
    [Header("Croque-Monsieur")]
    public RawImage croqueMrBon;
    public RawImage croqueMrFromage;
    public RawImage croqueMrViande;
    public RawImage croqueMrPain;

    // Start is called before the first frame update
    void Start()
    {
        all.Add(platViandeBon);
        all.Add(platViandeSalade);
        all.Add(platViandeSteak);

        all.Add(burgerBon);
        all.Add(burgerPain);
        all.Add(burgerFromage);
        all.Add(burgerViande);
        all.Add(burgerLaitue);
        all.Add(burgerTomate);

        all.Add(brochetteBon);
        all.Add(brochetteViande);
        all.Add(brochetteLaitue);
        all.Add(brochetteTomate);

        all.Add(jelloBon);
        all.Add(jelloJus);

        all.Add(sandwichBon);
        all.Add(sandwichPain);
        all.Add(sandwichViande);
        all.Add(sandwichLaitue);
        all.Add(sandwichTomate);

        all.Add(saladeBon);
        all.Add(saladeFromage);
        all.Add(saladeLaitue);
        all.Add(saladeTomate);

        all.Add(croqueMrBon);
        all.Add(croqueMrFromage);
        all.Add(croqueMrViande);
        all.Add(croqueMrPain);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newRecette(string name) {
        repas = name;
        clear();
        switch (repas)
        {
            case "Plat de viande":
                platViandeBon.enabled = true;
                break;

            case "Burger":
                burgerBon.enabled = true;
                break;

            case "Brochette":
                brochetteBon.enabled = true;
                break;

            case "Sandwich":
                sandwichBon.enabled = true;
                break;

            case "Salade":
                saladeBon.enabled = true;
                break;

            case "Croque-monsieur":
                croqueMrBon.enabled = true;
                break;

            case "Jello":
                jelloBon.enabled = true;
                break;

            default:
            break;
        }
    }

    public void checkIngredient(string name) {
        switch (repas) {
            case "Plat de viande":
            switch (name)
            {
                case "viande":
                platViandeSteak.enabled = true;
                break;
                case "laitue":
                platViandeSalade.enabled = true;
                break;
                default:
                break;
            }
            break;

            case "Burger":
            switch (name)
            {
                case "pain":
                burgerPain.enabled = true;
                break;
                case "fromage":
                burgerFromage.enabled = true;
                break;
                case "viande":
                burgerViande.enabled = true;
                break;
                case "laitue":
                burgerLaitue.enabled = true;
                break;
                case "tomate":
                burgerTomate.enabled = true;
                break;
                default:
                break;
            }
            break;

            case "Brochette":
            switch (name)
            {
                case "viande":
                brochetteViande.enabled = true;
                break;
                case "laitue":
                brochetteLaitue.enabled = true;
                break;
                case "tomate":
                brochetteTomate.enabled = true;
                break;
                default:
                break;
            }
            break;

            case "Jello":
            switch (name)
            {
                case "jus":
                jelloJus.enabled = true;
                break;
                default:
                break;
            }
            break;

            case "Sandwich":
            switch (name)
            {
                case "pain":
                sandwichPain.enabled = true;
                break;
                case "viande":
                sandwichViande.enabled = true;
                break;
                case "laitue":
                sandwichLaitue.enabled = true;
                break;
                case "tomate":
                sandwichTomate.enabled = true;
                break;
                default:
                break;
            }
            break;

            case "Salade":
            switch (name)
            {
                case "fromage":
                saladeFromage.enabled = true;
                break;
                case "laitue":
                saladeLaitue.enabled = true;
                break;
                case "tomate":
                saladeTomate.enabled = true;
                break;
                default:
                break;
            }
            break;

            case "Croque-monsieur":
            switch (name)
            {
                case "fromage":
                croqueMrFromage.enabled = true;
                break;
                case "viande":
                croqueMrViande.enabled = true;
                break;
                case "pain":
                croqueMrPain.enabled = true;
                break;
                default:
                break;
            }
            break;

            default:
            break;
        }
    }

    public void clear() {
      foreach (var a in all)
      {
          if (a != null) {
              a.enabled = false;
          }
      }
    }
}
