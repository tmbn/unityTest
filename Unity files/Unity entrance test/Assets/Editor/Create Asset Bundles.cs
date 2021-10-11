using UnityEngine;
using UnityEditor;
using System.IO;
 
public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        
        string folderName = "AssetBundles";
        string filePath = Path.Combine(Application.streamingAssetsPath, folderName);

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        BuildPipeline.BuildAssetBundles(filePath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
        
        AssetDatabase.Refresh();

    }
    

    
}
