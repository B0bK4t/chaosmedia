// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Personnage/PlayerControlsBeta.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlsBeta : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlsBeta()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlsBeta"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""92d9972f-976d-4187-9d65-126fe6cc91cd"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""889f177e-ef55-45ff-8961-32d436ed7e00"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ouvrir"",
                    ""type"": ""Value"",
                    ""id"": ""51b2d853-8002-4632-a444-c258315cbb6f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Button"",
                    ""id"": ""e03925fa-71de-444d-9c1b-fef32bee4829"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""interactionJeuxBas"",
                    ""type"": ""Button"",
                    ""id"": ""776240f4-dbd7-41ae-b298-8a594035a9ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""interactionJeuxHaut"",
                    ""type"": ""Button"",
                    ""id"": ""1ac066e5-c120-40d3-8403-baa70c0ed114"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""interactionJeuxDroite"",
                    ""type"": ""Button"",
                    ""id"": ""8e6d0a77-82ca-4e29-b945-a3c87d4e3637"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""interactionJeuxGauche"",
                    ""type"": ""Value"",
                    ""id"": ""bad51680-e3f1-4ddb-b9b2-94930633b928"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9fc79fe7-a757-418e-a658-b8a6bd1d97d1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""5add9981-f451-44d1-8041-7f8b62a2ce3f"",
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
                    ""id"": ""616994a2-6248-4127-8f07-a74a1a1bc2a0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""576a8b66-df13-4d36-bba9-901424c143ae"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""87e57a49-02ca-46ac-97f7-c235ad08d6b1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""abc5c879-fb73-4b8d-bc21-76a3025cb7bc"",
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
                    ""id"": ""7e81bffa-dd96-4932-bf10-4fb856d826b1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ouvrir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cbebad3-39d0-4460-b9e8-93b9f686c3b8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ouvrir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""388e5132-7b35-42c8-92d8-20a4c884d986"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ouvrir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""733a625c-74f9-4e22-91a4-ffb8d68bf5e2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0dbca769-c8bd-4e2d-9355-b469438c1bb5"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""interactionJeuxBas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12507d58-6c45-4403-b60f-6b17c4fa3848"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""interactionJeuxHaut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""105e9ed6-9e46-49dc-b175-ab0f1832500c"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""interactionJeuxDroite"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b252b46c-c8cb-45e7-ad3a-60e190ac7bd3"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""interactionJeuxGauche"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""id"": ""d8b8c22c-700b-4b2c-a14a-eaad606203b5"",
            ""actions"": [
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""af2b718c-2bb2-4f20-9940-bb36e9db3c73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8f1db833-fdbd-4009-94e9-23e00d463d83"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""63f8c2ca-bd5f-4b4c-bc7f-fcc840dc11cc"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd462c9c-c77a-410c-921b-ed08e3790129"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryPosition"",
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
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Ouvrir = m_Player.FindAction("Ouvrir", throwIfNotFound: true);
        m_Player_Camera = m_Player.FindAction("Camera", throwIfNotFound: true);
        m_Player_interactionJeuxBas = m_Player.FindAction("interactionJeuxBas", throwIfNotFound: true);
        m_Player_interactionJeuxHaut = m_Player.FindAction("interactionJeuxHaut", throwIfNotFound: true);
        m_Player_interactionJeuxDroite = m_Player.FindAction("interactionJeuxDroite", throwIfNotFound: true);
        m_Player_interactionJeuxGauche = m_Player.FindAction("interactionJeuxGauche", throwIfNotFound: true);
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_PrimaryContact = m_Touch.FindAction("PrimaryContact", throwIfNotFound: true);
        m_Touch_PrimaryPosition = m_Touch.FindAction("PrimaryPosition", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Ouvrir;
    private readonly InputAction m_Player_Camera;
    private readonly InputAction m_Player_interactionJeuxBas;
    private readonly InputAction m_Player_interactionJeuxHaut;
    private readonly InputAction m_Player_interactionJeuxDroite;
    private readonly InputAction m_Player_interactionJeuxGauche;
    public struct PlayerActions
    {
        private @PlayerControlsBeta m_Wrapper;
        public PlayerActions(@PlayerControlsBeta wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Ouvrir => m_Wrapper.m_Player_Ouvrir;
        public InputAction @Camera => m_Wrapper.m_Player_Camera;
        public InputAction @interactionJeuxBas => m_Wrapper.m_Player_interactionJeuxBas;
        public InputAction @interactionJeuxHaut => m_Wrapper.m_Player_interactionJeuxHaut;
        public InputAction @interactionJeuxDroite => m_Wrapper.m_Player_interactionJeuxDroite;
        public InputAction @interactionJeuxGauche => m_Wrapper.m_Player_interactionJeuxGauche;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Ouvrir.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuvrir;
                @Ouvrir.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuvrir;
                @Ouvrir.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOuvrir;
                @Camera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @interactionJeuxBas.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxBas;
                @interactionJeuxBas.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxBas;
                @interactionJeuxBas.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxBas;
                @interactionJeuxHaut.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxHaut;
                @interactionJeuxHaut.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxHaut;
                @interactionJeuxHaut.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxHaut;
                @interactionJeuxDroite.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxDroite;
                @interactionJeuxDroite.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxDroite;
                @interactionJeuxDroite.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxDroite;
                @interactionJeuxGauche.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxGauche;
                @interactionJeuxGauche.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxGauche;
                @interactionJeuxGauche.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionJeuxGauche;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Ouvrir.started += instance.OnOuvrir;
                @Ouvrir.performed += instance.OnOuvrir;
                @Ouvrir.canceled += instance.OnOuvrir;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @interactionJeuxBas.started += instance.OnInteractionJeuxBas;
                @interactionJeuxBas.performed += instance.OnInteractionJeuxBas;
                @interactionJeuxBas.canceled += instance.OnInteractionJeuxBas;
                @interactionJeuxHaut.started += instance.OnInteractionJeuxHaut;
                @interactionJeuxHaut.performed += instance.OnInteractionJeuxHaut;
                @interactionJeuxHaut.canceled += instance.OnInteractionJeuxHaut;
                @interactionJeuxDroite.started += instance.OnInteractionJeuxDroite;
                @interactionJeuxDroite.performed += instance.OnInteractionJeuxDroite;
                @interactionJeuxDroite.canceled += instance.OnInteractionJeuxDroite;
                @interactionJeuxGauche.started += instance.OnInteractionJeuxGauche;
                @interactionJeuxGauche.performed += instance.OnInteractionJeuxGauche;
                @interactionJeuxGauche.canceled += instance.OnInteractionJeuxGauche;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_PrimaryContact;
    private readonly InputAction m_Touch_PrimaryPosition;
    public struct TouchActions
    {
        private @PlayerControlsBeta m_Wrapper;
        public TouchActions(@PlayerControlsBeta wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryContact => m_Wrapper.m_Touch_PrimaryContact;
        public InputAction @PrimaryPosition => m_Wrapper.m_Touch_PrimaryPosition;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @PrimaryContact.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryContact;
                @PrimaryPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryContact.started += instance.OnPrimaryContact;
                @PrimaryContact.performed += instance.OnPrimaryContact;
                @PrimaryContact.canceled += instance.OnPrimaryContact;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnOuvrir(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnInteractionJeuxBas(InputAction.CallbackContext context);
        void OnInteractionJeuxHaut(InputAction.CallbackContext context);
        void OnInteractionJeuxDroite(InputAction.CallbackContext context);
        void OnInteractionJeuxGauche(InputAction.CallbackContext context);
    }
    public interface ITouchActions
    {
        void OnPrimaryContact(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
    }
}
