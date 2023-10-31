using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Colour_Changer : MonoBehaviour
{
    [SerializeField] private Color Chosen_Color;
    [SerializeField] private Material Shared_Material;
    [SerializeField] private GameObject Car_Object_1;
    [SerializeField] private GameObject Car_Object_2;

    private void Start()
    {
        string Saved_Color = PlayerPrefs.GetString("Chosen_Colour");

        if (!string.IsNullOrEmpty(Saved_Color))
        {
            Debug.Log(Saved_Color);
            Debug.Log("WOOHOOO");
            if (ColorUtility.TryParseHtmlString(Saved_Color, out Color Loaded_Color))
            {
                Debug.Log("YAAAAY");
                Chosen_Color = Loaded_Color;
            }
            else
            {
                Chosen_Color = Color.white;
            }

            // Change the materials of the objects
            Change_Object_Materials(Car_Object_1);
            Change_Object_Materials(Car_Object_2);
        }
    }

    public void Change_UI()
    {

    }

    private void Change_Object_Materials(GameObject Car)
    {
        Renderer Car_Renderer = Car.GetComponent<Renderer>();
        if (Car_Renderer != null)
        {
            Car_Renderer.material = Shared_Material; // Assign the shared material to the object.
            Car_Renderer.material.color = Chosen_Color; // Change the color of the shared material.
        }
    }

    public void ResetCarColor()
    {
        Chosen_Color = Color.white;
        Change_Object_Materials(Car_Object_1);
        Change_Object_Materials(Car_Object_2);
    }
}