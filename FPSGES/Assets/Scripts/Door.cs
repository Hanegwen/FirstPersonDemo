using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour, IActivatable 
{
    GameManager gm;
    [SerializeField]
    InventoryObject key;

    [SerializeField]
    bool isLocked = false;

    bool hasKey = false;
    Animator animator;
    InventoryManager inventoryManager;

    bool isOpen = false;

    public string NameText
    {
        get
        {
            if (isOpen)
            {
                return "";
                // as soon as I need two lines, I need curly brackets
            }

            if (isLocked && !hasKey)
                return "Locked";
            
            if (hasKey && isLocked)
                return "Open Door";

            return "Open Door";              
        }
    }

    public void DoActivate()
    {
        if (isLocked && key != null)
        {
            hasKey = inventoryManager.InventoryObjects.Contains(key);

            if (hasKey)
            {
                OpenDoor();
                PlayAudio();
            }
        }
        else if (!isLocked)
        {
            OpenDoor();
            PlayAudio();
        }
    }

    public void PlayAudio()
    {
        gm.audioSource.clip = gm.Pickup;
        gm.audioSource.Play();
    }

    private void OpenDoor()
    {
        isOpen = true;
        animator.SetBool("isOpen", true);
    }

    // Use this for initialization
    void Start () 
	{
        gm = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        animator.enabled = true;
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

    private void Update()
    {
        if(gm.hasKey)
        {
            hasKey = true;
        }
    }

}
