using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryInfoPanelController : MonoBehaviour
{
    public PlayerConfig myCoolPlayer;

    public ChewableConfig activeChewable;

    public GameObject panel, addButton, buyButton, removeButton;

    public Image[] bagImage;

    public Image chewableImage;
    public Image[] strengthMeter;

    public int activeChewableCost, inventoryAmount;
    public TextMeshProUGUI inventoryAmountText, activeChewableType, activeChewableCostText;

    [SerializeField] private VoidEvent countUpdating;


    public void initBag()
    {
        for (int i = 0; i < bagImage.Length; i++)
        {
            if (myCoolPlayer.yourPack[i] != null)
            {
                bagImage[i].sprite = myCoolPlayer.yourPack[i].chewySprite;
                bagImage[i].color = new Color(1, 1, 1, 1);
            }
            else
            {
                bagImage[i].color = new Color(0, 0, 0, 0);
            }
        }
    }
    public void activatePanel(ChewableConfig newChew)
    {
        Debug.Log("panel activate called");
        activeChewable = newChew;
        Debug.Log("active chewable set to " + activeChewable);
        loadInfo();
        panel.SetActive(true);
    }

    public void activatePanel(int i)
    {
        activeChewable = myCoolPlayer.yourPack[i];
        if (activeChewable != null)
        {
            loadInfo();
            panel.SetActive(true);
        }

    }

    public void loadInfo()
    {
        chewableImage.sprite = activeChewable.chewySprite;
        Debug.Log("chewable sprite loaded success");
        activeChewableType.text = activeChewable.chewableType;
        Debug.Log("chewable type loaded success");
        activeChewableCost = activeChewable.chewableCost;
        Debug.Log("chewable cost loaded success");
        activeChewableCostText.text = activeChewable.chewableCost.ToString();
        Debug.Log("chewable cost string loaded success");
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
        Debug.Log("strength meter success");

        updateInventory();
        checkBag();
        checkInventory();
        checkMoney();
        Debug.Log("inbag check success");
    }

    public void updateInventory()
    {
        inventoryAmount = myCoolPlayer.amount(activeChewable);
        inventoryAmountText.text = inventoryAmount.ToString();
        countUpdating.Raise();
    }

    //button shit
    public void add()
    {
        myCoolPlayer.addToBag(activeChewable);
        checkBag();
        checkInventory();
        updateInventory();
        initBag();
        panel.SetActive(false);
    }

    public void buy()
    {
        myCoolPlayer.changeBones(-1 * activeChewableCost);
        myCoolPlayer.addItems(activeChewable, 1);
        loadInfo();
    }

    public void removeFromBag(int i)
    {
        if (myCoolPlayer.yourPack[i] != null)
        {
            myCoolPlayer.removeChewable(i);
            checkBag();
            checkInventory();
            updateInventory();
            initBag();
        }

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

    public void playerSet(PlayerConfig newPlayer)
    {
        myCoolPlayer = newPlayer;
    }



    // Start is called before the first frame update
    void Start()
    {
        myCoolPlayer.initDick();
        initBag();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
