using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiceProfile
{
    public enum DiceType { D4 = 4, D6 = 6, D8 = 8, D12 = 12, D20 = 20 }
    public enum Element { None, Fire, Earth, Air, Universe, Water }

    public DiceType diceType;
    public Element element;

    public int MaxDamage { get { return (int)diceType; } }
    public Color32 GetColor()
    {
        switch (element)
        {
            case Element.None:
                return new Color32(255, 255, 255, 255);
            case Element.Fire:
                return new Color32(255, 80, 01, 255);
            case Element.Earth:
                return new Color32(93, 69, 56, 255);
            case Element.Air:
                return new Color32(148, 217, 223, 255);
            case Element.Universe:
                return new Color32(90, 0, 148, 255);
            case Element.Water:
                return new Color32(78, 101, 196, 255);
            default:
                return new Color32(255, 255, 255, 255);
        }
    }
}
