using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

public class CodeConstructor : MonoBehaviour
{
    public string StringConstruction;
    [SerializeField] Canvas currCanvas;
    [SerializeField] Canvas currCanvas2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateString()
    {
        var Codes = FindObjectsOfType<CodeCycler>();
        StringBuilder builder = new StringBuilder();
        foreach (var Code in Codes)
        {
            builder.Insert(Code.index, Code.codeBit);
        }
        currCanvas.enabled = false;
        FindObjectOfType<CodeDecryptor>().DecryptCode(builder.ToString());
        currCanvas2.enabled = true;
    }

    public void BackToString()
    {
        currCanvas.enabled = true;
        currCanvas2.enabled = false;
    }
}
