using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Seaeees.Folder_Utilities
{
    public static class FolderCreator
    {
        public static void MakeFolders(List<string> names)
        {
            foreach (var name in names)
            {
                MakeFolder(name);
            }
        }

        private static void MakeFolder(string name)
        {
            foreach (Object obj in Selection.GetFiltered(typeof(DefaultAsset), SelectionMode.Assets))
            {
                if (obj is DefaultAsset)
                {
                    string path = AssetDatabase.GetAssetPath(obj);

                    if(AssetDatabase.IsValidFolder(path))
                    {
                        AssetDatabase.CreateFolder(path, name);
                    }
                }
            }
        }
    }
}
