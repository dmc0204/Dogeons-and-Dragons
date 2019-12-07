using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DogInfoPanelController : MonoBehaviour {

    private DogStatsConfig displayDog;
    public Slider[] sliders;

    private Image portrait;

    public TextMeshProUGUI specialTextMeshPro;

    public string generateSpecialDescription (DogStatsConfig dogToShow) {
        StringBuilder sb = new StringBuilder ("", 100);
        foreach (special effect in dogToShow.specialEffects) {
            types typeToCheck = effect.type;
            switch (typeToCheck) {
                case types.changeHealth:
                    if (effect.value > 0) {
                        sb.Append ("Heals ");
                    } else if (effect.value < 0) {
                        sb.Append ("Damages ");
                    }
                    break;
                case types.changeAttack:
                    if (effect.value > 0) {
                        sb.Append ("Raises ");
                    } else if (effect.value < 0) {
                        sb.Append ("Lowers");
                    }
                    sb.Append ("attack of");
                    break;
                case types.changeDefense:
                    if (effect.value > 0) {
                        sb.Append ("Raises ");
                    } else if (effect.value < 0) {
                        sb.Append ("Lowers");
                    }
                    sb.Append ("defense of");
                    break;
                case types.changeSpeed:
                    if (effect.value > 0) {
                        sb.Append ("Raises ");
                    } else if (effect.value < 0) {
                        sb.Append ("Lowers");
                    }
                    sb.Append ("speed of");
                    break;
            }
            if (effect.targets == target.self) {
                sb.Append ("self ");
            }
            if (effect.targets == target.enemy) {
                sb.Append ("enemy ");
            }
            if (effect.value < 6) {
                sb.Append ("a little bit.\n");
            } else if (effect.value < 14) {
                sb.Append ("a moderate amount.\n");
            } else if (effect.value <= 20) {

            }
        }
        return sb.ToString ();
    }

    private string dogName, specialDescription;
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}