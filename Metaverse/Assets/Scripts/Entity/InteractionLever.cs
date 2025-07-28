using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class InteractionLever : MonoBehaviour
{
    public GameObject interactionObj;
    public GameObject interactionUI;

    private bool interactionEnable = false;

    public int type;
    private void Start()
    {
        interactionUI.transform.position = interactionObj.transform.position;
    }
    private void Update()
    {
        if(interactionEnable)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                GameManager.Instance.EnterGame(type);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactionUI.SetActive(true);
            interactionEnable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionUI.SetActive(false);
        }
    }
}
