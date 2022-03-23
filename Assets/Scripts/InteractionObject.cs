using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        
    }

    public enum InteractableType
    {
        nothing,
        info,
        pickup,
        dialogue
    }
    [Header("Type of Interactle")]
    public InteractableType interType;

    [Header("Simple info Message")]
    public string infoMessage;
    private Text textInfo;

    // Start is called before the first frame update
    public void Start()
    {
        textInfo = GameObject.Find("InfoText").GetComponent<Text>();
    }

    public void Nothing()
    {
        Debug.LogWarning("Object not set");
    }

    public void InfoMessage()
    {
        textInfo.text = infoMessage;
    }
}
