using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideState_Menu : IState
{
    private readonly IGlobalStateMachineProvider _machineProvider;
    private readonly UIMainMenuRoot _sceneRoot;

    public GuideState_Menu(IGlobalStateMachineProvider machineProvider, UIMainMenuRoot sceneRoot)
    {
        _machineProvider = machineProvider;
        _sceneRoot = sceneRoot;
    }

    public void EnterState()
    {
        _sceneRoot.OnClickToBack_Guide += ChangeStateToMain;

        _sceneRoot.OpenGuidePanel();
    }

    public void ExitState()
    {
        _sceneRoot.OnClickToBack_Guide -= ChangeStateToMain;

        _sceneRoot.CloseGuidePanel();
    }

    private void ChangeStateToMain()
    {
        _machineProvider.SetState(_machineProvider.GetState<MainState_Menu>());
    }
}
