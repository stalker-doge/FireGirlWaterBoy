using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDecryptor : MonoBehaviour
{
    //two dictionaries, one for character and what wire colour it represents, and another for integers and how many wires to cut

    public Dictionary<char, string> wireColour = new Dictionary<char, string>();
    public Dictionary<int, string> wireCut = new Dictionary<int, string>();

    public string userSerialCode;


    // Start is called before the first frame update
    void Start()
    {
        //initialise the dictionaries
        wireColour.Add('A', "RED Wire");
        wireColour.Add('B', "BLUE Wire");
        wireColour.Add('C', "GREEN Wire");
        wireColour.Add('D', "YELLOW Wire");
        wireColour.Add('E', "WHITE Wire");
        wireColour.Add('F', "GOLD Wire");
        wireColour.Add('G', "FAKE Wire");
        wireColour.Add('H', "FAKE Wire");
        wireColour.Add('I', "FAKE Wire");
        wireColour.Add('J', "FAKE Wire");

        wireCut.Add(1, "3 wires");
        wireCut.Add(2, "2 wires");
        wireCut.Add(3, "1 wire");
        wireCut.Add(4, "5 wires");
        wireCut.Add(5, "4 wires");
        wireCut.Add(6, "3 wires");
        wireCut.Add(7, "2 wires");
        wireCut.Add(8, "2 wires");
        wireCut.Add(9, "1 wires");
        wireCut.Add(0, "4 wires");

        DecryptCode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecryptCode()
    {
        //convert the serial code to a set of instructions, all serial codes follow the format of letter number and so on
        for (int i = 0; i < userSerialCode.Length; i++)
        {
            if (i % 2 == 0)
            {
                char currentChar = userSerialCode[i];
                if (wireColour.ContainsKey(currentChar))
                {
                    Debug.Log("Cut the " + wireColour[currentChar]);
                }
                else
                {
                    Debug.Log("Invalid character detected");
                }
            }
            else
            {
                int currentInt = (int)char.GetNumericValue(userSerialCode[i]);
                if (wireCut.ContainsKey(currentInt))
                {
                    Debug.Log("Cut " + wireCut[currentInt]);
                }
                else
                {
                    Debug.Log("Invalid number detected");
                }
            }
        }

    }
}
