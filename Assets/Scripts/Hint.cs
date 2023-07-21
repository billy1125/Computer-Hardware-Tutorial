using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HintTexts
{
    [TextArea]
    public string HintText;
}

public class Hint : MonoBehaviour
{
    public List<HintTexts> hintTexts = new List<HintTexts>();
    public Text HintTextBox;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ChangeText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeText()
    {
       
        for (i = 0; i < hintTexts.Count; i++)
        {
            HintTextBox.text = "´£¥Ü¡G" + hintTexts[i].HintText;
            
            yield return new WaitForSeconds(5.0f);
            if (i == hintTexts.Count - 1)
                i = -1;
        }
    }
}
