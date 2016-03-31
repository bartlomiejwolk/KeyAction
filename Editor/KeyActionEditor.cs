// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the KeyAction extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace KeyActionEx {

    [CustomEditor(typeof(KeyAction))]
    [CanEditMultipleObjects]
    public sealed class KeyActionEditor : Editor {
        #region FIELDS

        private KeyAction Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty inputMethod;
        private SerializedProperty keyInputType;
        private SerializedProperty keyCode;
        private SerializedProperty axeName;
        private SerializedProperty callbacks;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawInputMethodDropdown();
            DrawKeyInputTypeDropdown();
            DrawKeyCodeDropdown();
            DrawAxeNameDropdown();

            EditorGUILayout.Space();

            DrawCallbacksList();

            serializedObject.ApplyModifiedProperties();
        }
        private void OnEnable() {
            Script = (KeyAction)target;

            description = serializedObject.FindProperty("description");
            inputMethod = serializedObject.FindProperty("inputMethod");
            keyInputType = serializedObject.FindProperty("keyInputType");
            keyCode = serializedObject.FindProperty("keyCode");
            axeName = serializedObject.FindProperty("axeName");
            callbacks = serializedObject.FindProperty("callbacks");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS
        private void DrawCallbacksList() {
            EditorGUILayout.PropertyField(
                callbacks,
                new GUIContent(
                    "Callbacks",
                    ""));
        }

        private void DrawAxeNameDropdown() {
            if (keyInputType.enumValueIndex != (int) KeyType.String) return;

            EditorGUILayout.PropertyField(
                axeName,
                new GUIContent(
                    "Axe Name",
                    "Name of the input axes."));
        }

        private void DrawKeyInputTypeDropdown() {
            if (inputMethod.enumValueIndex != (int) InputMethod.GetKey
                && inputMethod.enumValueIndex != (int) InputMethod.GetKeyDown) {

                return;
            }

            EditorGUILayout.PropertyField(
                keyInputType,
                new GUIContent(
                    "Key Type",
                    ""));
        }

        private void DrawKeyCodeDropdown() {
            if (keyInputType.enumValueIndex != (int) KeyType.KeyCode) return;

            EditorGUILayout.PropertyField(
                keyCode,
                new GUIContent(
                    "Key",
                    ""));
        }

        private void DrawInputMethodDropdown() {
            EditorGUILayout.PropertyField(
                inputMethod,
                new GUIContent(
                    "Input Method",
                    ""));
        }


        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    KeyAction.Version,
                    KeyAction.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR
        #region METHODS

        [MenuItem("Component/Component Framework/KeyAction")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(KeyAction));
            }
        }

        #endregion METHODS
    }

}