// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/DrivingControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace VR_Road.InputSystem
{
    public class @DrivingControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @DrivingControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""DrivingControls"",
    ""maps"": [
        {
            ""name"": ""Driving"",
            ""id"": ""d33fb7b2-8f3e-48bc-a49b-5144a13239af"",
            ""actions"": [
                {
                    ""name"": ""Steering"",
                    ""type"": ""Value"",
                    ""id"": ""01e15380-2921-4321-a37f-fbd02c88939a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PaddleTopRight"",
                    ""type"": ""Button"",
                    ""id"": ""9fb66fd5-7fbe-4d66-bf0e-f5cd99139cdb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PaddleTopLeft"",
                    ""type"": ""Button"",
                    ""id"": ""514e8332-1ac3-4d73-ae3e-280dff82354e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PaddleBottomLeft"",
                    ""type"": ""Value"",
                    ""id"": ""788cdfb1-4765-45f0-b16f-87e53c207041"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PaddleBottomRight"",
                    ""type"": ""Value"",
                    ""id"": ""d4bb6096-407c-4ac9-87f5-6cf11da0f266"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Home Button"",
                    ""type"": ""Button"",
                    ""id"": ""ab1e5ddc-d4ed-431a-a6d0-906835871a48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drive Gear"",
                    ""type"": ""Button"",
                    ""id"": ""cee18ec8-b5e2-4851-ab17-ec9cc4ab57ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reverse Gear"",
                    ""type"": ""Button"",
                    ""id"": ""ed3dd8d5-ff8e-4505-9357-71e7a24a5ac9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake Pedal"",
                    ""type"": ""Value"",
                    ""id"": ""a6fa0401-836f-411d-80e0-1a50cebb1dd0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerator Pedal"",
                    ""type"": ""Value"",
                    ""id"": ""19474090-f881-41f2-af96-9e66fa258c2b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5c0a8ee5-7425-49d7-a347-590cab64177c"",
                    ""path"": ""<HID::PXN PXN-V99>/stick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa8d0797-2e07-4145-af27-710f9678fdcd"",
                    ""path"": ""<HID::PXN PXN-V99>/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PaddleTopRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4530e864-5f4b-4116-816a-80e44fa05c74"",
                    ""path"": ""<HID::PXN PXN-V99>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PaddleTopLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3cddc59-f577-464b-b090-5804c6b9f6bc"",
                    ""path"": ""<HID::PXN PXN-V99>/rx"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PaddleBottomLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f9c1a08-259d-48ac-a803-88f5de6d9d57"",
                    ""path"": ""<HID::PXN PXN-V99>/ry"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PaddleBottomRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6553b21f-3d9b-459b-9ce7-0aab11c36658"",
                    ""path"": ""<HID::PXN PXN-V99>/button13"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Home Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc24bf8d-5a37-4f73-80f3-9798aff6ee1b"",
                    ""path"": ""<HID::PXN PXN-V99>/button20"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drive Gear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fca156f6-a691-420d-ab11-ddd76a9c3d25"",
                    ""path"": ""<HID::PXN PXN-V99>/button19"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reverse Gear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c0f98fd-9f54-4805-89ba-288131e34d74"",
                    ""path"": ""<HID::PXN PXN-V99>/rz"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake Pedal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68ed2b74-52dd-4303-84cd-cab0dee1ad3d"",
                    ""path"": ""<HID::PXN PXN-V99>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerator Pedal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Driving
            m_Driving = asset.FindActionMap("Driving", throwIfNotFound: true);
            m_Driving_Steering = m_Driving.FindAction("Steering", throwIfNotFound: true);
            m_Driving_PaddleTopRight = m_Driving.FindAction("PaddleTopRight", throwIfNotFound: true);
            m_Driving_PaddleTopLeft = m_Driving.FindAction("PaddleTopLeft", throwIfNotFound: true);
            m_Driving_PaddleBottomLeft = m_Driving.FindAction("PaddleBottomLeft", throwIfNotFound: true);
            m_Driving_PaddleBottomRight = m_Driving.FindAction("PaddleBottomRight", throwIfNotFound: true);
            m_Driving_HomeButton = m_Driving.FindAction("Home Button", throwIfNotFound: true);
            m_Driving_DriveGear = m_Driving.FindAction("Drive Gear", throwIfNotFound: true);
            m_Driving_ReverseGear = m_Driving.FindAction("Reverse Gear", throwIfNotFound: true);
            m_Driving_BrakePedal = m_Driving.FindAction("Brake Pedal", throwIfNotFound: true);
            m_Driving_AcceleratorPedal = m_Driving.FindAction("Accelerator Pedal", throwIfNotFound: true);
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

        // Driving
        private readonly InputActionMap m_Driving;
        private IDrivingActions m_DrivingActionsCallbackInterface;
        private readonly InputAction m_Driving_Steering;
        private readonly InputAction m_Driving_PaddleTopRight;
        private readonly InputAction m_Driving_PaddleTopLeft;
        private readonly InputAction m_Driving_PaddleBottomLeft;
        private readonly InputAction m_Driving_PaddleBottomRight;
        private readonly InputAction m_Driving_HomeButton;
        private readonly InputAction m_Driving_DriveGear;
        private readonly InputAction m_Driving_ReverseGear;
        private readonly InputAction m_Driving_BrakePedal;
        private readonly InputAction m_Driving_AcceleratorPedal;
        public struct DrivingActions
        {
            private @DrivingControls m_Wrapper;
            public DrivingActions(@DrivingControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Steering => m_Wrapper.m_Driving_Steering;
            public InputAction @PaddleTopRight => m_Wrapper.m_Driving_PaddleTopRight;
            public InputAction @PaddleTopLeft => m_Wrapper.m_Driving_PaddleTopLeft;
            public InputAction @PaddleBottomLeft => m_Wrapper.m_Driving_PaddleBottomLeft;
            public InputAction @PaddleBottomRight => m_Wrapper.m_Driving_PaddleBottomRight;
            public InputAction @HomeButton => m_Wrapper.m_Driving_HomeButton;
            public InputAction @DriveGear => m_Wrapper.m_Driving_DriveGear;
            public InputAction @ReverseGear => m_Wrapper.m_Driving_ReverseGear;
            public InputAction @BrakePedal => m_Wrapper.m_Driving_BrakePedal;
            public InputAction @AcceleratorPedal => m_Wrapper.m_Driving_AcceleratorPedal;
            public InputActionMap Get() { return m_Wrapper.m_Driving; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DrivingActions set) { return set.Get(); }
            public void SetCallbacks(IDrivingActions instance)
            {
                if (m_Wrapper.m_DrivingActionsCallbackInterface != null)
                {
                    @Steering.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnSteering;
                    @Steering.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnSteering;
                    @Steering.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnSteering;
                    @PaddleTopRight.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleTopRight;
                    @PaddleTopRight.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleTopRight;
                    @PaddleTopRight.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleTopRight;
                    @PaddleTopLeft.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleTopLeft;
                    @PaddleTopLeft.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleTopLeft;
                    @PaddleTopLeft.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleTopLeft;
                    @PaddleBottomLeft.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleBottomLeft;
                    @PaddleBottomLeft.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleBottomLeft;
                    @PaddleBottomLeft.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleBottomLeft;
                    @PaddleBottomRight.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleBottomRight;
                    @PaddleBottomRight.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleBottomRight;
                    @PaddleBottomRight.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnPaddleBottomRight;
                    @HomeButton.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnHomeButton;
                    @HomeButton.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnHomeButton;
                    @HomeButton.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnHomeButton;
                    @DriveGear.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnDriveGear;
                    @DriveGear.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnDriveGear;
                    @DriveGear.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnDriveGear;
                    @ReverseGear.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnReverseGear;
                    @ReverseGear.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnReverseGear;
                    @ReverseGear.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnReverseGear;
                    @BrakePedal.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnBrakePedal;
                    @BrakePedal.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnBrakePedal;
                    @BrakePedal.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnBrakePedal;
                    @AcceleratorPedal.started -= m_Wrapper.m_DrivingActionsCallbackInterface.OnAcceleratorPedal;
                    @AcceleratorPedal.performed -= m_Wrapper.m_DrivingActionsCallbackInterface.OnAcceleratorPedal;
                    @AcceleratorPedal.canceled -= m_Wrapper.m_DrivingActionsCallbackInterface.OnAcceleratorPedal;
                }
                m_Wrapper.m_DrivingActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Steering.started += instance.OnSteering;
                    @Steering.performed += instance.OnSteering;
                    @Steering.canceled += instance.OnSteering;
                    @PaddleTopRight.started += instance.OnPaddleTopRight;
                    @PaddleTopRight.performed += instance.OnPaddleTopRight;
                    @PaddleTopRight.canceled += instance.OnPaddleTopRight;
                    @PaddleTopLeft.started += instance.OnPaddleTopLeft;
                    @PaddleTopLeft.performed += instance.OnPaddleTopLeft;
                    @PaddleTopLeft.canceled += instance.OnPaddleTopLeft;
                    @PaddleBottomLeft.started += instance.OnPaddleBottomLeft;
                    @PaddleBottomLeft.performed += instance.OnPaddleBottomLeft;
                    @PaddleBottomLeft.canceled += instance.OnPaddleBottomLeft;
                    @PaddleBottomRight.started += instance.OnPaddleBottomRight;
                    @PaddleBottomRight.performed += instance.OnPaddleBottomRight;
                    @PaddleBottomRight.canceled += instance.OnPaddleBottomRight;
                    @HomeButton.started += instance.OnHomeButton;
                    @HomeButton.performed += instance.OnHomeButton;
                    @HomeButton.canceled += instance.OnHomeButton;
                    @DriveGear.started += instance.OnDriveGear;
                    @DriveGear.performed += instance.OnDriveGear;
                    @DriveGear.canceled += instance.OnDriveGear;
                    @ReverseGear.started += instance.OnReverseGear;
                    @ReverseGear.performed += instance.OnReverseGear;
                    @ReverseGear.canceled += instance.OnReverseGear;
                    @BrakePedal.started += instance.OnBrakePedal;
                    @BrakePedal.performed += instance.OnBrakePedal;
                    @BrakePedal.canceled += instance.OnBrakePedal;
                    @AcceleratorPedal.started += instance.OnAcceleratorPedal;
                    @AcceleratorPedal.performed += instance.OnAcceleratorPedal;
                    @AcceleratorPedal.canceled += instance.OnAcceleratorPedal;
                }
            }
        }
        public DrivingActions @Driving => new DrivingActions(this);
        public interface IDrivingActions
        {
            void OnSteering(InputAction.CallbackContext context);
            void OnPaddleTopRight(InputAction.CallbackContext context);
            void OnPaddleTopLeft(InputAction.CallbackContext context);
            void OnPaddleBottomLeft(InputAction.CallbackContext context);
            void OnPaddleBottomRight(InputAction.CallbackContext context);
            void OnHomeButton(InputAction.CallbackContext context);
            void OnDriveGear(InputAction.CallbackContext context);
            void OnReverseGear(InputAction.CallbackContext context);
            void OnBrakePedal(InputAction.CallbackContext context);
            void OnAcceleratorPedal(InputAction.CallbackContext context);
        }
    }
}
