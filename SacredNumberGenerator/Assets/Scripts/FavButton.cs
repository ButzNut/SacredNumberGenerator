using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FavButton : MonoBehaviour
{
    public NumberDisplay number;
    public ListCreator list;

    public int numberss;

    private void Start()
    {
        numberss = number.numberS;
    }

    private void Update()
    {
        if (!FavouriteList.favInstance.favourites.Contains(number.numberS))
        {
            this.GetComponent<Image>().color = Color.red;
        }
        else if (FavouriteList.favInstance.favourites.Contains(number.numberS))
        {
            this.GetComponent<Image>().color = Color.green;
        }
    }

    public void Fav()
    {
        if (!FavouriteList.favInstance.favourites.Contains(number.numberS))
        {
            FavouriteList.favInstance.favourites.Add(number.numberS);
            SacredNumberGenerator.instance.Lists.Remove(number.numberS);
            list.reloadList();
            list.deleteNumbers();
        }
        else if (FavouriteList.favInstance.favourites.Contains(number.numberS))
        {
            FavouriteList.favInstance.favourites.Remove(number.numberS);
            SacredNumberGenerator.instance.Lists.Add(number.numberS);
            list.reloadList();
            list.deleteNumbers();
        }
    }

}
