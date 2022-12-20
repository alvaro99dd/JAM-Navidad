//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.1.1
//     from Assets/Scripts/Controls.inputactions
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
            ""name"": ""Movement"",
            ""id"": ""5416e756-def9-48f2-be31-4a386ec725a1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""fc0465c3-616d-4418-ad4f-a4af69d8f2eb"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e64375aa-7bed-4933-a87b-edea817eb7e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""509a2915-37cf-41ac-9b37-fde98d12ad35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Meditate"",
                    ""type"": ""Button"",
                    ""id"": ""1d7ba1b8-5c18-4570-ae41-ce5a368e81ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""3dac18db-df44-4296-a5b8-9e5610f70088"",
                    ""path"": ""3DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""bc7d3686-ca9e-4367-8d9b-19e7ccd0df73"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""d4df7ed9-ffc6-4e27-a13f-ed8a854a2ea4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Forward"",
                    ""id"": ""cc51ce77-c65c-4c2b-9120-aabab3b594de"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Backward"",
                    ""id"": ""d8f8f9ce-d6b2-4113-a5b0-732e1c5f6e03"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""74620f15-5e4a-4660-be26-07346468c53a"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a823d891-acdd-4695-b8da-2f664806f7b8"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""17341e08-a7e5-4be2-b00e-3f97e6eab01e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""ca3020ee-2444-4163-8538-939c9dbc2510"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""2bedf402-7062-4250-8945-16a8ba13e504"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bd26de12-538a-421b-8087-b22fc1cbcb6a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f647129-92a0-4ff2-9f19-1bb5a2bc7a73"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51624190-96fe-4411-aa14-c410cf317bf3"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c0577a1-6cd7-40b7-bf97-763ba13bb0a1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d60c7789-1e94-4a22-8996-9c36067ae177"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Meditate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38bcc1a8-ff4e-4c8d-962d-b12bac13548b"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Meditate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Skills"",
            ""id"": ""bf0dd6fd-f326-494d-bb14-218cd1a93cbb"",
            ""actions"": [
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""3fde254c-d0fc-49e9-afbf-ef342e721026"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Travel"",
                    ""type"": ""Button"",
                    ""id"": ""c5a00719-091d-4092-8cf8-4ad3b59e6f7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8cff163c-6502-48b6-91c7-37b0dc0d8830"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52287abe-ed81-480c-b82e-91052779cf52"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c33b2958-c393-48f0-a98e-8eceb41295f4"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Travel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9a25b93-3795-4e4f-acf2-8fbf4897989b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Travel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameActions"",
            ""id"": ""6fda4db3-ad7d-440b-aaf6-9b25d3c71b7e"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""7931aee0-1424-4e35-8776-e125eb815e34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""147dbc93-d1f8-4a7e-9d72-0abaa8272aec"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f757112f-ab8f-4fda-b79b-5fe6178f603a"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_Roll = m_Movement.FindAction("Roll", throwIfNotFound: true);
        m_Movement_Meditate = m_Movement.FindAction("Meditate", throwIfNotFound: true);
        // Skills
        m_Skills = asset.FindActionMap("Skills", throwIfNotFound: true);
        m_Skills_Throw = m_Skills.FindAction("Throw", throwIfNotFound: true);
        m_Skills_Travel = m_Skills.FindAction("Travel", throwIfNotFound: true);
        // GameActions
        m_GameActions = asset.FindActionMap("GameActions", throwIfNotFound: true);
        m_GameActions_Pause = m_GameActions.FindAction("Pause", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_Roll;
    private readonly InputAction m_Movement_Meditate;
    public struct MovementActions
    {
        private @Controls m_Wrapper;
        public MovementActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @Roll => m_Wrapper.m_Movement_Roll;
        public InputAction @Meditate => m_Wrapper.m_Movement_Meditate;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Roll.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRoll;
                @Meditate.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMeditate;
                @Meditate.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMeditate;
                @Meditate.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMeditate;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Meditate.started += instance.OnMeditate;
                @Meditate.performed += instance.OnMeditate;
                @Meditate.canceled += instance.OnMeditate;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Skills
    private readonly InputActionMap m_Skills;
    private ISkillsActions m_SkillsActionsCallbackInterface;
    private readonly InputAction m_Skills_Throw;
    private readonly InputAction m_Skills_Travel;
    public struct SkillsActions
    {
        private @Controls m_Wrapper;
        public SkillsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throw => m_Wrapper.m_Skills_Throw;
        public InputAction @Travel => m_Wrapper.m_Skills_Travel;
        public InputActionMap Get() { return m_Wrapper.m_Skills; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SkillsActions set) { return set.Get(); }
        public void SetCallbacks(ISkillsActions instance)
        {
            if (m_Wrapper.m_SkillsActionsCallbackInterface != null)
            {
                @Throw.started -= m_Wrapper.m_SkillsActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_SkillsActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_SkillsActionsCallbackInterface.OnThrow;
                @Travel.started -= m_Wrapper.m_SkillsActionsCallbackInterface.OnTravel;
                @Travel.performed -= m_Wrapper.m_SkillsActionsCallbackInterface.OnTravel;
                @Travel.canceled -= m_Wrapper.m_SkillsActionsCallbackInterface.OnTravel;
            }
            m_Wrapper.m_SkillsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @Travel.started += instance.OnTravel;
                @Travel.performed += instance.OnTravel;
                @Travel.canceled += instance.OnTravel;
            }
        }
    }
    public SkillsActions @Skills => new SkillsActions(this);

    // GameActions
    private readonly InputActionMap m_GameActions;
    private IGameActionsActions m_GameActionsActionsCallbackInterface;
    private readonly InputAction m_GameActions_Pause;
    public struct GameActionsActions
    {
        private @Controls m_Wrapper;
        public GameActionsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GameActions_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GameActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActionsActions set) { return set.Get(); }
        public void SetCallbacks(IGameActionsActions instance)
        {
            if (m_Wrapper.m_GameActionsActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameActionsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameActionsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameActionsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameActionsActions @GameActions => new GameActionsActions(this);
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnMeditate(InputAction.CallbackContext context);
    }
    public interface ISkillsActions
    {
        void OnThrow(InputAction.CallbackContext context);
        void OnTravel(InputAction.CallbackContext context);
    }
    public interface IGameActionsActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
