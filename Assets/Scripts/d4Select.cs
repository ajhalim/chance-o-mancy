using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d4Select : MonoBehaviour
{
    // Start is called before the first frame update
    public int elementalNum = 0;
    public void changeElement()
    {
        if (elementalNum >= 4)
        {
            elementalNum = 0;
        }
        elementalNum++;
        print(elementalNum);

    }

}
