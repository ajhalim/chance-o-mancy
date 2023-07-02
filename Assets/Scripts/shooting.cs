using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint;
    public GameObject dicePrefab;
    public Camera cam;
    [SerializeField] SpriteRenderer bodyRenderer;
    [SerializeField] SpriteRenderer headRenderer;
    [SerializeField] Sprite none, fire, earth, air, universe, water;
    [SerializeField] float shootCooldown = 0.5f;
    public float diceForce = 20f;

    public int diceNum;
    public string diceElem;

    public string d4Val;
    public string d6Val;
    public string d8Val;
    public string d12Val;
    public string d20Val;

    [SerializeField] Image d4Indicator, d6Indicator, d8Indicator, d12Indicator, d20Indicator;

    float lastShootTime = 0;

    //new Color()
    void Start()
    {
        d4Val = PlayerPrefs.GetString("d4Num");
        d6Val = PlayerPrefs.GetString("d6Num");
        d8Val = PlayerPrefs.GetString("d8Num");
        d12Val = PlayerPrefs.GetString("d12Num");
        d20Val = PlayerPrefs.GetString("d20Num");

        diceNum = 4;
        diceElem = d4Val;
        colorBody(diceElem);
        headRenderer.sprite = fire;

        d4Indicator.color = GetColor(d4Val);
        d6Indicator.color = GetColor(d6Val);
        d8Indicator.color = GetColor(d8Val);
        d12Indicator.color = GetColor(d12Val);
        d20Indicator.color = GetColor(d20Val);

        //TODO: integrate with tetris mechanic
        /*
        bodyRenderer.color = currentDice.GetColor();
        headRenderer.color = currentDice.GetColor();

        switch (currentDice.diceType)
        {
            case DiceProfile.DiceType.D4:
                headRenderer.sprite = fire;
                break;
            case DiceProfile.DiceType.D6:
                headRenderer.sprite = earth;
                break;
            case DiceProfile.DiceType.D8:
                headRenderer.sprite = air;
                break;
            case DiceProfile.DiceType.D12:
                headRenderer.sprite = universe;
                break;
            case DiceProfile.DiceType.D20:
            default:
                headRenderer.sprite = water;
                break;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        //This was really dumb but it works
        if (Input.GetKeyDown("1"))
        {
            diceNum = 4;
            diceElem = d4Val;
            colorBody(diceElem);
            headRenderer.sprite = fire;
        }
        if (Input.GetKeyDown("2"))
        {
            diceNum = 6;
            diceElem = d6Val;
            colorBody(diceElem);
            headRenderer.sprite = earth;
        }
        if (Input.GetKeyDown("3"))
        {
            diceNum = 8;
            diceElem = d8Val;
            colorBody(diceElem);
            headRenderer.sprite = air;
        }
        if (Input.GetKeyDown("4"))
        {
            diceNum = 12;
            diceElem = d12Val;
            colorBody(diceElem);
            headRenderer.sprite = universe;
        }
        if (Input.GetKeyDown("5"))
        {
            diceNum = 20;
            diceElem = d20Val;
            colorBody(diceElem);
            headRenderer.sprite = water;
        }
        if (Input.GetButton("Fire1") && lastShootTime + shootCooldown < Time.time)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    void Shoot()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        firePoint.up = mousePos - firePoint.position;
        diceScript dice = Instantiate(dicePrefab, firePoint.position, firePoint.rotation).GetComponent<diceScript>();
        dice.Setup(firePoint.up * diceForce, diceNum, diceElem);
    }

    public void colorBody(string element)
    {
        bodyRenderer.color = GetColor(element);
        headRenderer.color = GetColor(element);
    }

    Color GetColor(string element)
    {
        switch (element)
        {
            case "fire":
                return new Color(255 / 255f, 80 / 255f, 1 / 255f, 255 / 255f);

            case "earth":
                return new Color(93 / 255f, 69 / 255f, 56 / 255f, 255 / 255f);

            case "wind":
                return new Color(148 / 255f, 217 / 255f, 223 / 255f, 255 / 255f);

            case "universe":
                return new Color(90 / 255f, 0 / 255f, 148 / 255f, 255 / 255f);

            case "water":
                return new Color(78 / 255f, 101 / 255f, 196 / 255f, 255 / 255f);

            default:
                return Color.white;

        }
    }
}
