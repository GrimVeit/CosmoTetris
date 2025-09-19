using System;
using UnityEngine;

public class UIMainMenuRoot : UIRoot
{
    [SerializeField] private MainPanel_Menu mainPanel;
    [SerializeField] private SettingsPanel_Menu settingsPanel;
    [SerializeField] private GuidePanel_Menu guidePanel;

    private ISoundProvider _soundProvider;

    public void SetSoundProvider(ISoundProvider soundProvider)
    {
        _soundProvider = soundProvider;
    }

    public void Initialize()
    {
        mainPanel.Initialize();
        settingsPanel.Initialize();
        guidePanel.Initialize();
    }

    public void Activate()
    {
        mainPanel.OnClickToPlay += HandleClickToPlay_Main;
        mainPanel.OnClickToSettings += HandleClickToSettings_Main;
        mainPanel.OnClickToGuide += HandleClickToGuide_Main;
        mainPanel.OnClickToPrivacyPolicy += HandleClickToPrivacyPolicy_Main;

        settingsPanel.OnClickToBack += HandleClickToBack_Settings;

        guidePanel.OnClickToBack += HandleClickToBack_Guide;
    }


    public void Deactivate()
    {
        mainPanel.OnClickToPlay -= HandleClickToPlay_Main;
        mainPanel.OnClickToSettings -= HandleClickToSettings_Main;
        mainPanel.OnClickToGuide -= HandleClickToGuide_Main;
        mainPanel.OnClickToPrivacyPolicy -= HandleClickToPrivacyPolicy_Main;

        settingsPanel.OnClickToBack -= HandleClickToBack_Settings;

        guidePanel.OnClickToBack -= HandleClickToBack_Guide;

        if (currentPanel != null)
            CloseOtherPanel(currentPanel);
    }

    public void Dispose()
    {
        mainPanel.Dispose();
        settingsPanel.Dispose();
        guidePanel.Dispose();
    }

    #region Input

    public void OpenMainPanel()
    {
        OpenOtherPanel(mainPanel);
    }

    public void CloseMainPanel()
    {
        CloseOtherPanel(mainPanel);
    }



    public void OpenSettingsPanel()
    {
        OpenOtherPanel(settingsPanel);
    }

    public void CloseSettingsPanel()
    {
        CloseOtherPanel(settingsPanel);
    }



    public void OpenGuidePanel()
    {
        OpenOtherPanel(guidePanel);
    }

    public void CloseGuidePanel()
    {
        CloseOtherPanel(guidePanel);
    }

    #endregion


    #region Output

    //////////////////////////////////////////

    public event Action OnClickToPlay_Main;
    public event Action OnClickToSettings_Main;
    public event Action OnClickToGuide_Main;
    public event Action OnClickToPrivacyPolicy_Main;

    private void HandleClickToPlay_Main()
    {
        OnClickToPlay_Main?.Invoke();
    }

    private void HandleClickToSettings_Main()
    {
        OnClickToSettings_Main?.Invoke();
    }

    private void HandleClickToGuide_Main()
    {
        OnClickToGuide_Main?.Invoke();
    }

    private void HandleClickToPrivacyPolicy_Main()
    {
        OnClickToPrivacyPolicy_Main?.Invoke();
    }

    //////////////////////////////////////////

    public event Action OnClickToBack_Settings;

    private void HandleClickToBack_Settings()
    {
        OnClickToBack_Settings?.Invoke();
    }

    //////////////////////////////////////////

    public event Action OnClickToBack_Guide;

    private void HandleClickToBack_Guide()
    {
        OnClickToBack_Guide?.Invoke();
    }

    #endregion

}
