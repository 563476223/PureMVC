using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class AutoSetImportAsset : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        TextureImporter importer = (TextureImporter)assetImporter;
        importer.mipmapEnabled = false;
        importer.isReadable = false;
        if (importer.assetPath.Contains("Assets/Art/Atlas"))
        {
            importer.textureType = TextureImporterType.Sprite;
            if (importer.assetPath.Contains("Common"))//--公共模块不打图集
            {
                return;
            }
            string dir = importer.assetPath;
            string folderName = string.Empty;
            do
            {
                dir = Path.GetDirectoryName(dir);
                folderName = Path.GetFileName(dir) + folderName;
            } while (!Path.GetDirectoryName(dir).EndsWith("Atlas"));
            importer.spritePackingTag = folderName;
        }
    }
}
