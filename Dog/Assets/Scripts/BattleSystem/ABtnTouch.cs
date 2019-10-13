using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ABtnTouch : MonoBehaviour
{
    public Button ABtn;
    public Animator anim;
    void Start()
    {
        Button btn = ABtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        anim.SetTrigger("PlayerAttack");
    }

}

