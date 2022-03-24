using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
    //public int delay;

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

    [Header("Dialogue Text")]
    [TextArea]
    public string[] sentances;

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
        StartCoroutine(ShowInfo(infoMessage, 2.5f));
    }
    public void PickUp()
    {
        this.gameObject.SetActive(false);
    }

    public void Dialogue()
    {
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().startDialogue(sentances);
    }

    IEnumerator ShowInfo(string message, float delay)
    {
        textInfo.text = message;
        yield return new WaitForSeconds(delay);
        textInfo.text = null;
    }
}
