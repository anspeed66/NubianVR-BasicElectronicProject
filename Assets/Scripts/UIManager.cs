using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public UIPanel _currentPanel;
    public UIPanel firstPanel, secondPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
             Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_currentPanel != null)
        {
            _currentPanel.UpdateBehaviour();
        }
    }

    public void TriggerPanelTransition(UIPanel panel)
    {
        TriggerOpenPanel(panel);
    }

    void TriggerOpenPanel(UIPanel panel) {
        if (_currentPanel != null)
        {
            TriggerClosePanel(_currentPanel);
        }
        _currentPanel = panel;
        panel.OpenBehaviour();
    }

    void TriggerClosePanel(UIPanel panel) {
        panel.CloseBehaviour();
    }
}
