using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryInfoPanelController : MonoBehaviour
{
    public PlayerConfig myCoolPlayer;

    public ChewableConfig activeChewable;

    public GameObject panel, addButton, buyButton;

    public Image chewableImage;
    public Image[] strengthMeter;

    public int activeChewableCost, inventoryAmount;
    public TextMeshProUGUI inventoryAmountText, activeChewableType, activeChewableCostText;

    public void activatePanel(ChewableConfig newChew)
    {
        activeChewable = newChew;
        loadInfo(false);
        panel.SetActive(true);
    }

    public void activatePanel(int i)
    {
        activeChewable = myCoolPlayer.yourPack[i];
        loadInfo(true);
        panel.SetActive(true);
    }

    public void loadInfo(bool inBag)
    {
        chewableImage.sprite = activeChewable.chewySprite;
        activeChewableType.text = activeChewable.chewableType;
        activeChewableCost = activeChewable.chewableCost;
        activeChewableCostText.text = activeChewable.chewableCost.ToString();
        for (int i = 0; i < strengthMeter.Length; i++)
        {
            if (i <= activeChewable.chewableStrength)
            {
                strengthMeter[i].color = new Color(1, 1, 1, 1);
            }
            else
            {
                strengthMeter[i].color = new Color(0, 0, 0, 0);
            }
        }
        updateInventory();
        checkBag();
        checkInventory();
        checkMoney();
    }

    public void updateInventory()
    {
        inventoryAmount = myCoolPlayer.amount(activeChewable);
        inventoryAmountText.text = inventoryAmount.ToString();
    }

    //button shit
    public void addToBag()
    {
        myCoolPlayer.addToBag(activeChewable);
        checkBag();
        checkInventory();
        updateInventory();
    }

    //checks if bag is full
    public void checkBag()
    {
        int numChewsInBag = 0;
        for (int i = 0; i < myCoolPlayer.yourPack.Length; i++)
        {
            if (myCoolPlayer.yourPack[i] != null)
            {
                numChewsInBag++;
            }
        }
        if (numChewsInBag < 5)
        {
            addButton.SetActive(true);
        }
        else
        {
            addButton.SetActive(false);
        }
    }

    //checks if you have it in your inventory ONLY USE AFTER CHECKBAG
    public void checkInventory()
    {
        if (inventoryAmount <= 0)
        {
            addButton.SetActive(false);
        }
    }

    //checks if you're poor
    public void checkMoney()
    {
        if (activeChewableCost < myCoolPlayer.currency)
        {
            buyButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
