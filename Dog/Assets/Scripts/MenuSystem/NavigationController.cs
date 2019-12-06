using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    public GameObject[] panels;
    public Stack previous;

    public void activatePanel(GameObject which)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i] == which)
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
        previous = new Stack();
        pushing(0);
    }

    public void pushing(int i)
    {
        previous.Push(panels[i]);
    }

    public void navPrev()
    {
        if (previous.Count > 0)
        {
            activatePanel(previous.Pop());
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
