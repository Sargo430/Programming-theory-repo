using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;

public class ActionButton : MonoBehaviour
{
    private int m_actionNumber;
    public int aNumber;
    private TextMeshProUGUI buttonText;
    public int actionNumber
    {
        get { return m_actionNumber; }
        set
        { 
            if(value < 1 || value > 4)
            {
                Debug.LogError("Invalid action number");
            }
            else
            {
                m_actionNumber = value;
            }
            
        }
    }
    
    private Button button;
    private Monkey monkey;
    // Start is called before the first frame update
    void Start()
    {
        buttonText= GetComponentInChildren<TextMeshProUGUI>();
        actionNumber = aNumber;
        monkey = GameObject.Find("Player").GetComponent<Monkey>();
        ButtonName();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAction()
    {
        Debug.Log(monkey.name);
        monkey.PlayerActions(actionNumber);
    }
    void ButtonName()
    {
        switch (actionNumber)
        {
            
            case 1:
                {
                    buttonText.text = monkey.firstAbility;
                    return;
                }
            case 2:
                {
                    buttonText.text= monkey.secondAbility;
                    return;
                }
            case 3:
                {
                    buttonText.text = monkey.thirdAbility;
                    return;
                }
            case 4:
                {
                    buttonText.text = monkey.fourthAbility;
                    return;
                }
        }
    }
}
