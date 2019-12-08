using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DogInfoPanelController : MonoBehaviour
{

    private DogStatsConfig displayDog;
    public ArrayOfDogs doggies;
    public PlayerConfig myPlayer;

    public Slider[] sliders;

    public Image portrait;

    public TextMeshProUGUI specialTextMeshPro, dogName, dupeMessage;
    public GameObject thisPanel, addGameObject, removeGameObject, dupeGameObject;
    public Button addButton, removeButton, exitButton;

    //[SerializeField] private IntEvent refunding;
    [SerializeField] public DogStatsEvent displaying, dupesplaying;
    [SerializeField] private VoidEvent teamUpdating;


    public void summonedDog(DogStatsConfig newDog)
    {
        if (myPlayer.hasDog(newDog))
        {
            duplicateDog(newDog);
        }
        else
        {
            addDog(newDog);
            myPlayer.yourDogs.Add(newDog);
        }
    }

    public void addDog(DogStatsConfig newDog)
    {
        //DogStatsConfig newDog = dogsInTheGame.dogsInTheGame[i];
        if (myPlayer.isOnTeam(newDog))
        {
            Debug.Log("is on team");
            onTeamPanel(newDog);
        }
        else
        {
            addPanel(newDog);
        }
    }

    public void duplicateDog(DogStatsConfig dupeDog)
    {
        dupePanel(dupeDog);
    }

    public void addDogFromDoghouse(int i)
    {
        DogStatsConfig myCoolDog = doggies.dogsInTheGame[i];
        addDog(myCoolDog);
    }

    public void removeDogFromFrame(int i)
    {
        DogStatsConfig myCoolDog = myPlayer.yourTeam[i];
        addDog(myCoolDog);
    }
    public string generateSpecialDescription(DogStatsConfig dogToShow)
    {
        StringBuilder sb = new StringBuilder("", 100);
        foreach (special effect in dogToShow.specialEffects)
        {
            types typeToCheck = effect.type;
            switch (typeToCheck)
            {
                case types.changeHealth:
                    if (effect.value > 0)
                    {
                        sb.Append("Heals ");
                    }
                    else if (effect.value < 0)
                    {
                        sb.Append("Damages ");
                    }
                    break;
                case types.changeAttack:
                    if (effect.value > 0)
                    {
                        sb.Append("Raises ");
                    }
                    else if (effect.value < 0)
                    {
                        sb.Append("Lowers");
                    }
                    sb.Append("attack of ");
                    break;
                case types.changeDefense:
                    if (effect.value > 0)
                    {
                        sb.Append("Raises ");
                    }
                    else if (effect.value < 0)
                    {
                        sb.Append("Lowers");
                    }
                    sb.Append("defense of ");
                    break;
                case types.changeSpeed:
                    if (effect.value > 0)
                    {
                        sb.Append("Raises ");
                    }
                    else if (effect.value < 0)
                    {
                        sb.Append("Lowers");
                    }
                    sb.Append("speed of ");
                    break;
            }
            float absValueEffect = Math.Abs(effect.value);
            if (effect.targets == target.self)
            {
                sb.Append("self ");
            }
            if (effect.targets == target.enemy)
            {
                sb.Append("enemy ");
            }
            if (absValueEffect < 6)
            {
                sb.Append("a little bit\n");
            }
            else if (absValueEffect < 14)
            {
                sb.Append("moderately\n");
            }
            else if (absValueEffect <= 20)
            {
                sb.Append("massively\n");
            }
        }
        return sb.ToString();
    }

    public void stringGen(DogStatsConfig dogToShow)
    {
        specialTextMeshPro.text = generateSpecialDescription(dogToShow);
    }

    public void setName(DogStatsConfig dogToShow)
    {
        dogName.text = dogToShow.dogName;
    }

    public void setStatBars(DogStatsConfig dogToShow)
    {
        float[] myNewArray = { dogToShow.MaxHealth, dogToShow.BaseAttack, dogToShow.BaseDefense, dogToShow.BaseSpeed };
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = myNewArray[i] / 50;
        }
    }

    public void setPortrait(DogStatsConfig dogToShow)
    {
        portrait.sprite = dogToShow.head;
    }

    public void showPanel(DogStatsConfig dogToShow)
    {
        if (myPlayer.hasDog(dogToShow))
        {
            displayDog = dogToShow;
            stringGen(dogToShow);
            setName(dogToShow);
            setStatBars(dogToShow);
            setPortrait(dogToShow);
            thisPanel.SetActive(true);
        }
    }

    public void onTeamPanel(DogStatsConfig dogToShow)
    {
        removeGameObject.SetActive(true);
        addGameObject.SetActive(false);
        dupeGameObject.SetActive(false);
        showPanel(dogToShow);
    }

    public void addPanel(DogStatsConfig dogToShow)
    {
        removeGameObject.SetActive(false);
        dupeGameObject.SetActive(false);
        int numDogsInTeam = 0;
        for (int i = 0; i < myPlayer.yourTeam.Length; i++)
        {
            if (myPlayer.yourTeam[i] != null)
            {
                numDogsInTeam++;
            }
        }
        if (numDogsInTeam < 3)
        {
            addGameObject.SetActive(true);
        }
        else
        {
            addGameObject.SetActive(false);

        }
        showPanel(dogToShow);
    }

    public void dupePanel(DogStatsConfig dogToShow)
    {
        setDupeMessage(dogToShow);
        removeGameObject.SetActive(false);
        addGameObject.SetActive(false);
        dupeGameObject.SetActive(true);
        showPanel(dogToShow);
    }

    public void setDupeMessage(DogStatsConfig dogToShow)
    {
        int refund;
        Rarity dogRarity = dogToShow.dogRarity;
        switch (dogRarity)
        {
            case Rarity.rare:
                refund = 10;
                break;
            case Rarity.superRare:
                refund = 25;
                break;
            case Rarity.superDuperRare:
                refund = 50;
                break;
            case Rarity ultraRare:
                refund = 75;
                break;
        }
        myPlayer.changeBones(refund);
        dupeMessage.text = "Duplicate Dog Summoned (+ " + refund.ToString() + " bones)";
    }

    public void toTeam()
    {
        myPlayer.addToTeam(displayDog);
        teamUpdating.Raise();
    }

    public void toHouse()
    {
        myPlayer.removeFromTeam(displayDog);
        teamUpdating.Raise();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}