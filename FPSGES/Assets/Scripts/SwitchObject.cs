using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : MonoBehaviour, IActivatable {

    [SerializeField]
    Light lightObject;

    [SerializeField]
    string objectName;

    [SerializeField]
    bool lightOn;

    public string NameText
    {
        get
        {
            return objectName;
        }
    }

    public void DoActivate()
    {
        if(lightOn)
        {
            lightObject.enabled = false;
        }

        else
        {
            lightObject.enabled = true;
        }
    }

    public void PlayAudio()
    {
        
    }
}
