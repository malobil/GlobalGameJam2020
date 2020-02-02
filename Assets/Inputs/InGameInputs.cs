// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/InGameInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InGameInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InGameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InGameInputs"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""74ec69a1-b36a-489f-af08-28aad66f0ad3"",
            ""actions"": [
                {
                    ""name"": ""Spatule"",
                    ""type"": ""Button"",
                    ""id"": ""32130b8a-1e4d-4064-9b5e-cd73870840fa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.8)""
                },
                {
                    ""name"": ""Knife"",
                    ""type"": ""Button"",
                    ""id"": ""2cac57c3-d926-4750-a1fd-837ff6efdf87"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Tongs"",
                    ""type"": ""Button"",
                    ""id"": ""bb4f7f7e-b936-486f-9045-f5f86c48c41f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Sucker"",
                    ""type"": ""Button"",
                    ""id"": ""87b4c5c4-8250-4f36-9b77-e9d5d02cc4de"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ad4d535e-40a0-4419-afaa-bfe0b3337df2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spatule"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60414893-b2ee-4496-8039-f2d31ef8d91d"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spatule"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4c90d25-faa9-42ed-aed5-ad74e59944c4"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spatule"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""135c5b44-5f8a-46db-b9e3-cc12fd60b490"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Knife"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9465291f-9e75-4f78-9dab-dac281b6d68b"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Knife"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69cf34c9-6839-42c5-a291-2e56600c7f58"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Knife"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92638b87-d737-40ac-816e-cdfdb1a329b7"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tongs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5ec6c58-a84a-44a3-b484-856e964c010c"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tongs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7180ebf-06d7-4532-b3fc-7eceb2986753"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tongs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6680280-cdd5-4ae0-aef3-5d10d5737aad"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sucker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3fc70ca-641e-43d1-8b37-90f1ffe7dc15"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sucker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10c91913-15e3-41ce-ae59-05689ad8591b"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sucker"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InMenu"",
            ""id"": ""75b1c435-0784-45c5-874e-fc1327abe29b"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""9793b146-2346-479d-b6d5-cbfc9bfe9162"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""a224a956-5077-483d-9d08-37d11cf83816"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""883205bc-1f5e-4377-ab85-435995f24535"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da394753-9b17-4b69-8ad6-b49b398e2c48"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e012ab26-331b-4b6c-b227-d8fc1f538a1e"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04c833b6-b48b-43ec-b9ac-690a406c44c2"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_Spatule = m_InGame.FindAction("Spatule", throwIfNotFound: true);
        m_InGame_Knife = m_InGame.FindAction("Knife", throwIfNotFound: true);
        m_InGame_Tongs = m_InGame.FindAction("Tongs", throwIfNotFound: true);
        m_InGame_Sucker = m_InGame.FindAction("Sucker", throwIfNotFound: true);
        // InMenu
        m_InMenu = asset.FindActionMap("InMenu", throwIfNotFound: true);
        m_InMenu_Submit = m_InMenu.FindAction("Submit", throwIfNotFound: true);
        m_InMenu_MousePosition = m_InMenu.FindAction("MousePosition", throwIfNotFound: true);
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

    // InGame
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_Spatule;
    private readonly InputAction m_InGame_Knife;
    private readonly InputAction m_InGame_Tongs;
    private readonly InputAction m_InGame_Sucker;
    public struct InGameActions
    {
        private @InGameInputs m_Wrapper;
        public InGameActions(@InGameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Spatule => m_Wrapper.m_InGame_Spatule;
        public InputAction @Knife => m_Wrapper.m_InGame_Knife;
        public InputAction @Tongs => m_Wrapper.m_InGame_Tongs;
        public InputAction @Sucker => m_Wrapper.m_InGame_Sucker;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @Spatule.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnSpatule;
                @Spatule.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnSpatule;
                @Spatule.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnSpatule;
                @Knife.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnKnife;
                @Knife.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnKnife;
                @Knife.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnKnife;
                @Tongs.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnTongs;
                @Tongs.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnTongs;
                @Tongs.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnTongs;
                @Sucker.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnSucker;
                @Sucker.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnSucker;
                @Sucker.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnSucker;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Spatule.started += instance.OnSpatule;
                @Spatule.performed += instance.OnSpatule;
                @Spatule.canceled += instance.OnSpatule;
                @Knife.started += instance.OnKnife;
                @Knife.performed += instance.OnKnife;
                @Knife.canceled += instance.OnKnife;
                @Tongs.started += instance.OnTongs;
                @Tongs.performed += instance.OnTongs;
                @Tongs.canceled += instance.OnTongs;
                @Sucker.started += instance.OnSucker;
                @Sucker.performed += instance.OnSucker;
                @Sucker.canceled += instance.OnSucker;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);

    // InMenu
    private readonly InputActionMap m_InMenu;
    private IInMenuActions m_InMenuActionsCallbackInterface;
    private readonly InputAction m_InMenu_Submit;
    private readonly InputAction m_InMenu_MousePosition;
    public struct InMenuActions
    {
        private @InGameInputs m_Wrapper;
        public InMenuActions(@InGameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_InMenu_Submit;
        public InputAction @MousePosition => m_Wrapper.m_InMenu_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_InMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InMenuActions set) { return set.Get(); }
        public void SetCallbacks(IInMenuActions instance)
        {
            if (m_Wrapper.m_InMenuActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_InMenuActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_InMenuActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_InMenuActionsCallbackInterface.OnSubmit;
                @MousePosition.started -= m_Wrapper.m_InMenuActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_InMenuActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_InMenuActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_InMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public InMenuActions @InMenu => new InMenuActions(this);
    public interface IInGameActions
    {
        void OnSpatule(InputAction.CallbackContext context);
        void OnKnife(InputAction.CallbackContext context);
        void OnTongs(InputAction.CallbackContext context);
        void OnSucker(InputAction.CallbackContext context);
    }
    public interface IInMenuActions
    {
        void OnSubmit(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
