using System;
using System.Collections.Generic;

public class StateMachine_Menu : IGlobalStateMachineProvider
{
    private readonly Dictionary<Type, IState> states = new();

    private IState _currentState;

    public StateMachine_Menu(UIMainMenuRoot sceneRoot)
    {
        states[typeof(MainState_Menu)] = new MainState_Menu(this, sceneRoot);
        states[typeof(SettingsState_Menu)] = new SettingsState_Menu(this, sceneRoot);
        states[typeof(GuideState_Menu)] = new GuideState_Menu(this, sceneRoot);
    }

    public void Initialize()
    {
        SetState(GetState<MainState_Menu>());
    }

    public void Dispose()
    {

    }

    public IState GetState<T>() where T : IState
    {
        return states[typeof(T)];
    }

    public void SetState(IState state)
    {
        _currentState?.ExitState();

        _currentState = state;
        _currentState.EnterState();
    }
}
