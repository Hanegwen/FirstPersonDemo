using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivateLookedAtObject : MonoBehaviour 
{
    // This script is intended to be put on the camera!

    [SerializeField]
    float maxDistanceToActivate = 4;
    [SerializeField]
    LayerMask layerToCheckForObjects;
    [SerializeField]
    Text lookedAtObjectText;

    IActivatable lookedAtObject;

	// Use this for initialization
	void Start () 
	{
        lookedAtObjectText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckForLookedAtObjects();
        UpdateLookedAtObjectText();
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (lookedAtObject != null)
            {
                lookedAtObject.DoActivate();
            }
        }
    }

    void UpdateLookedAtObjectText()
    {
        if (lookedAtObject == null)
        {
            lookedAtObjectText.gameObject.SetActive(false);
        }
        else
        {
            lookedAtObjectText.text = lookedAtObject.NameText;
            lookedAtObjectText.gameObject.SetActive(true);
        }
    }

    private void CheckForLookedAtObjects()
    {
        Vector3 endPoint = (transform.forward * maxDistanceToActivate) + transform.position;
        Debug.DrawLine(transform.position, endPoint, Color.red);

        RaycastHit raycastHit;
        if (Physics.Raycast(transform.position, transform.forward,
            out raycastHit, maxDistanceToActivate, layerToCheckForObjects))
        {           
            // Debug.Log("Ray hit: " + raycastHit.transform.gameObject.name);
            lookedAtObject = raycastHit.transform.gameObject.GetComponent<IActivatable>();
        }
        else
        {
            lookedAtObject = null;
        }
    }
}
