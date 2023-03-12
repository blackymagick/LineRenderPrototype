using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gemManager : MonoBehaviour
{
    public static gemManager Instance;
    public TextMeshProUGUI gemText;
    public List<GameObject> gemList = new List<GameObject>();
    public int Gems;
    public int MaxGems;
    private screenShake screenShake;
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
        screenShake = GameObject.FindObjectOfType<screenShake>();
    }

    // Update is called once per frame
    void Update()
    {
        //gemText.text = Gems.ToString() + "/" + MaxGems.ToString();

        if(Gems >= MaxGems)
        {
            GameManager.Instance.GoalAction?.Invoke();
        }
    }

    public void addGem()
    {
        Gems++;
        screenShake.shakeCamera();
    }

    public void resetGems()
    {
        Gems = 0;
        foreach ( var gemItems in gemList)
        {
            gemItems.SetActive(true);
        }
    }


}
