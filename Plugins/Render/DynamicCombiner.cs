using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DynamicCombiner
{
    public static void Combine(List<GameObject> gameObjects)
    {
        if (gameObjects == null)
            return;
        List<Texture2D> textureList = new List<Texture2D>(gameObjects.Count);
        Shader sharedShader = null;
        Material newMat = null;
        Texture2D newTex = null;
        List<MeshRenderer> renderList = new List<MeshRenderer>(gameObjects.Count);
        List<Mesh> meshList = new List<Mesh>();
        Dictionary<int, int> meshUVIndex = new Dictionary<int, int>();

        for (int i = 0; i < gameObjects.Count; i++)
        {
            var render = gameObjects[i].GetComponent<MeshRenderer>();
            var mat = render.sharedMaterial;
            var shader = mat.shader;
            var meshFilter = gameObjects[i].GetComponent<MeshFilter>();
            var tex = mat.mainTexture as Texture2D;
            //超过256的不合并图集
            if (tex.width > 256 || tex.height > 256)
            {
                continue;
            }
            if (sharedShader == null)
            {
                sharedShader = shader;
                newMat = new Material(shader);
#if UNITY_ANDROID
                newTex = new Texture2D(512, 512, TextureFormat.ETC_RGB4, true);
#elif UNITY_IPHONE
                newTex = new Texture2D(512, 512, TextureFormat.PVRTC_RGBA4, true);
#elif UNITY_EDITOR
 				newTex = new Texture2D(512, 512, TextureFormat.DXT1, true);
#endif
            }
            else if (sharedShader != shader)
            {
                Debug.LogError("material error " + gameObjects[i].name, gameObjects[i]);
                continue;
            }
            renderList.Add(render);
            meshList.Add(meshFilter.mesh);
            if (!textureList.Contains(tex))
            {
                textureList.Add(tex);
                meshUVIndex[meshList.Count - 1] = textureList.Count - 1;

            }
            else
            {
                for (int k = 0; k < textureList.Count; k++)
                {
                    if (textureList[k] == tex)
                    {
                        meshUVIndex[meshList.Count - 1] = k;
                        break;
                    }
                }
            }
        }
        Rect[] texUV = newTex.PackTextures(textureList.ToArray(), 0);
        newMat.mainTexture = newTex;
        for (int i = 0; i < meshList.Count; i++)
        {
            var index = meshUVIndex[i];
            var offset = new Vector2(texUV[index].x, texUV[index].y);
            var scale = new Vector2(texUV[index].width, texUV[index].height);
            var uv = meshList[i].uv;
            List<Vector2> uvNew = new List<Vector2>(uv.Length);
            for (int k = 0; k < uv.Length; k++)
            {
                var newUV = new Vector2(meshList[i].uv[k].x * scale.x, meshList[i].uv[k].y * scale.y) + offset;
                uvNew.Add(newUV);
            }
            meshList[i].uv = uvNew.ToArray();
        }
        for (int i = 0; i < renderList.Count; i++)
        {
            renderList[i].material = newMat;
        }
    }
}
