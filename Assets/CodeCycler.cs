using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeCycler : MonoBehaviour
{
    [SerializeField] bool Character;
    [SerializeField] int counter = 0;
    [SerializeField] TextMeshProUGUI textMeshPro;
    public int index;
    public string codeBit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Character)
        {
            switch(counter)
            {
                case 0:
                    textMeshPro.text = "A";
                    codeBit = "A";
                    break;

                case 1:
                    textMeshPro.text = "B";
                    codeBit = "B";
                    break;
                    case 2:
                    textMeshPro.text = "C";
                    codeBit = "C";
                    break;

                case 3:
                    textMeshPro.text = "D";
                    codeBit = "D";
                    break;
                    case 4:
                    textMeshPro.text = "E";
                    codeBit = "E";
                    break;
                    case 5:
                    textMeshPro.text = "F";
                    codeBit = "F";
                    break;
                    case 6:
                    textMeshPro.text = "G";
                    codeBit= "G";
                    break;
                    case 7:
                    textMeshPro.text = "H";
                    codeBit = "H";
                    break;
                    case 8:
                    textMeshPro.text = "I";
                    codeBit = "I";
                    break;
                    case 9:
                    textMeshPro.text = "J";
                    codeBit = "J";
                    break;

            }
        }
        else
        {
            textMeshPro.text=counter.ToString();
            codeBit=counter.ToString();
        }
    }

    public void Add()
    {
        if(counter<9)
        {
            counter++;
        }
    }

    public void Decrease()
    {
        if (counter > 0)
        {
            counter--;
        }
    }
}
