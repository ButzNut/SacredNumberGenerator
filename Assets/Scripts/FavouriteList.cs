using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FavouriteList : MonoBehaviour
{
    public List<int> favourites = new List<int>();

    public static FavouriteList favInstance;

    private void Awake()
    {
        favInstance = this;
    }

    public int[] savFav;

    private void Start()
    {
        savFav = PlayerPrefsX.GetIntArray("savefav");
        FavouriteList.favInstance.favourites.AddRange(savFav);
    }

    private void Update()
    {
        savFav = FavouriteList.favInstance.favourites.ToArray();
        PlayerPrefsX.SetIntArray("savefav", savFav);
    }

}
