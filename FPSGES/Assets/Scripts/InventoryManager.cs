using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour 
{
    [SerializeField]
    GameObject inventoryMenuPanel;

    [SerializeField]
    FirstPersonController firstPersonController;

    [SerializeField]
    GameObject inventoryItemTogglePrefab;

    [SerializeField]
    Transform inventoryItemsListPanel;

    [SerializeField]
    Text descriptionText;

    public List<InventoryObject> InventoryObjects { get; set; }

    private List<GameObject> inventoryObjectToggles;

    public const string DefaultDescriptionMessage =
        "If you've picked anything up, you can select it to learn more." + 
        "\n\nIf you haven't, you'll just have to close the menu and keep playing...";

    bool isInventoryMenuShowing;

	// Use this for initialization
	void Start () 
	{
        InventoryObjects = new List<InventoryObject>();
        inventoryObjectToggles = new List<GameObject>();
        HideInventoryMenu();
        UpdateDescriptionText(DefaultDescriptionMessage);
	}
	
	// Update is called once per frame
	void Update ()
	{
        HandleInput();
        UpdateCursor();
        UpdateFirstPersonController();
	}

    public void UpdateDescriptionText(string newText)
    {
        descriptionText.text = newText;
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isInventoryMenuShowing)
            {
                HideInventoryMenu();
            }
            else
            {
                ShowInventoryMenu();
            }
        }
    }

    private void ShowInventoryMenu()
    {
        DestroyInventoryItemToggles();
        GenerateInventoryItemToggles();
        isInventoryMenuShowing = true;
        inventoryMenuPanel.SetActive(true);
    }

    private void DestroyInventoryItemToggles()
    {
        foreach (GameObject item in inventoryObjectToggles)
        {
            Destroy(item);
        }
    }

    private void GenerateInventoryItemToggles()
    {
        for (int i = 0; i < InventoryObjects.Count; i++)
        {
            GameObject inventoryObjectToggle = 
                GameObject.Instantiate(inventoryItemTogglePrefab, inventoryItemsListPanel) as GameObject;

            inventoryObjectToggle.GetComponent<InventoryMenuItem>().InventoryObjectRepresented =
                InventoryObjects[i];

            inventoryObjectToggle.GetComponentInChildren<Text>().text =
                InventoryObjects[i].NameText;

            Toggle toggle = inventoryObjectToggle.GetComponent<Toggle>();
            toggle.group = inventoryItemsListPanel.GetComponent<ToggleGroup>();

            inventoryObjectToggles.Add(inventoryObjectToggle);
        }
    }

    private void HideInventoryMenu()
    {
        isInventoryMenuShowing = false;
        inventoryMenuPanel.SetActive(false);
    }

    private void UpdateFirstPersonController()
    {
        if (isInventoryMenuShowing)
        {
            firstPersonController.enabled = false;
        }
        else
        {
            firstPersonController.enabled = true;
        }
    }

    private void UpdateCursor()
    {
        if (isInventoryMenuShowing)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
