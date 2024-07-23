using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera m_PlayerCamera;

    void Start()
    {
        
    }

    void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = m_PlayerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 4.0f))
            {
                Debug.Log("Detect Object: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer(GlobalVar.BUTTON_LAYER))
                {
                    InteractButton interactButton = hit.collider.gameObject.GetComponent<InteractButton>();
                    interactButton.Execute();
                }
            }
        }
    }
}
