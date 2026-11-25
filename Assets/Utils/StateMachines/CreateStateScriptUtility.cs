using UnityEngine;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using System.IO;

namespace StateMachines.Templates
{
    public class CreateStateScriptUtility
    {
        [MenuItem("Assets/Create/Scripting/State", false, 80)]
        public static void CreateState()
        {
            string templatePath = "Assets/Utils/StateMachines/StateScriptTemplate.cs.txt";
            if (!File.Exists(templatePath))
            {
                Debug.LogError($"Template not found at: {templatePath}\nCreate the file StateScriptTemplate.cs.txt in the Assets/Editor/Templates/ folder");
                return;
            }

            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
                0,
                ScriptableObject.CreateInstance<DoCreateStateScript>(),
                "NewState.cs",
                EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D,
                templatePath
            );
        }

        internal class DoCreateStateScript : EndNameEditAction
        {
            public override void Action(int instanceId, string pathName, string resourceFile)
            {
                string templateContent = File.ReadAllText(resourceFile);

                string className = Path.GetFileNameWithoutExtension(pathName);

                string finalContent = templateContent.Replace("#SCRIPTNAME#", className);

                File.WriteAllText(pathName, finalContent);
                AssetDatabase.Refresh();

                Object newScript = AssetDatabase.LoadAssetAtPath<Object>(pathName);
                ProjectWindowUtil.ShowCreatedAsset(newScript);
            }
        }
    }
}
