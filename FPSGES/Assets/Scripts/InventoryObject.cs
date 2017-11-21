using UnityEngine;
using System.Collections;
using System;

public class InventoryObject : MonoBehaviour, IActivatable
{
    [SerializeField]
    string nameText;

    [SerializeField]
    string descriptionText;

    InventoryManager inventoryManager;

    public string NameText
    {
        get
        {
            return nameText;
        }
    }

    public string DescriptionText
    {
        get
        {
            return descriptionText;
        }
    }

    public void DoActivate()
    {
        gameObject.SetActive(false);
        inventoryManager.InventoryObjects.Add(this);
    }

    // Use this for initialization
    void Start () 
	{
        try
        {    
            inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        }
        catch (Exception)
        {
           throw new System.Exception("Scene must contain a gameobject named 'Inventory Manager'" +
                    " with an InventoryManager script attached.");
        }
     
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
