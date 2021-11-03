using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropResize : MonoBehaviour
{
    private RectTransform rt;
    private Dropdown drop;

    public StoryBox sBox;

    private void Start()
    {
        rt = this.GetComponent<RectTransform>();
        drop = this.GetComponent<Dropdown>();
    }

    //resize the dropdown based on the current option's label length
    public void Resize( int option )
    {
        int width = 0;
        const int MINIMUM_WIDTH = 300;
        int expandedWidth = ( ( drop.options[option].text.Length ) * 40 );

        if (drop.options[option].text.Length < 5 )
        {
            width = MINIMUM_WIDTH;
        }
        else
        {            
            width = expandedWidth;
        }
        rt.sizeDelta = new Vector2(width, sBox.dropHeight);
        sBox.RepositionElements();
    }
}
