using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour {

    [SerializeField]
    LayerMask PlayerLayer;

    [SerializeField]
    Canvas WinCanvas;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Cursor.visible = true;
            WinCanvas.enabled = true;
            Time.timeScale = 0;
        }
    }
}
