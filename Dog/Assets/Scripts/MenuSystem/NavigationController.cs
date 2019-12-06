using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public GameObject[] panels;
    public Stack<GameObject> previous;

    public void activatePanel(int which)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == which)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
        }
    }

    public void initPrev()
    {
        previous = new Stack<GameObject>();
        pushing(0);
    }

    public void pushing(int i)
    {
        previous.Push(panels[i]);
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
