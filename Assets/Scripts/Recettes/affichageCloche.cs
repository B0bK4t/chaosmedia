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
                // pain.enabled = true;
                current = pain;
            break;
            case "viande":
                // viande.enabled = true;
                current = viande;
            break;
            case "fromage":
                // fromage.enabled = true;
                current = fromage;
            break;
            case "tomate":
                // tomate.enabled = true;
                current = tomate;
            break;
            case "laitue":
                // laitue.enabled = true;
                current = laitue;
            break;
            case "jusCru":
                // jus.enabled = true;
                current = jus;
            break;
            case "viandeCrue":
                // viandeCrue.enabled = true;
                current = viandeCrue;
            break;
            case "laitueCrue":
                // laitueCrue.enabled = true;
                current = laitueCrue;
            break;
            case "painCru":
                // painCru.enabled = true;
                current = painCru;
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
