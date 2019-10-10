using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//small component to display a visual representation of health/mana/whatever bars

public class ImageFillSetter : MonoBehaviour
{
    public FloatReference Variable;
    public FloatReference Max;

    public Image Image;

    private void Update() {
        Image.fillAmount = Mathf.Clamp01(Variable.Value / Max.Value);
    }


}
