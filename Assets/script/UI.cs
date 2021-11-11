using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text left;
    public Text right;
    public Text jump;

    public GameObject obj;
    public GameObject setting;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        act();
        left.text = obj.GetComponent<Player>().Lef.ToString();
        right.text = obj.GetComponent<Player>().Righ.ToString();
        jump.text = obj.GetComponent<Player>().Jump.ToString();
    }

    void act()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (setting.activeInHierarchy)
            {
                setting.SetActive(false);
                Time.timeScale = 1;
            }  
            else
            {
                setting.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
