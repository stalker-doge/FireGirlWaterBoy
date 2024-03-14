using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class CodeDecryptor : MonoBehaviour
{
    //two dictionaries, one for character and what wire colour it represents, and another for integers and how many wires to cut

    public Dictionary<char, string> wireColour = new Dictionary<char, string>();
    public Dictionary<int, string> wireCut = new Dictionary<int, string>();

    public string userSerialCode;

    [SerializeField] TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        //initialise the dictionaries
        wireColour.Add('A', "RED Wire");
        wireColour.Add('B', "BLUE Wire");
        wireColour.Add('C', "GREEN Wire");
        wireColour.Add('D', "FAKE Wire");
        wireColour.Add('E', "WHITE Wire");
        wireColour.Add('F', "GOLD Wire");
        wireColour.Add('G', "FAKE Wire");
        wireColour.Add('H', "FAKE Wire");
        wireColour.Add('I', "FAKE Wire");
        wireColour.Add('J', "FAKE Wire");

        wireCut.Add(1, "1 wires");
        wireCut.Add(2, "2 wires");
        wireCut.Add(3, "1 wire");
        wireCut.Add(4, "2 wires");
        wireCut.Add(5, "1 wires");
        wireCut.Add(6, "2 wires");
        wireCut.Add(7, "2 wires");
        wireCut.Add(8, "2 wires");
        wireCut.Add(9, "1 wires");
        wireCut.Add(0, "1 wires");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecryptCode(string Code)
    {
        Debug.Log(Code);
        StringBuilder builder = new StringBuilder();
        //convert the serial code to a set of instructions, all serial codes follow the format of letter number and so on
        for (int i = 0; i < Code.Length; i++)
        {
            if (i % 2 == 0)
            {
                char currentChar = Code[i];
                if (wireColour.ContainsKey(currentChar))
                {
                    if (wireColour[currentChar].ToString() != "FAKE Wire")
                    {
                        Debug.Log("Cut the " + wireColour[currentChar]);
                        builder.Append("Cut the " + wireColour[currentChar] + " ");
                    }

                }
            }
            else
            {
                int currentInt = (int)char.GetNumericValue(Code[i]);
                if (wireCut.ContainsKey(currentInt))
                {
                    Debug.Log("Cut " + wireCut[currentInt]);
                    builder.Append(wireCut[currentInt] + " times \n");
                }
            }
        }
        textMeshPro.text = builder.ToString();
    }
}
