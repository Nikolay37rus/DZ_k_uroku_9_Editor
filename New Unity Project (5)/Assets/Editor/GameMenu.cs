using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
   
        
        [MenuItem("Game/Clear player prefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }

        [MenuItem("Game/Take screenshot")]
        public static void TakeScreenshot()
        {
            string path = "Screenshots";

            Directory.CreateDirectory(path);

            int i = 0;
            while (File.Exists(path + "/" + i + ".png")) i++;

            ScreenCapture.CaptureScreenshot(path + "/" + i + ".png");
        }

        [MenuItem("Game/Tools/Pos all trees")]
        public static void PositionAllTrees()
        {
            TreeBase[] trees = Object.FindObjectsOfType<TreeBase>();

            Undo.RecordObjects(trees.Select(t => t.transform).ToArray(), "pos all trees");

            foreach (var tree in trees)
            {
                tree.PositionTree();
            }
        }

        [MenuItem("Game/Check current scene for Standard material")]
        private static void CheckMaterials()
        {
            bool found = false;
            foreach (MeshRenderer renderer in Object.FindObjectsOfType<MeshRenderer>())
            {
                foreach (Material material in renderer.sharedMaterials)
                {
                    if (material.shader.name == "Standard")
                    {
                        Debug.LogError(material.shader.name, renderer);
                        found = true;
                    }
                }
            }

            if (!found) Debug.Log("Well done, no any Standard materials on current scene!");
        }
    }

