using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DogHouse : MonoBehaviour
{
    //this will create level buttons/holders.
    //
    public GameObject LevelHolder;
    public GameObject LevelIcon;
    public GameObject thisCanvas;
    public int NumberOfLevels = 10;
    private Rect panelDimensions;
    private Rect iconDimensions;
    private int amountPerPage;
    private int currentLevelCount;
    public Vector2 iconSpacing;
    // Start is called before the first frame update
    void Start()
    {
        panelDimensions = LevelHolder.GetComponent<RectTransform>().rect;
        iconDimensions = LevelIcon.GetComponent<RectTransform>().rect;
        
        //tower select, so 1 column, many rows
        int MaxInRow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
        int MaxInCol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
        int AmountPerPage = MaxInRow * MaxInCol;
        int totalPages = Mathf.CeilToInt((float)NumberOfLevels / AmountPerPage);
        LoadPanels(totalPages);
    }

    void LoadPanels(int NumOfPanels)
    {
        GameObject PanelClone = Instantiate(LevelHolder) as GameObject;
        for(int i = 1; i<= NumOfPanels; i++)
        {
            GameObject panel = Instantiate(PanelClone) as GameObject;
            panel.transform.SetParent(LevelHolder.transform);
            panel.transform.SetParent(LevelHolder.transform);
            panel.name = "Floor-" + i;
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);
            SetUpGrid(panel);

            int numOfIcons = i == NumOfPanels ? NumberOfLevels - currentLevelCount : amountPerPage;

            LoadIcons(10,panel);
        }
        Destroy(PanelClone);
    }



    void SetUpGrid(GameObject panel)
    {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
        grid.childAlignment = TextAnchor.MiddleCenter;
        grid.spacing = iconSpacing;
    }


    void LoadIcons(int numOfIcons, GameObject parentObject)
    {
        for(int i = 1;i<= numOfIcons; i++)
        {
            GameObject icon = Instantiate(LevelIcon) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = "Floor " + i;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
