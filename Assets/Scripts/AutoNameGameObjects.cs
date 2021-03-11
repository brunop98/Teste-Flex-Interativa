/**
 * Author: Bruno Poór
 * brunopoor@gmail.com  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


#if UNITY_EDITOR


public class AutoNameGameObjects : MonoBehaviour
{
    public void Autoname()
    {
        foreach (Text item in GameObject.FindObjectsOfType<Text>())
        {
            item.name = "Text " + item.text;
        }

        foreach (Image item in GameObject.FindObjectsOfType<Image>())
        {
            if (item.sprite == null) continue;
            item.name = "Image" + item.sprite.name;
        }

        foreach (Button item in GameObject.FindObjectsOfType<Button>())
        {

            if (!item.GetComponentInChildren<Text>()) continue;
            item.name = "Button " + item.GetComponentInChildren<Text>().text;
        }

        foreach (Slider item in GameObject.FindObjectsOfType<Slider>())
        {

            if (string.IsNullOrEmpty( item.onValueChanged.GetPersistentMethodName(0)) ) continue;
            item.name = "Slider -  " + item.onValueChanged.GetPersistentMethodName(0)  + "(" + item.onValueChanged.GetPersistentTarget(0).name + ")" ;
            // item.name = "Slider -  " +  ((GameObject) item.onValueChanged.GetPersistentTarget(0)).name ;
        }

        Debug.Log("UI Itens renamed!");
    }


    public void ImprooveUIPerfomence()
    {
        foreach (Text item in GameObject.FindObjectsOfType<Text>())
        {
            item.raycastTarget = false;
        }

        foreach (Image item in GameObject.FindObjectsOfType<Image>())
        {
            item.raycastTarget = false;
        }

        foreach (Slider item in GameObject.FindObjectsOfType<Slider>())
        {
            foreach(Image i in item.GetComponentsInChildren<Image>())
            {
                i.raycastTarget = true;
            }            
        }

        Debug.Log("UI Performance improoved!");

       
    }


}


#endif