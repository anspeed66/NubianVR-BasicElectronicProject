using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class First_UIPanel : UIPanel
{
    public Button firstButton;

    public override void OpenBehaviour()
    {
        base.OpenBehaviour();
        firstButton.onClick.AddListener(() => FirstButtonClicked());
    }


    void FirstButtonClicked() {

        UIPanel targetPanel = UIManager.instance.secondPanel;
        UIManager.instance.TriggerPanelTransition(targetPanel);
    }
}
