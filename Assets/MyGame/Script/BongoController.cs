using UnityEngine;
using System.Collections.Generic;

public class BongoController : MonoBehaviour
{
    public GameObject upObject;

    [System.Serializable]
    public class KeyPosition
    {
        public KeyCode key;
        public GameObject downObject;
    }


    // List to hold key positions
    public List<KeyPosition> keyPositions;

    private KeyCode currentKey = KeyCode.None;
    void Start()
    {
        upObject.SetActive(true);

        foreach (var key in keyPositions)
        {
            key.downObject.SetActive(false);
        }
    }

    void Update()
    {

        if (currentKey != KeyCode.None && !Input.GetKey(currentKey))
        {
            currentKey = KeyCode.None;
        }
        

        if(currentKey == KeyCode.None)
        {
            foreach (var key in keyPositions)
            {
                if (Input.GetKey(key.key))
                {
                    currentKey = key.key;
                    break;
                }
            }
        }

        bool anyKeyPressed = false;

        foreach(var key in keyPositions)
        {
            if(key.key == currentKey && currentKey != KeyCode.None)
            {
                if(key.downObject != null)
                {
                    key.downObject.SetActive(true);
                    anyKeyPressed = true;
                }
            }
            else
            {
                if(key.downObject != null)
                {
                    key.downObject.SetActive(false);
                }
            }
        }

        if (upObject != null)
        {
            upObject.SetActive(!anyKeyPressed);
        }
    }
}