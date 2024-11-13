//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.1
//     from Assets/Inputs/PlayerActions.inputactions
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

public partial class @PlayerActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControl"",
            ""id"": ""56b4d7f2-6a38-41e5-a346-07adb7835e4d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fe139d52-31bf-4f77-bbf2-997927d4125d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Concentration"",
                    ""type"": ""Button"",
                    ""id"": ""07699a48-50bd-406c-9430-08893cafb242"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""ae560930-323a-4c95-b375-5fa1eeb15bb5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow"",
                    ""id"": ""3f1133b0-603f-4a92-aa27-29d66206b1c8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5746b2be-30ae-4971-bb33-cbb93b7034d5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4bd2dfdb-5a2a-4931-94a9-5a7f5645ccfe"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""15afb609-b1ea-4ae7-b8c0-fe2bafd529e0"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1c998900-eba2-41cb-a3cd-2a450b336656"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""1e4168a6-2251-4771-baa0-0a6e70d1cc36"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1d69d535-b2b4-4b87-874c-41e1f53a89ac"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c77717b7-3c0a-4a7e-acee-10a8ecac66d7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6b097351-a64a-4b72-ae51-417e1f98c4ea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c1dc87e1-a848-4a3d-90a5-ca97dd191c45"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""376235f3-fa0a-4413-8cf7-b1d95dde3720"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";PC"",
                    ""action"": ""Concentration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""677d3e92-ed4e-4bef-a732-0fe39fc6b5a9"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";PC"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""799a2f51-9b6e-4c72-9da7-682260cd09f1"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainTitle"",
            ""id"": ""a5b15b72-0354-4525-ab7f-a1a83f7d8efc"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""860b7478-b67d-43b5-bb7f-70175e84623e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""f2053231-cc4a-49d3-a3a0-072a960bcf81"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""37389cbb-81a0-4c2f-873d-86e8b72c1aa1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8ba5e5c-1f5c-41ce-b355-89ff83bddb14"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3eaa2976-2a27-4605-991c-664350c29020"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc80016c-753e-421b-b44d-7fddb6304e9f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControl
        m_PlayerControl = asset.FindActionMap("PlayerControl", throwIfNotFound: true);
        m_PlayerControl_Move = m_PlayerControl.FindAction("Move", throwIfNotFound: true);
        m_PlayerControl_Concentration = m_PlayerControl.FindAction("Concentration", throwIfNotFound: true);
        m_PlayerControl_Shoot = m_PlayerControl.FindAction("Shoot", throwIfNotFound: true);
        // MainTitle
        m_MainTitle = asset.FindActionMap("MainTitle", throwIfNotFound: true);
        m_MainTitle_Up = m_MainTitle.FindAction("Up", throwIfNotFound: true);
        m_MainTitle_Down = m_MainTitle.FindAction("Down", throwIfNotFound: true);
    }

    ~@PlayerActions()
    {
        UnityEngine.Debug.Assert(!m_PlayerControl.enabled, "This will cause a leak and performance issues, PlayerActions.PlayerControl.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_MainTitle.enabled, "This will cause a leak and performance issues, PlayerActions.MainTitle.Disable() has not been called.");
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

    // PlayerControl
    private readonly InputActionMap m_PlayerControl;
    private List<IPlayerControlActions> m_PlayerControlActionsCallbackInterfaces = new List<IPlayerControlActions>();
    private readonly InputAction m_PlayerControl_Move;
    private readonly InputAction m_PlayerControl_Concentration;
    private readonly InputAction m_PlayerControl_Shoot;
    public struct PlayerControlActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerControlActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControl_Move;
        public InputAction @Concentration => m_Wrapper.m_PlayerControl_Concentration;
        public InputAction @Shoot => m_Wrapper.m_PlayerControl_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerControlActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerControlActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Concentration.started += instance.OnConcentration;
            @Concentration.performed += instance.OnConcentration;
            @Concentration.canceled += instance.OnConcentration;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IPlayerControlActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Concentration.started -= instance.OnConcentration;
            @Concentration.performed -= instance.OnConcentration;
            @Concentration.canceled -= instance.OnConcentration;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerControlActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);

    // MainTitle
    private readonly InputActionMap m_MainTitle;
    private List<IMainTitleActions> m_MainTitleActionsCallbackInterfaces = new List<IMainTitleActions>();
    private readonly InputAction m_MainTitle_Up;
    private readonly InputAction m_MainTitle_Down;
    public struct MainTitleActions
    {
        private @PlayerActions m_Wrapper;
        public MainTitleActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_MainTitle_Up;
        public InputAction @Down => m_Wrapper.m_MainTitle_Down;
        public InputActionMap Get() { return m_Wrapper.m_MainTitle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainTitleActions set) { return set.Get(); }
        public void AddCallbacks(IMainTitleActions instance)
        {
            if (instance == null || m_Wrapper.m_MainTitleActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MainTitleActionsCallbackInterfaces.Add(instance);
            @Up.started += instance.OnUp;
            @Up.performed += instance.OnUp;
            @Up.canceled += instance.OnUp;
            @Down.started += instance.OnDown;
            @Down.performed += instance.OnDown;
            @Down.canceled += instance.OnDown;
        }

        private void UnregisterCallbacks(IMainTitleActions instance)
        {
            @Up.started -= instance.OnUp;
            @Up.performed -= instance.OnUp;
            @Up.canceled -= instance.OnUp;
            @Down.started -= instance.OnDown;
            @Down.performed -= instance.OnDown;
            @Down.canceled -= instance.OnDown;
        }

        public void RemoveCallbacks(IMainTitleActions instance)
        {
            if (m_Wrapper.m_MainTitleActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMainTitleActions instance)
        {
            foreach (var item in m_Wrapper.m_MainTitleActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MainTitleActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MainTitleActions @MainTitle => new MainTitleActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IPlayerControlActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnConcentration(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IMainTitleActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}
