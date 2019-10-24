using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

//IPointers here were used to test mouse
public class RightButton : MonoBehaviour, IPointerClickHandler
{
    //This is called RightButton because A and Sp buttons are on the right. 
    //This script works on both of them. 1 working for 2!

    
    //Clicking on the button!
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log(this.gameObject.name + "was clicked");
            //below is for testing if ABtn and SpBtn actually do get clicked

            
            if (this.gameObject.name == "ABtn")
            {
                Debug.Log("ABTN attacks");
                
            }else if (this.gameObject.name == "SpBtn")
            {
                Debug.Log("SPBTN SPECIALIZES");
               
            }
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
