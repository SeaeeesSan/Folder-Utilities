using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Seaeees.Folder_Utilities.Editor
{
    public class Popup : EditorWindow
    {
        private int _flags;

        private readonly string[] _options = {"  ", "Scenes", "Prefabs", "Scripts", "Animations", "Materials", "Physics", "Fonts", "Textures", "Audio", "Resources", "Editor", "Plugins"};

        private bool _initialized = true;

        [MenuItem("Assets/Create/Folder Utilities/Presets",false,0)]
        static void Init()
        {
            Popup window = CreateInstance<Popup>();
            window.ShowPopup();
        }

        void OnGUI()
        {
            if (_initialized)
            {
                position = new Rect(Event.current.mousePosition,new Vector2(300,50));
                _initialized = false;
            }
            _flags = EditorGUILayout.MaskField("Folder Name", _flags, _options);

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Close"))
            {
                Close();
            }

            if (GUILayout.Button("Ok"))
            {
                FolderCreator.MakeFolders(Check(_flags));
                Close();
            }
            EditorGUILayout.EndHorizontal();

            if (Event.current.keyCode == KeyCode.Escape)
            {
                Close();
            }
        }

        List<string> Check(int flags)
        {
            List<string> flag = new List<string>();
            if ((flags & 1 << 1) != 0)  flag.Add("Scenes");
            if ((flags & 1 << 2) != 0)  flag.Add("Prefabs");
            if ((flags & 1 << 3) != 0)  flag.Add("Scripts");
            if ((flags & 1 << 4) != 0)  flag.Add("Animations");
            if ((flags & 1 << 5) != 0)  flag.Add("Materials");
            if ((flags & 1 << 6) != 0)  flag.Add("Physics");
            if ((flags & 1 << 7) != 0)  flag.Add("Fonts");
            if ((flags & 1 << 8) != 0)  flag.Add("Textures");
            if ((flags & 1 << 9) != 0)  flag.Add("Audio");
            if ((flags & 1 << 10) != 0)  flag.Add("Resources");
            if ((flags & 1 << 11) != 0)  flag.Add("Editor");
            if ((flags & 1 << 12) != 0)  flag.Add("Plugins");

            return flag;
        }
    }
}
