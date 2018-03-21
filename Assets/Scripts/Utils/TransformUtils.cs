using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TransformUtils
{
    /// <summary>
    /// 屏幕适配
    /// </summary>
    public enum ResolutionPolicy
    {
        LeftTop = 1,
        MiddleTop,
        RightTop,
        LeftMiddle,
        Middle,
        RightMiddle,
        LeftBottom,
        MiddleBottom,
        RightBottom
    }

    public static void ResizeRectTransform(int type,RectTransform rect,bool isFullScreen)
    {
        ResizeRectTransform((ResolutionPolicy)type, rect, isFullScreen);
    }

    /// <summary>
    /// 重置RectTransform大小，该方法Anchor在其中心
    /// </summary>
    /// <param name="type"></param>
    /// <param name="rect"></param>
    /// <param name="isFullScreen"></param>
    [NoToLua]
    public static void ResizeRectTransform(ResolutionPolicy type,RectTransform rect,bool isFullScreen = false)
    {
        float scaleX = Screen.width / Config.UI_DESIGN_WIDTH;
        float scaleY = Screen.height / Config.UI_DESIGN_HEIGHT;
        float scale = scaleX;
        if (scaleX > scaleY & isFullScreen == false || scaleX < scaleY && isFullScreen == true)
        {
            scale = scaleY;
        }

        rect.localScale = new Vector3(scale, scale, scale);
        if (type == ResolutionPolicy.LeftBottom)
        {
            rect.localPosition = new Vector3(-(Screen.width * 0.5f - rect.sizeDelta.x * scale * 0.5f), -(Screen.height * 0.5f - rect.sizeDelta.y * scale * 0.5f));
        }
        else if (type == ResolutionPolicy.LeftMiddle)
        {
            rect.localPosition = new Vector3(-(Screen.width * 0.5f - rect.sizeDelta.x * scale * rect.pivot.x), 0);
        }
        else if (type == ResolutionPolicy.LeftTop)
        {
            rect.localPosition = new Vector3(-(Screen.width * 0.5f - rect.sizeDelta.x * scale * 0.5f), Screen.height * 0.5f - rect.sizeDelta.y * scale * 0.5f);
        }
        else if (type == ResolutionPolicy.Middle)
        {
            rect.localPosition = new Vector3(0, 0);
        }
        else if (type == ResolutionPolicy.MiddleBottom)
        {
            rect.localPosition = new Vector3(0, -(Screen.height * 0.5f - rect.sizeDelta.y * scale * 0.5f));
        }
        else if (type == ResolutionPolicy.MiddleTop)
        {
            rect.localPosition = new Vector3(0, Screen.height * 0.5f - rect.sizeDelta.y * scale * 0.5f);
        }
        else if (type == ResolutionPolicy.RightBottom)
        {
            rect.localPosition = new Vector3(Screen.width * 0.5f - rect.sizeDelta.x * scale * 0.5f, -(Screen.height * 0.5f - rect.sizeDelta.y * scale * 0.5f));
        }
        else if (type == ResolutionPolicy.RightMiddle)
        {
            rect.localPosition = new Vector3(Screen.width * 0.5f - rect.sizeDelta.x * scale * 0.5f, 0);
        }
        else if (type == ResolutionPolicy.RightTop)
        {
            rect.localPosition = new Vector3(Screen.width * 0.5f - rect.sizeDelta.x * scale * 0.5f, Screen.height * 0.5f - rect.sizeDelta.y * scale * 0.5f);
        }
    }

    public static Transform FindChild(Transform parent, string childName)
    {
        if (parent == null || childName.Length == 0)
        {
            return null;
        }
        Transform transform = SearchChildRecursion(parent, childName);

        return transform;
    }

    private static Transform SearchChildRecursion(Transform parent, string childName)
    {
        if (parent == null)
        {
            return null;
        }

        if (parent.name == childName)
        {
            return parent;
        }

        Transform child = parent.Find(childName);

        if (child != null)
        {
            return child;
        }
        else
        {
            for (int i = 0; i < parent.childCount; ++i)
            {
                child = parent.GetChild(i);
                child = FindChild(child, childName);
                if (child != null)
                {
                    return child;
                }
            }
        }
        return null;
    }

    public static void RemoveAllChildren(Transform parent, bool immediate)
    {
        if (parent == null)
        {
            return;
        }
        while (parent.childCount != 0)
        {
            if (immediate)
            {
                GameObject.DestroyImmediate(parent.GetChild(0).gameObject);
            }
            else
            {
                GameObject.Destroy(parent.GetChild(0).gameObject);
            }
        }
    }

    /// <summary>
    /// 获取组件，没有给具体路径，保证唯一性，或者直接给具体路径进行获取对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    [NoToLua]
    public static T GetComponent<T>(Transform parent, string path)where T:Component
    {
        if (parent == null || path.Length == 0)
        {
            return default(T);
        }
        Transform transform = null;
        if (path.Contains("/"))
        {
            transform = parent.Find(path);
        }
        else
        {
            transform = SearchChildRecursion(parent, path);
        }
        if (transform != null)
        {
            return transform.gameObject.GetComponent<T>();
        }
        return default(T);
    }

    public static Component GetComponent(Transform parent, string component, string path)
    {
        if (parent == null || path.Length == 0)
        {
            return null;
        }

        Transform transform = null;
        if (path.Contains("/"))
        {
            transform = parent.Find(path);
        }
        else
        {
            transform = SearchChildRecursion(parent, path);
        }

        if (transform != null)
        {
            return transform.gameObject.GetComponent(component);
        }

        return null;
    }

    ///图集的释放，除公共模块不释放
    ///图集卸载时，如果其他UI在引用将也会释放
    public static void UnloadUIAtlas(Transform root)
    {
        Image[] imgArray = root.GetComponentsInChildren<Image>(true);
        if (imgArray == null)
        {
            return;
        }
        List<Texture2D> atlas = new List<Texture2D>();
        int count = imgArray.Length;

        for (int i = 0; i < count; ++i)
        {
            Sprite sprite = imgArray[i].sprite;
            if (sprite == null || sprite.texture == null || !sprite.texture.name.StartsWith("SpriteAtlasTexture-"))
            {
                continue;
            }

            if (sprite.texture.name.Replace("SpriteAtlasTexture-", "").StartsWith("Common") || sprite.texture.name.Replace("SpriteAtlasTexture-", "").StartsWith("CommonNew"))
            {
                continue;
            }

            if (!atlas.Contains(sprite.texture))
            {
                atlas.Add(sprite.texture);
            }
        }

        for (int i = 0; i < atlas.Count; ++i)
        {
            Texture2D texture = atlas[i];
            Resources.UnloadAsset(texture);
        }
    }
   
}
