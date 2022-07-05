
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ItemGenerator : UdonSharpBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject generatePlace;
    void Start()
    {
        
    }
    
    void Update() {
      
    }

    public override void Interact()
    {
        generateItem();
    }

    public void generateItem()
    {
        GameObject item = VRCInstantiate(itemPrefab);
        item.transform.parent = generatePlace.transform.parent;
        item.transform.localPosition = generatePlace.transform.localPosition;
    }
}
