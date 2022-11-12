//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Controls/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Generic"",
            ""id"": ""2890aa49-b0eb-40c6-9b49-9f2b4eb66561"",
            ""actions"": [
                {
                    ""name"": ""LeftAxis"",
                    ""type"": ""Value"",
                    ""id"": ""36691a22-3135-4460-be4f-0fa844deb606"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LeftAction"",
                    ""type"": ""Button"",
                    ""id"": ""01bad9ac-cc2f-4fc6-86ce-02de1559c73f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightAction"",
                    ""type"": ""Button"",
                    ""id"": ""c36e0afd-6ba5-4c09-bbcb-5ec40508bf11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightAxis"",
                    ""type"": ""Value"",
                    ""id"": ""023687f0-5851-4733-90e4-61281e4f2ac3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""42a30337-3d4f-460d-94a8-96866eb9f2c2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f5448478-ab35-42f7-a91c-540ea78bcd9a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""aeef7aed-21b2-4fc2-987e-c232623d9eda"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2c546ac1-eb30-42d7-b7e1-d17e386fec4d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""beaa4847-ebe2-4b7e-bbca-367ce9d58612"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e104561d-0b1a-4737-b74d-aa6e67e3c744"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f85e0e01-e174-41cf-922e-2639da25b9a5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""213c1304-fef6-4bb5-aa40-9f84c6e4c7c5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""c72d1fb7-dcfa-4211-80ca-ac71779d40b2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7daebbfe-004f-491a-8b69-3721e6578aa7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6b075d69-a1aa-4143-b5ee-f2846de38afd"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e0e5de0c-2171-4ea9-a653-62a901f3fb5f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5ee329d0-cf8c-4b41-aea5-8ff2ca6db9db"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6be788ea-b6bc-4a44-acf2-51d4b029b5ab"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Buttons"",
                    ""id"": ""d87ef914-4a77-464c-9f38-53e4ea9e2afa"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""42552336-75f7-4f6a-ae12-1f1bd4766f05"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bafd5885-a2cf-434c-9e2a-31b0e58ed4e4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b2788c74-306d-448c-8b92-55d1bba56868"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b77d8ea7-8a4b-498e-933c-66afc11eb2c7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Generic
        m_Generic = asset.FindActionMap("Generic", throwIfNotFound: true);
        m_Generic_LeftAxis = m_Generic.FindAction("LeftAxis", throwIfNotFound: true);
        m_Generic_LeftAction = m_Generic.FindAction("LeftAction", throwIfNotFound: true);
        m_Generic_RightAction = m_Generic.FindAction("RightAction", throwIfNotFound: true);
        m_Generic_RightAxis = m_Generic.FindAction("RightAxis", throwIfNotFound: true);
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

    // Generic
    private readonly InputActionMap m_Generic;
    private IGenericActions m_GenericActionsCallbackInterface;
    private readonly InputAction m_Generic_LeftAxis;
    private readonly InputAction m_Generic_LeftAction;
    private readonly InputAction m_Generic_RightAction;
    private readonly InputAction m_Generic_RightAxis;
    public struct GenericActions
    {
        private @Controls m_Wrapper;
        public GenericActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftAxis => m_Wrapper.m_Generic_LeftAxis;
        public InputAction @LeftAction => m_Wrapper.m_Generic_LeftAction;
        public InputAction @RightAction => m_Wrapper.m_Generic_RightAction;
        public InputAction @RightAxis => m_Wrapper.m_Generic_RightAxis;
        public InputActionMap Get() { return m_Wrapper.m_Generic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GenericActions set) { return set.Get(); }
        public void SetCallbacks(IGenericActions instance)
        {
            if (m_Wrapper.m_GenericActionsCallbackInterface != null)
            {
                @LeftAxis.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnLeftAxis;
                @LeftAxis.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnLeftAxis;
                @LeftAxis.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnLeftAxis;
                @LeftAction.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnLeftAction;
                @LeftAction.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnLeftAction;
                @LeftAction.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnLeftAction;
                @RightAction.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnRightAction;
                @RightAction.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnRightAction;
                @RightAction.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnRightAction;
                @RightAxis.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnRightAxis;
                @RightAxis.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnRightAxis;
                @RightAxis.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnRightAxis;
            }
            m_Wrapper.m_GenericActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftAxis.started += instance.OnLeftAxis;
                @LeftAxis.performed += instance.OnLeftAxis;
                @LeftAxis.canceled += instance.OnLeftAxis;
                @LeftAction.started += instance.OnLeftAction;
                @LeftAction.performed += instance.OnLeftAction;
                @LeftAction.canceled += instance.OnLeftAction;
                @RightAction.started += instance.OnRightAction;
                @RightAction.performed += instance.OnRightAction;
                @RightAction.canceled += instance.OnRightAction;
                @RightAxis.started += instance.OnRightAxis;
                @RightAxis.performed += instance.OnRightAxis;
                @RightAxis.canceled += instance.OnRightAxis;
            }
        }
    }
    public GenericActions @Generic => new GenericActions(this);
    public interface IGenericActions
    {
        void OnLeftAxis(InputAction.CallbackContext context);
        void OnLeftAction(InputAction.CallbackContext context);
        void OnRightAction(InputAction.CallbackContext context);
        void OnRightAxis(InputAction.CallbackContext context);
    }
}
