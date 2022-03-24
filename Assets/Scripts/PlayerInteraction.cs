using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInteractObjScript = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInterObj == true)
        {
            CheckInteraction();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("InterObject") == true)
        {
            //Debug.Log("Player Touched");
            currentInterObj = other.gameObject;
            currentInteractObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentInterObj = null;
        currentInteractObjScript = null;
    }

    void CheckInteraction()
    {
        Debug.Log("this is a " + currentInterObj.name);

        if (currentInteractObjScript.interType == InteractionObject.InteractableType.nothing)
        {
            currentInteractObjScript.Nothing();
        }
        else if (currentInteractObjScript.interType == InteractionObject.InteractableType.info)
        {
            currentInteractObjScript.InfoMessage();
        }
        else if (currentInteractObjScript.interType == InteractionObject.InteractableType.pickup)
        {
            currentInteractObjScript.PickUp();
        }
        else if (currentInteractObjScript.interType == InteractionObject.InteractableType.dialogue)
        {
            currentInteractObjScript.Dialogue();
        }
    }

}
