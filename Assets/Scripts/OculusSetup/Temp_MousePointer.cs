using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSetup;

public class Temp_MousePointer : MonoBehaviour
{
    public LineRenderer laser;
    public Transform laser_origin;
    public float m_Distance = 40f;

    public LayerMask m_EverythingMask = 0;
    public LayerMask m_InteractableMask = 0;


    GameObject m_CurrentObject;
    GameObject m_PrevObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    RaycastHit hit;
    Ray ray;
    Interactable interactable;
    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {

                Interactable interactable = hit.transform.gameObject.GetComponent<Interactable>();
                interactable.Pressed();

            }
        }

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.collider)
            {
                Interactable interactable = hit.transform.gameObject.GetComponent<Interactable>();
                if (interactable) interactable.Hovered();

                if (hit.transform.gameObject != m_PrevObject)
                {
                    if (interactable) interactable.HoveredOff();
                    m_PrevObject = hit.transform.gameObject;
                }
            }
        }
    }

   


}
