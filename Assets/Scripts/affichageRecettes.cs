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

    // Start is called before the first frame update
    void Start()
    {
        all.Add(platViandeBon);
        all.Add(platViandeSalade);
        all.Add(platViandeSteak);
        clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newRecette(string name) {
        repas = name;
        clear();
        switch (name)
        {
            case "Plat de viande":
            platViandeBon.enabled = true;
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
