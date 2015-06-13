/*============================================================================== 
 * Copyright (c) 2012-2014 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/

using UnityEngine;
using System.Collections;
using Vuforia;

public class VirtualButtonsUIView : ISampleAppUIView {
    
    
    #region PUBLIC_PROPERTIES
    public CameraDevice.FocusMode FocusMode
    {
        get {
            return mFocusMode;
        }
        set {
            mFocusMode = value;
        }
    }
    #endregion PUBLIC_PROPERTIES
    
    #region PUBLIC_MEMBER_VARIABLES
    public event System.Action TappedToClose;
    public SampleAppUIBox mBox;
    public SampleAppUILabel mHeaderLabel;
    public SampleAppUILabel mButtonsLabel;
    public SampleAppUICheckButton mAboutButton;
    public SampleAppUICheckButton mOffTargetTracking;
    public SampleAppUICheckButton mCameraFlashSettings;
    public SampleAppUICheckButton mAutoFocusSetting;
    
    public SampleAppUICheckButton mVirtualYellowButton;
    public SampleAppUICheckButton mVirtualGreenButton;
    public SampleAppUICheckButton mVirtualRedButton;
    public SampleAppUICheckButton mVirtualBlueButton;
    
    public SampleAppUILabel mCameraLabel;
    public SampleAppUIRadioButton mCameraFacing;
    public SampleAppUIRadioButton mVirtualButtons;
    public SampleAppUILabel mButtonLabel;
    public SampleAppUIButton mCloseButton;
    #endregion PUBLIC_MEMBER_VARIABLES
    
    #region PRIVATE_MEMBER_VARIABLES
    private CameraDevice.FocusMode mFocusMode;
    private SampleAppsUILayout mLayout;
    #endregion PRIVATE_MEMBER_VARIABLES
    
    #region PUBLIC_METHODS
    
    public void LoadView()
    {
        mLayout = new SampleAppsUILayout();
        mHeaderLabel = mLayout.AddLabel("Virtual Buttons");
        mAboutButton = mLayout.AddSimpleButton("About");
        mLayout.AddGap(2);
        mAutoFocusSetting = mLayout.AddSlider("Autofocus", false);
        mLayout.AddGap(2);
        mCameraFlashSettings = mLayout.AddSlider("Flash", false);
        mLayout.AddGap(16);
        mCameraLabel = mLayout.AddGroupLabel("Camera");
        string[] options = { "Front", "Rear" };
        mCameraFacing = mLayout.AddToggleOptions(options, 1);
        mLayout.AddGap(14);
        mButtonLabel = mLayout.AddGroupLabel("Button");
        mVirtualYellowButton = mLayout.AddSlider_Type2("Yellow", true);
        mLayout.AddGap(2);
        mVirtualRedButton = mLayout.AddSlider_Type2("Red", true);
        mLayout.AddGap(2);
        mVirtualGreenButton = mLayout.AddSlider_Type2("Green", true);
        mLayout.AddGap(2);
        mVirtualBlueButton = mLayout.AddSlider_Type2("Blue", true);
        Rect CloseButtonRect = new Rect(0, Screen.height - (100 * Screen.width) / 800.0f, Screen.width, (70.0f * Screen.width) / 800.0f);
        mCloseButton = mLayout.AddButton("Close", CloseButtonRect);
    }
    
    public void UnLoadView()
    {
        mHeaderLabel = null;
        mAboutButton = null;
        mCameraFlashSettings = null;
        mAutoFocusSetting = null;
        mCameraLabel = null;
        mCameraFacing = null;
        mVirtualYellowButton = null;
        mVirtualGreenButton = null;
        mVirtualBlueButton = null;
        mVirtualRedButton = null;
    }
    
    public void UpdateUI(bool tf)
    {
        if(!tf)
        {
            return;
        }

        mLayout.Draw();
    }

    public void OnTappedToClose ()
    {
        if(this.TappedToClose != null)
        {
            this.TappedToClose();
        }
    }
    #endregion PUBLIC_METHODS

}
