using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Second_UIPanel : UIPanel
{
    public Image testImage;

    public override void UpdateBehaviour()
    {
        base.UpdateBehaviour();
        testImage.rectTransform.Rotate(Vector3.right * Time.deltaTime * 90f);
    }

}
