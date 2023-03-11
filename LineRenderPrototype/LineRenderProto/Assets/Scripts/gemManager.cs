using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gemManager : MonoBehaviour
{
    public static gemManager Instance;
    public TextMeshProUGUI gemText;
    public List<GameObject> gemList = new List<GameObject>();
    public GameObject EndGoal;
    public int Gems;
    public int MaxGems;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        gemList.AddRange(GameObject.FindGameObjectsWithTag("Collectible"));
        MaxGems = gemList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        //gemText.text = Gems.ToString() + "/" + MaxGems.ToString();

        if(Gems >= MaxGems)
        {
            GemsCollected();
            EndGoal.SetActive(true);
        }
    }

    public void addGem()
    {
        Gems++;
    }

    public void resetGems()
    {
        Gems = 0;
        foreach ( var gemItems in gemList)
        {
            gemItems.SetActive(true);
        }
    }

    void GemsCollected()
    {
        
    }

}
