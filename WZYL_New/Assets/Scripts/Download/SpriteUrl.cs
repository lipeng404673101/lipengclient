using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public static class TexturePool
{
    public static Dictionary<string, Texture2D> m_Pool = new Dictionary<string, Texture2D>();
}

public class SpriteUrl : MonoBehaviour {
    
    public UITexture m_Texture;
    private string m_ImageUrl;
    public bool isMe = false;
    private bool isInit = false;
    public static readonly SpriteUrl ms_Instance = new SpriteUrl();
    public static SpriteUrl Instance
    {
        get
        {
            return ms_Instance;
        }
    }
    public string path
    {
        get
        {
            //pc,ios //android :jar:file//
#if UNITY_EDITOR
            return Application.persistentDataPath + "/ImageCache/";
#elif UNITY_ANDROID
            return Application.persistentDataPath + "/ImageCache/";
#elif UNITY_IOS
            return Application.persistentDataPath + "/ImageCache/";
#endif
        }
    }

    public void OnEnable()
    {
        //http://wx.qlogo.cn/mmopen/EVxJeWK7jLpxBAzboIO94qNehTn1TBhC4KjMFhBj7sQfNfJrpPTue6Ph869ccPU4cVUu6KvT17LRTR5OtRfDjicyqCGib7ricH1/0
        if(isMe && isInit)
            Init(m_ImageUrl);
    }

    public bool Init(string _url)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/ImageCache/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/ImageCache/");
        }
        StartLoad(_url);
        
        return true;
    }

    public void SetAsyncImage(string url)
    {
        m_ImageUrl = url;
        //开始下载图片前，将UITexture的主图片设置为占位图
        //if (m_Texture != null)
        //{
        //    m_Texture.mainTexture = image;
        //    return;
        //}
        isInit = true;
        Debug.Log("isMe：：" + isMe);
        if (!isMe)
            Init(m_ImageUrl);
        
    }

    public void StartLoad(string url)
    {
        //查询是否已经有缓存
        if(TexturePool.m_Pool.ContainsKey(url))
        {
            Debug.Log("已经有了缓存:"+ url);
           // m_Texture.mainTexture = TexturePool.m_Pool[url];
            return;
        }
        //判断是否是第一次加载这张图片
        if (!File.Exists(path + url.GetHashCode()))
        {
            //如果之前不存在缓存文件
            Debug.Log("不存在缓存文件,下载:" + url);
            StartCoroutine(DownloadImage(url));
        }
        else
        {
            Debug.Log("本地加载:" + url);
            StartCoroutine(LoadLocalImage(url));
        }
    }

    IEnumerator DownloadImage(string url)
    {
        Debug.Log("downloading new image:" + path + url.GetHashCode());//url转换HD5作为名字
        WWW www = new WWW(url);
        yield return www;

        Texture2D tex2d = www.texture;
        //将图片保存至缓存路径
        byte[] pngData = tex2d.EncodeToPNG();                         //将材质压缩成byte流
        File.WriteAllBytes(path + url.GetHashCode(), pngData);        //然后保存到本地

       // m_Texture.mainTexture = tex2d;

        if (!TexturePool.m_Pool.ContainsKey(url))
            TexturePool.m_Pool.Add(url, tex2d);

        //Sprite m_sprite = Sprite.Create(tex2d, new Rect(0, 0, tex2d.width, tex2d.height), new Vector2(0, 0));
        //image.sprite = m_sprite;
        //myWXPic = m_sprite;
    }

    IEnumerator LoadLocalImage(string url)
    {
#if UNITY_EDITOR
        string filePath = "file:///" + path + url.GetHashCode();
#elif UNITY_ANDROID
                string filePath = path + url.GetHashCode();
#elif UNITY_IOS
                string filePath = path + url.GetHashCode();
#endif
        Debug.Log("Path:" + path);
        Debug.Log("原始Url：" + url);
        Debug.Log("加载本地文件：" + filePath);
#if UNITY_EDITOR

        WWW www = new WWW(filePath);
        yield return www;
        Texture2D texture = www.texture;

       // m_Texture.mainTexture = texture;

        if (!TexturePool.m_Pool.ContainsKey(url))
            TexturePool.m_Pool.Add(url, texture);


#else

        if (TexturePool.m_Pool.ContainsKey(url))
        {
            yield return null;
            Texture2D texture = TexturePool.m_Pool[url];
          //  m_Texture.mainTexture = texture;
        }
        else
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            Texture2D tex = new Texture2D(72 , 72);
            tex.LoadImage(bytes);
            yield return null;
            //WWW www = new WWW(filePath);
            //yield return www;
            //Texture2D texture = www.texture;

         //   m_Texture.mainTexture = tex;

            if (!TexturePool.m_Pool.ContainsKey(url))
                TexturePool.m_Pool.Add(url, tex);
        }

#endif



        //Sprite m_sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
        //image.sprite = m_sprite;
        //myWXPic = m_sprite;
    }


}
