using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpBtnTouch : MonoBehaviour
{
    public Button SpBtn;
    public Animator anim2;
    void Start()
    {
        Button btn = SpBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        anim2.SetTrigger("TransformPug");
    }
}
