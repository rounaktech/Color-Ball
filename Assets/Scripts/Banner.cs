using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Banner : MonoBehaviour
{

    public string gameId = "4122501";
    public string surfacingId = "banner";
    public bool testMode = false;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(surfacingId);
    }
}