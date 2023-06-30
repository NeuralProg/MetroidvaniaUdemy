//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/Input/Controls.inputactions
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

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""8e7db122-967d-45bc-aeea-918ccd91f372"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b6809040-455a-480b-9ec5-bba20cf407f3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ZQSD"",
                    ""id"": ""90433083-92a7-4035-bb46-a6686349afc5"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""530b0b4a-d581-4dfc-9731-a6f0d0e64cf1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3079a787-9a5e-4506-8c5e-00916fd69c29"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6610a90d-be96-45ec-814d-4ef0772236e5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""863e02e1-8883-4fd5-8682-982cfef22d49"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""3815d5b9-a6f3-403e-bb04-803c53314159"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""402a8a77-172d-47b3-a74b-d3c10c58be27"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9714e8fb-a54b-4077-8999-07e488677b34"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4a4c7d4b-9cf6-42a1-8314-f81ea3925425"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b367e64e-7013-4aec-80e8-50fc7f2b8e7b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Analog"",
                    ""id"": ""fc32e032-343c-4a46-9b4b-a771c2fbc1b9"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""738cb220-8e53-4a09-b582-95ef0dd3d59d"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d1f2e8db-efb9-4154-a1f1-6493da80519b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""26636ff6-c8de-442e-8e9e-83d90b1d3f49"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8f59f9b5-c27b-4865-befd-d870a2524b94"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""7aa7a4b4-5e88-4b54-a03a-b03fa6cff0c7"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""321baa71-31c6-474e-97dd-a01b36a07417"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dea83dc9-99e8-43dc-ae67-6dec6f39911d"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""53b0e83e-f1ce-4002-8290-f3a842d0f4ab"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d0416b3e-f2df-4c9d-a97b-569eb5b9c9e7"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Jumping"",
            ""id"": ""9d25718b-5b9a-4657-8b1b-a8ff5f3e81ba"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""df75bb9e-939b-4625-b017-40199fd6359b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""38bc99ec-ca99-4cd9-8212-9c014eafca7f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb0e2424-026b-4fa9-ad0f-dae940ac17fe"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Shooting"",
            ""id"": ""d66e0963-9f80-44fd-8aac-bca137238bc4"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""efddc113-f814-4fca-aa06-829729b9e22d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""958562bb-def5-4ac5-8e7e-337d616b3ec1"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d0def22-0b0c-4fb8-ad93-275550d3aefc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""164cbc76-b9dd-4771-a0d0-c68e08e148e7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dashing"",
            ""id"": ""1f71a48f-7586-4797-bde4-76a2f837085b"",
            ""actions"": [
                {
                    ""name"": ""Dash"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6d416624-a8b3-43a4-afc5-c8ad542b829e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""64d3f6eb-10de-43dc-ab52-82ea315f3250"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a1726df-e6c4-404b-9cb8-0e09997fe921"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfb8fd44-3fe6-4419-b58b-f9206c655556"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SwitchingState"",
            ""id"": ""c406d234-bd3b-4332-9d38-cba3100b1cf7"",
            ""actions"": [
                {
                    ""name"": ""Switch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9517869a-cb70-4038-976a-a06cfda1aef3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""294d77ac-283a-4673-a7f3-cc767a1cc89c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""474b5390-f97c-4bbb-a7cd-adb4beccef80"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Healing"",
            ""id"": ""c485d318-0d06-4a74-97a3-333e3c8aafd0"",
            ""actions"": [
                {
                    ""name"": ""Heal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ed7b5fcf-45a4-48c5-95b2-0195779e5c0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f1d3dffb-775d-4f64-9f42-14c33e032503"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d011451-e144-4c28-bb41-8d61c6ec6568"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        // Jumping
        m_Jumping = asset.FindActionMap("Jumping", throwIfNotFound: true);
        m_Jumping_Jump = m_Jumping.FindAction("Jump", throwIfNotFound: true);
        // Shooting
        m_Shooting = asset.FindActionMap("Shooting", throwIfNotFound: true);
        m_Shooting_Shoot = m_Shooting.FindAction("Shoot", throwIfNotFound: true);
        // Dashing
        m_Dashing = asset.FindActionMap("Dashing", throwIfNotFound: true);
        m_Dashing_Dash = m_Dashing.FindAction("Dash", throwIfNotFound: true);
        // SwitchingState
        m_SwitchingState = asset.FindActionMap("SwitchingState", throwIfNotFound: true);
        m_SwitchingState_Switch = m_SwitchingState.FindAction("Switch", throwIfNotFound: true);
        // Healing
        m_Healing = asset.FindActionMap("Healing", throwIfNotFound: true);
        m_Healing_Heal = m_Healing.FindAction("Heal", throwIfNotFound: true);
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
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Move;
    public struct MovementActions
    {
        private @Controls m_Wrapper;
        public MovementActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Jumping
    private readonly InputActionMap m_Jumping;
    private List<IJumpingActions> m_JumpingActionsCallbackInterfaces = new List<IJumpingActions>();
    private readonly InputAction m_Jumping_Jump;
    public struct JumpingActions
    {
        private @Controls m_Wrapper;
        public JumpingActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Jumping_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Jumping; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JumpingActions set) { return set.Get(); }
        public void AddCallbacks(IJumpingActions instance)
        {
            if (instance == null || m_Wrapper.m_JumpingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_JumpingActionsCallbackInterfaces.Add(instance);
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IJumpingActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IJumpingActions instance)
        {
            if (m_Wrapper.m_JumpingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IJumpingActions instance)
        {
            foreach (var item in m_Wrapper.m_JumpingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_JumpingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public JumpingActions @Jumping => new JumpingActions(this);

    // Shooting
    private readonly InputActionMap m_Shooting;
    private List<IShootingActions> m_ShootingActionsCallbackInterfaces = new List<IShootingActions>();
    private readonly InputAction m_Shooting_Shoot;
    public struct ShootingActions
    {
        private @Controls m_Wrapper;
        public ShootingActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Shooting_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Shooting; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShootingActions set) { return set.Get(); }
        public void AddCallbacks(IShootingActions instance)
        {
            if (instance == null || m_Wrapper.m_ShootingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ShootingActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IShootingActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IShootingActions instance)
        {
            if (m_Wrapper.m_ShootingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IShootingActions instance)
        {
            foreach (var item in m_Wrapper.m_ShootingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ShootingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ShootingActions @Shooting => new ShootingActions(this);

    // Dashing
    private readonly InputActionMap m_Dashing;
    private List<IDashingActions> m_DashingActionsCallbackInterfaces = new List<IDashingActions>();
    private readonly InputAction m_Dashing_Dash;
    public struct DashingActions
    {
        private @Controls m_Wrapper;
        public DashingActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash => m_Wrapper.m_Dashing_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Dashing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DashingActions set) { return set.Get(); }
        public void AddCallbacks(IDashingActions instance)
        {
            if (instance == null || m_Wrapper.m_DashingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DashingActionsCallbackInterfaces.Add(instance);
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
        }

        private void UnregisterCallbacks(IDashingActions instance)
        {
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
        }

        public void RemoveCallbacks(IDashingActions instance)
        {
            if (m_Wrapper.m_DashingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDashingActions instance)
        {
            foreach (var item in m_Wrapper.m_DashingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DashingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DashingActions @Dashing => new DashingActions(this);

    // SwitchingState
    private readonly InputActionMap m_SwitchingState;
    private List<ISwitchingStateActions> m_SwitchingStateActionsCallbackInterfaces = new List<ISwitchingStateActions>();
    private readonly InputAction m_SwitchingState_Switch;
    public struct SwitchingStateActions
    {
        private @Controls m_Wrapper;
        public SwitchingStateActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Switch => m_Wrapper.m_SwitchingState_Switch;
        public InputActionMap Get() { return m_Wrapper.m_SwitchingState; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SwitchingStateActions set) { return set.Get(); }
        public void AddCallbacks(ISwitchingStateActions instance)
        {
            if (instance == null || m_Wrapper.m_SwitchingStateActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SwitchingStateActionsCallbackInterfaces.Add(instance);
            @Switch.started += instance.OnSwitch;
            @Switch.performed += instance.OnSwitch;
            @Switch.canceled += instance.OnSwitch;
        }

        private void UnregisterCallbacks(ISwitchingStateActions instance)
        {
            @Switch.started -= instance.OnSwitch;
            @Switch.performed -= instance.OnSwitch;
            @Switch.canceled -= instance.OnSwitch;
        }

        public void RemoveCallbacks(ISwitchingStateActions instance)
        {
            if (m_Wrapper.m_SwitchingStateActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISwitchingStateActions instance)
        {
            foreach (var item in m_Wrapper.m_SwitchingStateActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SwitchingStateActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SwitchingStateActions @SwitchingState => new SwitchingStateActions(this);

    // Healing
    private readonly InputActionMap m_Healing;
    private List<IHealingActions> m_HealingActionsCallbackInterfaces = new List<IHealingActions>();
    private readonly InputAction m_Healing_Heal;
    public struct HealingActions
    {
        private @Controls m_Wrapper;
        public HealingActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Heal => m_Wrapper.m_Healing_Heal;
        public InputActionMap Get() { return m_Wrapper.m_Healing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HealingActions set) { return set.Get(); }
        public void AddCallbacks(IHealingActions instance)
        {
            if (instance == null || m_Wrapper.m_HealingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HealingActionsCallbackInterfaces.Add(instance);
            @Heal.started += instance.OnHeal;
            @Heal.performed += instance.OnHeal;
            @Heal.canceled += instance.OnHeal;
        }

        private void UnregisterCallbacks(IHealingActions instance)
        {
            @Heal.started -= instance.OnHeal;
            @Heal.performed -= instance.OnHeal;
            @Heal.canceled -= instance.OnHeal;
        }

        public void RemoveCallbacks(IHealingActions instance)
        {
            if (m_Wrapper.m_HealingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHealingActions instance)
        {
            foreach (var item in m_Wrapper.m_HealingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_HealingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HealingActions @Healing => new HealingActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IJumpingActions
    {
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IShootingActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IDashingActions
    {
        void OnDash(InputAction.CallbackContext context);
    }
    public interface ISwitchingStateActions
    {
        void OnSwitch(InputAction.CallbackContext context);
    }
    public interface IHealingActions
    {
        void OnHeal(InputAction.CallbackContext context);
    }
}
