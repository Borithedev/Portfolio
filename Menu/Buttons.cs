using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Buttons : MonoBehaviour
{
    public Button menubuttons;
    public Sprite unselected;
    public Sprite selected;
    private int counter = 0;
      
    // Start is called before the first frame update
    void Start()
    {
        menubuttons = GetComponent<Button>();
    }

        public void changeButton()
        {
            counter++;
            if(counter % 2 == 0)
            {
                menubuttons.image.overrideSprite = unselected;
            }
            else
            {
                menubuttons.image.overrideSprite = selected;
            }
        }
}
