/* Brass Haptics valve.cs
* Created by Devon Blewett December 2022
* 
* This script detects collision in the named valve and sends the activation/deactivation information to the virtual trumpet
* 
*
*/
using UnityEngine;

public class valve : MonoBehaviour
{
    // set this in the editor to the name of the valve
    public string name = "";
    // the trumpet to send information to
    private SliderTrumpetV3 trumpet;
    // Start is called before the first frame update
    void Start()
    {
        trumpet = FindObjectOfType<SliderTrumpetV3>();
        if (!trumpet)
        {
            print("trumpet not found");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if the cube this script is on collides with the "blocker", which should be in the user's palm, activate this valve   
        if (other.gameObject.tag == "blocker")
        {
            if (trumpet)
            {
                trumpet.Activate(name);
                GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        // if the cube this script is on stops colliding, deactivate this valve
        if (other.gameObject.tag == "blocker")
        {
            if (trumpet)
            {
                trumpet.Deactivate(name);
                GetComponent<Renderer>().material.color = Color.magenta;
            }
        }
    }
   

}
