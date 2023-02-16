using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealtBar : MonoBehaviour
{
    public Image healthBarImage;
    public TextMeshProUGUI healthText;
    private Monkey monkey;
    // Start is called before the first frame update
    void Start()
    {
        monkey = GameObject.Find("Player").GetComponent<Monkey>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealthBar()
    {
        healthText.text = $"HP:{monkey.playerLife}/{monkey.playerMaxLife}";
        healthBarImage.fillAmount = Mathf.Clamp(monkey.playerLife/monkey.playerMaxLife, 0,1f);
    }
}
