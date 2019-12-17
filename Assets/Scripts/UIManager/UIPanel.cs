using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public bool isOpen = false;
    public virtual void OpenBehaviour()
    {
        if (!isOpen)
        {
            isOpen = true;
            gameObject.SetActive(true);
        }
    }

    public virtual void UpdateBehaviour()
    { 
    
    }

    public virtual void CloseBehaviour() {
        if (isOpen)
        {
            isOpen = false;
            gameObject.SetActive(false);

        
        }
        
    }


}
