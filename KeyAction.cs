// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the KeyAction extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEngine;
using UnityEngine.Events;

namespace KeyActionEx {

    public sealed class KeyAction : MonoBehaviour {

        #region CONSTANTS

        public const string Version = "v0.1.0";
        public const string Extension = "KeyAction";

        #endregion CONSTANTS

        #region DELEGATES
        #endregion DELEGATES

        #region EVENTS
        #endregion EVENTS

        #region FIELDS

#pragma warning disable 0414
        /// <summary>
        ///     Allows identify component in the scene file when reading it with
        ///     text editor.
        /// </summary>
        [SerializeField]
        private string componentName = "KeyAction";
#pragma warning restore 0414

        #endregion FIELDS

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        [SerializeField]
        private InputMethod inputMethod;

        [SerializeField]
        private KeyType keyInputType;

        [SerializeField]
        private KeyCode keyCode;

        [SerializeField]
        private string axeName;

        [SerializeField]
        private UnityEvent callbacks;

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        /// <summary>
        ///     Optional text to describe purpose of this instance of the component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        public InputMethod InputMethod {
            get { return inputMethod; }
            set { inputMethod = value; }
        }

        public KeyCode KeyCode {
            get { return keyCode; }
            set { keyCode = value; }
        }

        public KeyType KeyInputType {
            get { return keyInputType; }
            set { keyInputType = value; }
        }

        public string AxeName {
            get { return axeName; }
            set { axeName = value; }
        }

        public UnityEvent Callbacks {
            get { return callbacks; }
            set { callbacks = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void Awake() { }

        private void FixedUpdate() { }

        private void LateUpdate() { }

        private void OnEnable() { }

        private void Reset() { }

        private void Start() { }

        private void Update() {
            HandleInputMethod();
        }

        private void HandleInputMethod() {
            HandleGetKeyDownInputMethod();
            HandleGetButtonInputMethod();
            // todo implement HandleGetKeyInputMethod()
        }

        private void HandleGetButtonInputMethod() {
            if (InputMethod != InputMethod.GetButton) {
                return;
            }


            if (Input.GetButton(AxeName)) {
                Callbacks.Invoke();
            }
        }

        private void HandleGetKeyDownInputMethod() {
            if (InputMethod != InputMethod.GetKeyDown) {
                return;
            }

            switch (KeyInputType) {
                case KeyType.KeyCode:
                    if (Input.GetKeyDown(KeyCode)) {
                        Callbacks.Invoke();
                    }
                    break;
                case KeyType.String:
                    if (Input.GetKeyDown(AxeName)) {
                        Callbacks.Invoke();
                    }
                    break;
            }
        }

        private void OnValidate() { }

        private void OnDisable() { }

        private void OnDestroy() { }

        #endregion UNITY MESSAGES

        #region EVENT INVOCATORS
        #endregion INVOCATORS

        #region EVENT HANDLERS
        #endregion EVENT HANDLERS

        #region METHODS
        #endregion METHODS

    }

}