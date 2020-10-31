// GENERATED AUTOMATICALLY FROM 'Assets/Input System/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""PlayerShip"",
            ""id"": ""8b19ad32-8eef-408e-8eb1-b90b1a09324c"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""d3f21e0a-a0de-4032-bcfe-3ebf84815b96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""b17c6f8e-52c8-41c6-97b0-a96ae09d1ee8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""1708ba86-956b-49fd-9b30-727fa5240ff1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""971e7ea7-d55e-426d-8c3d-2012e1ecd5eb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c7e6a8d-47ec-4bb8-b01e-866463bf48c6"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fee8afa7-ef72-4ac4-be76-299fd18fa59b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d8f7e97-7244-43ab-b7e5-caa47e97e5b8"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1756a542-a58c-42b8-bf5c-f61ecf731b8c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3bddf24-3db0-4b9f-a130-9861e0dbe84b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerShip
        m_PlayerShip = asset.FindActionMap("PlayerShip", throwIfNotFound: true);
        m_PlayerShip_Up = m_PlayerShip.FindAction("Up", throwIfNotFound: true);
        m_PlayerShip_Down = m_PlayerShip.FindAction("Down", throwIfNotFound: true);
        m_PlayerShip_Fire = m_PlayerShip.FindAction("Fire", throwIfNotFound: true);
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

    // PlayerShip
    private readonly InputActionMap m_PlayerShip;
    private IPlayerShipActions m_PlayerShipActionsCallbackInterface;
    private readonly InputAction m_PlayerShip_Up;
    private readonly InputAction m_PlayerShip_Down;
    private readonly InputAction m_PlayerShip_Fire;
    public struct PlayerShipActions
    {
        private @GameControls m_Wrapper;
        public PlayerShipActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_PlayerShip_Up;
        public InputAction @Down => m_Wrapper.m_PlayerShip_Down;
        public InputAction @Fire => m_Wrapper.m_PlayerShip_Fire;
        public InputActionMap Get() { return m_Wrapper.m_PlayerShip; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerShipActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerShipActions instance)
        {
            if (m_Wrapper.m_PlayerShipActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnDown;
                @Fire.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_PlayerShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public PlayerShipActions @PlayerShip => new PlayerShipActions(this);
    public interface IPlayerShipActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
