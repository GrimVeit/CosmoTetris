using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    public MainState_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToSettings_Main += ChangeStateToSettings;
        _sceneRoot.OnClickToGuide_Main += ChangeStateToGuide;
        _sceneRoot.OnClickToPrivacyPolicy_Main += ChangeStateToPrivacyPolicy;

        _sceneRoot.OpenMainPanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToSettings_Main -= ChangeStateToSettings;
        _sceneRoot.OnClickToGuide_Main -= ChangeStateToGuide;
        _sceneRoot.OnClickToPrivacyPolicy_Main -= ChangeStateToPrivacyPolicy;

        _sceneRoot.CloseMainPanel();
    }

    private void ChangeStateToSettings()
    {
        _machineProvider.SetState(_machineProvider.GetState<SettingsState_Menu>());
    }

    private void ChangeStateToGuide()
    {
        _machineProvider.SetState(_machineProvider.GetState<GuideState_Menu>());
    }

    private void ChangeStateToPrivacyPolicy()
    {

    }
}
