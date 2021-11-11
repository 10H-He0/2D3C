using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ForwardKey : MonoBehaviour, IPointerExitHandler, IPointerClickHandler
{
    public KeyCode currentKeycode;
    bool isstart = false;
    public Text text;
    public GameObject obj;

    public void OnPointerClick(PointerEventData eventData)
    {
        isstart = true;
        this.GetComponent<Image>().color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isstart = false;
        this.GetComponent<Image>().color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentKeycode = obj.GetComponent<Player>().Righ;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isstart) return;
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
                    continue;
                if (Input.GetKeyDown(keyCode))
                {
                    currentKeycode = keyCode;
                }
            }
        }
        text.text = currentKeycode.ToString();
        obj.GetComponent<Player>().Righ = currentKeycode;
    }
}
