//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/GameCore/Inputs/GameInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""eebfaba3-7e1e-46ae-aecb-b54ce959c0e9"",
            ""actions"": [
                {
                    ""name"": ""CameraMoveControl"",
                    ""type"": ""Value"",
                    ""id"": ""a46896fc-b074-4193-81b6-2cf6b0aff040"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""InvertVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ScreenClick"",
                    ""type"": ""Button"",
                    ""id"": ""7941f300-3c4f-4d7c-9a56-6b57b50a5bf3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GridClick"",
                    ""type"": ""Button"",
                    ""id"": ""73d82180-fe84-48cc-80d2-b2df750b6c96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ScreenClickPos"",
                    ""type"": ""Value"",
                    ""id"": ""dcef9788-625b-4762-8ec5-e9e8eab3463d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Spawn"",
                    ""type"": ""Button"",
                    ""id"": ""f01c8c11-fcc1-4eb5-ad24-34c1f9844fee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DeSpawn"",
                    ""type"": ""Button"",
                    ""id"": ""10672b82-d7db-4aee-ab20-7dbd9b9d2f75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""15cb4f50-79a4-4588-a405-54f4e3f6fbf0"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""CameraMoveControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""915acaf1-4aab-4216-b4f7-20c5cdaa8ebb"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScreenClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecd68098-1fd6-4b0a-bb5f-b4d8db0a505d"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GridClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e5cf768-154f-4120-8522-844685efadae"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScreenClickPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""876ea660-c628-49e4-9963-afc33e2674ee"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d2981d8-1c70-4f2b-94ec-ad6bad983087"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e837f0e0-6ce3-4161-aedf-124b6978fedc"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeSpawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_CameraMoveControl = m_Player.FindAction("CameraMoveControl", throwIfNotFound: true);
        m_Player_ScreenClick = m_Player.FindAction("ScreenClick", throwIfNotFound: true);
        m_Player_GridClick = m_Player.FindAction("GridClick", throwIfNotFound: true);
        m_Player_ScreenClickPos = m_Player.FindAction("ScreenClickPos", throwIfNotFound: true);
        m_Player_Spawn = m_Player.FindAction("Spawn", throwIfNotFound: true);
        m_Player_DeSpawn = m_Player.FindAction("DeSpawn", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_CameraMoveControl;
    private readonly InputAction m_Player_ScreenClick;
    private readonly InputAction m_Player_GridClick;
    private readonly InputAction m_Player_ScreenClickPos;
    private readonly InputAction m_Player_Spawn;
    private readonly InputAction m_Player_DeSpawn;
    public struct PlayerActions
    {
        private @GameInput m_Wrapper;
        public PlayerActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraMoveControl => m_Wrapper.m_Player_CameraMoveControl;
        public InputAction @ScreenClick => m_Wrapper.m_Player_ScreenClick;
        public InputAction @GridClick => m_Wrapper.m_Player_GridClick;
        public InputAction @ScreenClickPos => m_Wrapper.m_Player_ScreenClickPos;
        public InputAction @Spawn => m_Wrapper.m_Player_Spawn;
        public InputAction @DeSpawn => m_Wrapper.m_Player_DeSpawn;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @CameraMoveControl.started += instance.OnCameraMoveControl;
            @CameraMoveControl.performed += instance.OnCameraMoveControl;
            @CameraMoveControl.canceled += instance.OnCameraMoveControl;
            @ScreenClick.started += instance.OnScreenClick;
            @ScreenClick.performed += instance.OnScreenClick;
            @ScreenClick.canceled += instance.OnScreenClick;
            @GridClick.started += instance.OnGridClick;
            @GridClick.performed += instance.OnGridClick;
            @GridClick.canceled += instance.OnGridClick;
            @ScreenClickPos.started += instance.OnScreenClickPos;
            @ScreenClickPos.performed += instance.OnScreenClickPos;
            @ScreenClickPos.canceled += instance.OnScreenClickPos;
            @Spawn.started += instance.OnSpawn;
            @Spawn.performed += instance.OnSpawn;
            @Spawn.canceled += instance.OnSpawn;
            @DeSpawn.started += instance.OnDeSpawn;
            @DeSpawn.performed += instance.OnDeSpawn;
            @DeSpawn.canceled += instance.OnDeSpawn;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @CameraMoveControl.started -= instance.OnCameraMoveControl;
            @CameraMoveControl.performed -= instance.OnCameraMoveControl;
            @CameraMoveControl.canceled -= instance.OnCameraMoveControl;
            @ScreenClick.started -= instance.OnScreenClick;
            @ScreenClick.performed -= instance.OnScreenClick;
            @ScreenClick.canceled -= instance.OnScreenClick;
            @GridClick.started -= instance.OnGridClick;
            @GridClick.performed -= instance.OnGridClick;
            @GridClick.canceled -= instance.OnGridClick;
            @ScreenClickPos.started -= instance.OnScreenClickPos;
            @ScreenClickPos.performed -= instance.OnScreenClickPos;
            @ScreenClickPos.canceled -= instance.OnScreenClickPos;
            @Spawn.started -= instance.OnSpawn;
            @Spawn.performed -= instance.OnSpawn;
            @Spawn.canceled -= instance.OnSpawn;
            @DeSpawn.started -= instance.OnDeSpawn;
            @DeSpawn.performed -= instance.OnDeSpawn;
            @DeSpawn.canceled -= instance.OnDeSpawn;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnCameraMoveControl(InputAction.CallbackContext context);
        void OnScreenClick(InputAction.CallbackContext context);
        void OnGridClick(InputAction.CallbackContext context);
        void OnScreenClickPos(InputAction.CallbackContext context);
        void OnSpawn(InputAction.CallbackContext context);
        void OnDeSpawn(InputAction.CallbackContext context);
    }
}
