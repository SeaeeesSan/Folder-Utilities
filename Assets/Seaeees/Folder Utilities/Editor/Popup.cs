using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Seaeees.Folder_Utilities.Editor
{
    public class Popup : EditorWindow
    {
        private readonly string[] _optionNames = {"Scenes", "Prefabs", "Scripts", "Animations", "Materials", "Physics", "Fonts", "Textures", "Audio", "Resources", "Editor", "Plugins"};

        private bool[] _options = new bool[12];

        private bool _initialized = true;

        [MenuItem("Assets/Create/Folder Utilities",false,0)]
        static void Init()
        {
            Popup window = CreateInstance<Popup>();
            window.ShowPopup();
        }

        void OnGUI()
        {
            if (_initialized)
            {
                position = new Rect(Event.current.mousePosition,new Vector2(150,305));
                _initialized = false;
            }

            EditorGUILayout.LabelField("Folder Utilities",EditorStyles.boldLabel);

            for (int i = 0; i < 12; i++)
            {
                _options[i] = EditorGUILayout.ToggleLeft(_optionNames[i], _options[i]);
            }

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("o")) ResetOptions(true);
            if (GUILayout.Button("x")) ResetOptions(false);
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("OK"))
            {
                FolderCreator.MakeFolders(Check());
                Close();
            }

            if (Event.current.keyCode == KeyCode.Escape)
            {
                Close();
            }
        }

        void ResetOptions(bool n)
        {
            for (int i = 0; i < _options.Length; i++) _options[i] = n;
        }

        List<string> Check()
        {
            List<string> flag = new List<string>();
            for (int i = 0; i < _options.Length; i++)
                if(_options[i])
                    flag.Add(_optionNames[i]);
            return flag;
        }
    }
}
