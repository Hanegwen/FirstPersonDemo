using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class InventoryMenuItem : MonoBehaviour 
{
    private Toggle toggle;
    private InventoryManager inventoryManager;

    public InventoryObject InventoryObjectRepresented { get; set; }

    public void OnValueChanged()
    {
        if (toggle.isOn)
        {
            // update the description text based on the selected item
            inventoryManager.UpdateDescriptionText(InventoryObjectRepresented.DescriptionText);
        }
    }

	// Use this for initialization
	void Start () 
	{
        toggle = GetComponent<Toggle>();

        try
        {
            inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        }
        catch 
        {
            throw new System.Exception("Scene requires game object" + 
                " named \"Inventory Manager\" with an InventoryManager script attached");
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
