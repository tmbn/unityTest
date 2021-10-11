using System.Collections;
using System.IO;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public string nameOfAssetBundle ;
    public string nameOfObjectToLoad ;
    //Just a flag to prevent the "modulesmaterials" bundle to load twice
    private static bool once = true;
    void Start()
    {
        StartCoroutine(LoadAsset(nameOfAssetBundle, nameOfObjectToLoad));
    }
    
    
    IEnumerator LoadAsset(string assetBundleName, string objectNameToLoad)
    {
        string basepath = Path.Combine(Application.streamingAssetsPath, "AssetBundles");
        string prefabPath = Path.Combine(basepath, assetBundleName);
        //This section loads modulesmaterials just once to prevent it from loading twice.
        if (once)
        {            
            once = false;
            string materialPath = Path.Combine(basepath, "modulesmaterials");
            //modulesmaterials is loaded before our prefab so it can find the material reference
            var materialsPath = AssetBundle.LoadFromFile(materialPath);
        }
        var moduleAB = AssetBundle.LoadFromFile(prefabPath);
        if (moduleAB == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            yield break;
        }
        var prefab = moduleAB.LoadAsset<GameObject>(objectNameToLoad);
        Instantiate(prefab);
        
        

    }
}



