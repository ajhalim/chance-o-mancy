using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class diceSelection : MonoBehaviour
{
    public Button D4;
    public Button D6;
    public Button D8;
    public Button D12;
    public Button D20;

    public Image img4;
    public Image img6;
    public Image img8;
    public Image img12;
    public Image img20;


    public int d4Num = 0;
    public int d6Num = 1;
    public int d8Num = 2;
    public int d12Num = 3;
    public int d20Num = 4;

    /*
    private void Awake()
    {
        d4Val = PlayerPrefs.GetString("d4Num");
        d6Val = PlayerPrefs.GetString("d6Num");
        d8Val = PlayerPrefs.GetString("d8Num");
        d12Val = PlayerPrefs.GetString("d12Num");
        d20Val = PlayerPrefs.GetString("d20Num");

        print(d4Val);
        print(d6Val);
        print(d8Val);
        print(d12Val);
        print(d20Val);
    }
    */
    private void Update()
    {
        switch (d4Num)
        {
            case 0:
                PlayerPrefs.SetString("d4Num", "fire");
                img4.color = new Color(255 / 255f, 80 / 255f, 1 / 255f, 255 / 255f);
                break;
            case 1:
                PlayerPrefs.SetString("d4Num", "earth");
                img4.color = new Color(93 / 255f, 69 / 255f, 56 / 255f, 255 / 255f);
                break;
            case 2:
                PlayerPrefs.SetString("d4Num", "wind");
                img4.color = new Color(148 / 255f, 217 / 255f, 223 / 255f, 255 / 255f);
                break;
            case 3:
                PlayerPrefs.SetString("d4Num", "universe");
                img4.color = new Color(90 / 255f, 0 / 255f, 148 / 255f, 255 / 255f);
                break;
            case 4:
                PlayerPrefs.SetString("d4Num", "water");
                img4.color = new Color(78 / 255f, 101 / 255f, 196 / 255f, 255 / 255f);
                break;
        }

        switch (d6Num)
        {
            case 0:
                PlayerPrefs.SetString("d6Num", "fire");
                img6.color = new Color(255 / 255f, 80 / 255f, 1 / 255f, 255 / 255f);
                break;
            case 1:
                PlayerPrefs.SetString("d6Num", "earth");
                img6.color = new Color(93 / 255f, 69 / 255f, 56 / 255f, 255 / 255f);
                break;
            case 2:
                PlayerPrefs.SetString("d6Num", "wind");
                img6.color = new Color(148 / 255f, 217 / 255f, 223 / 255f, 255 / 255f);
                break;
            case 3:
                PlayerPrefs.SetString("d6Num", "universe");
                img6.color = new Color(90 / 255f, 0 / 255f, 148 / 255f, 255 / 255f);
                break;
            case 4:
                PlayerPrefs.SetString("d6Num", "water");
                img6.color = new Color(78 / 255f, 101 / 255f, 196 / 255f, 255 / 255f);
                break;
        }

        switch (d8Num)
        {
            case 0:
                PlayerPrefs.SetString("d8Num", "fire");
                img8.color = new Color(255 / 255f, 80 / 255f, 1 / 255f, 255 / 255f);
                break;
            case 1:
                PlayerPrefs.SetString("d8Num", "earth");
                img8.color = new Color(93 / 255f, 69 / 255f, 56 / 255f, 255 / 255f);
                break;
            case 2:
                PlayerPrefs.SetString("d8Num", "wind");
                img8.color = new Color(148 / 255f, 217 / 255f, 223 / 255f, 255 / 255f);
                break;
            case 3:
                PlayerPrefs.SetString("d8Num", "universe");
                img8.color = new Color(90 / 255f, 0 / 255f, 148 / 255f, 255 / 255f);
                break;
            case 4:
                PlayerPrefs.SetString("d8Num", "water");
                img8.color = new Color(78 / 255f, 101 / 255f, 196 / 255f, 255 / 255f);
                break;
        }

        switch (d12Num)
        {
            case 0:
                PlayerPrefs.SetString("d12Num", "fire");
                img12.color = new Color(255 / 255f, 80 / 255f, 1 / 255f, 255 / 255f);
                break;
            case 1:
                PlayerPrefs.SetString("d12Num", "earth");
                img12.color = new Color(93 / 255f, 69 / 255f, 56 / 255f, 255 / 255f);
                break;
            case 2:
                PlayerPrefs.SetString("d12Num", "wind");
                img12.color = new Color(148 / 255f, 217 / 255f, 223 / 255f, 255 / 255f);
                break;
            case 3:
                PlayerPrefs.SetString("d12Num", "universe");
                img12.color = new Color(90 / 255f, 0 / 255f, 148 / 255f, 255 / 255f);
                break;
            case 4:
                PlayerPrefs.SetString("d12Num", "water");
                img12.color = new Color(78 / 255f, 101 / 255f, 196 / 255f, 255 / 255f);
                break;
        }

        switch (d20Num)
        {
            case 0:
                PlayerPrefs.SetString("d20Num", "fire");
                img20.color = new Color(255 / 255f, 80 / 255f, 1 / 255f, 255 / 255f);
                break;
            case 1:
                PlayerPrefs.SetString("d20Num", "earth");
                img20.color = new Color(93 / 255f, 69 / 255f, 56 / 255f, 255 / 255f);
                break;
            case 2:
                PlayerPrefs.SetString("d20Num", "wind");
                img20.color = new Color(148 / 255f, 217 / 255f, 223 / 255f, 255 / 255f);
                break;
            case 3:
                PlayerPrefs.SetString("d20Num", "universe");
                img20.color = new Color(90 / 255f, 0 / 255f, 148 / 255f, 255 / 255f);
                break;
            case 4:
                PlayerPrefs.SetString("d20Num", "water");
                img20.color = new Color(78 / 255f, 101 / 255f, 196 / 255f, 255 / 255f);
                break;
        }
        /*PlayerPrefs.SetInt("d4Num", d4Num);
        PlayerPrefs.SetInt("d6Num", d6Num);
        PlayerPrefs.SetInt("d8Num", d8Num);
        PlayerPrefs.SetInt("d12Num", d12Num);
        PlayerPrefs.SetInt("d20Num", d20Num);*/
    }

   
    public void changeD4()
    {
        if(d4Num >= 4)
        {
            d4Num = 0;
        }
        else
        {
            d4Num++;
        }
        //print(d4Num);
    }

    public void changeD6()
    {
        if (d6Num >= 4)
        {
            d6Num = 0;
        }
        else
        {
            d6Num++;
        }
        
        //print(d4Num);
    }

    public void changeD8()
    {
        if (d8Num >= 4)
        {
            d8Num = 0;
        }
        else
        {
            d8Num++;
        }
        
        //print(d4Num);
    }

    public void changeD12()
    {
        if (d12Num >= 4)
        {
            d12Num = 0;
        }
        else
        {
            d12Num++;
        }
        //print(d4Num);
    }

    public void changeD20()
    {
        if (d20Num >= 4)
        {
            d20Num = 0;
        }
        else
        {
            d20Num++;
        }
        //print(d4Num);
    }
}
