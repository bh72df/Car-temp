using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Colour_Picker : MonoBehaviour
{
    public Menu_Controller Menu_Controller;

    public Slider Red_Slider;
    public Slider Green_Slider;
    public Slider Blue_Slider;
    public Image Colour_Image;

    private Color Chosen_Colour = Color.white;

    public void Colour_Change()
    {
        // Get slider values and create a color from them.
        float R = Red_Slider.value;
        float G = Green_Slider.value;
        float B = Blue_Slider.value;
        Chosen_Colour = new Color(R, G, B);

        Colour_Image.color = Chosen_Colour;
        Menu_Controller.Save_Chosen_Colour(Chosen_Colour);
    }
}