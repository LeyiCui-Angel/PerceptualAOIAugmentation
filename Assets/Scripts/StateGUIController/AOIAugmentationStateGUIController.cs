using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AOIAugmentationStateGUIController : GUIController
{
    // Start is called before the first frame update
    public TargetImageController targetImageController;

    public NoAOIAugmentationOverlayController noAOIAugmentationOverlay;
    public StaticAOIAugmentationOverlayController staticAOIAugmentationOverlayController;
    public InteractiveAOIAugmentationOverlayController interactiveAOIAugmentationOverlay;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public void setImage(Texture2D imageTexture)
    {
        targetImageController.setImage(imageTexture);
    }




}
