using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class affichageCloche : MonoBehaviour
{
    [Header("Ingrédients")]
    public RawImage fromage;
    public RawImage pain;
    public RawImage painCru;
    public RawImage viande;
    public RawImage viandeCrue;
    public RawImage laitue;
    public RawImage laitueCrue;
    public RawImage jus;
    public RawImage jello;
    public RawImage tomate;
    public RawImage tomateCrue;

    private float startPosX = -55;
    private float currentPosX;
    private float newPosX;
    private List<RawImage> all = new List<RawImage>();
    private float multiplicateur = 40;
    private float posY = -35;

    [Header("Clonage")]
    public GameObject parent;
    private List<RawImage> clones = new List<RawImage>();
    private RawImage clone;
    private RawImage current;
    private int currentNb;

    void Start() {    
        all.Add(fromage);
        all.Add(pain);
        all.Add(painCru);
        all.Add(viande);
        all.Add(viandeCrue);
        all.Add(laitue);
        all.Add(laitueCrue);
        all.Add(jus);
        all.Add(jello);
        all.Add(tomate);
        all.Add(tomateCrue);
        
        clearCloche();
    }

    void Update() {
        currentPosX = this.GetComponent<GameManager>().hotspotAssiette.GetComponent<Hotspot_assiette>().nbIngredients;
    }

    public void ajouterDansCloche(string name) {
        newPosX = startPosX + currentPosX*multiplicateur;
        var i = name;
        switch (i)
        {
            case "pain":
                current = pain;
            break;
            case "viande":
                current = viande;
            break;
            case "fromage":
                current = fromage;
            break;
            case "tomate":
                current = tomate;
            break;
            case "laitue":
                current = laitue;
            break;
            case "jusCru":
                current = jus;
            break;
            case "jus":
                current = jello;
            break;
            case "viandeCrue":
                current = viandeCrue;
            break;
            case "laitueCrue":
                current = laitueCrue;
            break;
            case "painCru":
                current = painCru;
            break;
            case "tomateCrue":
                current = tomateCrue;
            break;
            default:
            break;
        }
        clone = Instantiate(current, new Vector3(0,0, 0), Quaternion.identity, parent.transform);
        clone.transform.localPosition = new Vector3(newPosX, posY, 0);
        clone.enabled = true;
        clones.Add(clone);
        currentNb ++;
    }

    public void enleverDansCloche(string name) {
        Destroy(clones[currentNb-1]);
        clones.RemoveAt(currentNb-1);
        currentNb --;
    }

    public void clearCloche() {
      foreach (var a in all)
      {
          if (a != null) {
              a.enabled = false;
          }
      }
      foreach (var c in clones)
      {
          Destroy(c);
      }
        clones.Clear();
        currentNb = 0;
    }
}
