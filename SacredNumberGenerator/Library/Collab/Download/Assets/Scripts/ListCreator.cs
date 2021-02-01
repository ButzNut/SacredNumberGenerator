using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ListCreator : MonoBehaviour
{
    public SacredNumberGenerator sacred;
    public FavouriteList faves;

    public static ListCreator creator;

    [SerializeField]
    private Transform SpawnPoint = null;

    [SerializeField]
    private GameObject NewNumber = null;

    [SerializeField]
    private GameObject FavNumber = null;

    [SerializeField]
    private RectTransform content = null;

    public float distance;
    public float contentDistance;

    public float spawnY1;
    public float spawnY2;
    public float spawnY3;


    public int[] SacredNumbers;
    public int[] favSave;

    private void Awake()
    {
        creator = this;
    }

    public void NewNumberAdd()
    {

        StartCoroutine(list());
    }

    public void reloadList()
    {
        StartCoroutine(LoadList());
    }

    public void deleteNumbers()
    {
        SacredNumbers = SacredNumberGenerator.instance.saveNumbers;
        foreach (Transform child in SpawnPoint)
        {
                GameObject.Destroy(child.gameObject);
        }
        content.sizeDelta = new Vector2(0, faves.savFav.LongLength * (distance + contentDistance));
    }


    IEnumerator list()
    {

        yield return new WaitForSeconds(0.1f);

        content.sizeDelta = new Vector2(0, ((SacredNumberGenerator.instance.saveNumbers.LongLength + faves.savFav.LongLength) * distance) + contentDistance);

        spawnY1 = ((SacredNumberGenerator.instance.saveNumbers.LongLength - 1) + faves.savFav.LongLength) * distance;

        Vector3 pos = new Vector3(0, -spawnY1, 0);

        GameObject SpawnItem = Instantiate(NewNumber, pos, SpawnPoint.rotation);

        SpawnItem.transform.SetParent(SpawnPoint, false);

        NumberDisplay numberDisplay = SpawnItem.GetComponent<NumberDisplay>();

        SacredNumbers = SacredNumberGenerator.instance.saveNumbers;

        numberDisplay.number.text = SacredNumbers[SacredNumberGenerator.instance.saveNumbers.LongLength - 1].ToString("D6");
        numberDisplay.numberS = SacredNumbers[SacredNumberGenerator.instance.saveNumbers.LongLength - 1];

    }

    IEnumerator LoadList()
    {
        for (int i = 0; i < faves.savFav.LongLength; i++)
        {
            spawnY2 = i * distance;

            Vector3 pos = new Vector3(0, -spawnY2, 0);

            GameObject FavItem = Instantiate(FavNumber, pos, SpawnPoint.rotation);


            FavItem.transform.SetParent(SpawnPoint, false);


            NumberDisplay numberDisplay = FavItem.GetComponent<NumberDisplay>();

            SacredNumbers = SacredNumberGenerator.instance.saveNumbers;
            favSave = faves.savFav;

            numberDisplay.number.text = favSave[i].ToString("D6");
            numberDisplay.numberS = favSave[i];
        }
        content.sizeDelta = new Vector2(0, (faves.savFav.LongLength * distance) + contentDistance);

        yield return new WaitForSeconds(0.0f);

        for (int i = 0; i < SacredNumberGenerator.instance.saveNumbers.LongLength; i++)
        {
            spawnY1 = (faves.savFav.LongLength + i) * distance;

            Vector3 pos = new Vector3(0, -spawnY1, 0);

            GameObject SpawnItem = Instantiate(NewNumber, pos, SpawnPoint.rotation);


            SpawnItem.transform.SetParent(SpawnPoint, false);

            NumberDisplay numberDisplay = SpawnItem.GetComponent<NumberDisplay>();

            SacredNumbers = SacredNumberGenerator.instance.saveNumbers;

            numberDisplay.number.text = SacredNumbers[i].ToString("D6");
            numberDisplay.numberS = SacredNumbers[i];
        }
        content.sizeDelta = new Vector2(0, ((SacredNumberGenerator.instance.saveNumbers.LongLength + faves.savFav.LongLength) * distance) + contentDistance);

    }
}
