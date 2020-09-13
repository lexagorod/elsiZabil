using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

public class APIController : MonoBehaviour
{
    public static APIController API;
    public RawImage rawImage;

    private readonly string baseURL = "https://picsum.photos/200";
    private void Awake()
    {
        API = this;
    }
    private void Start()
    {
        rawImage.texture = Texture2D.blackTexture;
    }

    public void OnButtonImage()
    {
        rawImage.texture = Texture2D.blackTexture;

        StartCoroutine(GetImage(baseURL));
    }

    IEnumerator GetImage(string s)
    {
        string getURL = s;

        UnityWebRequest uRequest = UnityWebRequestTexture.GetTexture(getURL);

        yield return uRequest.SendWebRequest();

        if (uRequest.isNetworkError || uRequest.isHttpError)
        {
            Debug.LogError(uRequest.error);
            yield break;
        }

        rawImage.texture = DownloadHandlerTexture.GetContent(uRequest);
        rawImage.texture.filterMode = FilterMode.Bilinear;
    }


}
