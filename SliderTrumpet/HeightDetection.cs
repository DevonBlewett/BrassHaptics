/* Brass Haptics HeightDetection.cs
* Created by Devon Blewett December 2022
* 
* This script measures the cubes world height to determine which register to activate when pinching
* 
*
*/

using UnityEngine;

public class HeightDetection : MonoBehaviour
{
    // previous register name
    public string previous = "";

    // lists of the min and max ranges for the five registers used in our program
    public double[] mins = new double[5];
    public double[] maxs = new double[5];

    // materials for when active or not active in each zone
    public Material[] activemats = new Material[5];
    public Material[] inactivemats = new Material[5];

   // variables for the hand and trumpet
    public OVRHand hand;
    public SliderTrumpetV3 trumpet;
    // bool for if the hand is pinching or not
    public bool isPinching = false;

    // Start is called before the first frame update
    void Start()
    {
        // these values were found within the editor and written here.
        maxs[4] = -0.417;
        maxs[3] = -0.5762;
        maxs[2] = -0.7255;
        maxs[1] = -0.882;
        maxs[0] = -1.05;

        mins[4] = -0.501;
        mins[3] = -0.6643;
        mins[2] = -0.8118;
        mins[1] = -0.974;
        mins[0] = -1.13;

        hand = GameObject.Find("LeftHand").GetComponent<OVRHand>();
        trumpet = FindObjectOfType<SliderTrumpetV3>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!trumpet)
        {
            trumpet = FindObjectOfType<SliderTrumpetV3>();
        }
        if (!hand)
        {
            hand = GameObject.Find("LeftHand").GetComponent<OVRHand>();
        }
        else
        {
            //  check if the hand is pinching
            if (hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
            {
                isPinching = true;
            }
            // if the hand is not pinching, make sure all the registers are disabled so a note can't play
            else if (!hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
            {
                isPinching = false;
                trumpet.UpdateNote();
                trumpet.Deselect("red");
                trumpet.Deselect("orange");
                trumpet.Deselect("green");
                trumpet.Deselect("lightblue");
                trumpet.Deselect("blue");
            }
            else
            {
                isPinching = false;
                trumpet.UpdateNote();
                trumpet.Deselect("red");
                trumpet.Deselect("orange");
                trumpet.Deselect("green");
                trumpet.Deselect("lightblue");
                trumpet.Deselect("blue");
            }
            // Control to check which zone the hand is in, check that it is not already playing a note in that zone to avoid looping, 
            // activeate this register and deactivate other registers
            if (transform.position.y <= maxs[4] && transform.position.y >= mins[4])
            {
                if (isPinching)
                {
                    if(previous != "red" && trumpet.isActive)
                    {
                        trumpet.UpdateNote();
                        previous = "red";
                        trumpet.isActive = false;
                    }
                    GetComponent<Renderer>().material = activemats[4];
                    if (!trumpet.isActive)
                    {
                        trumpet.Select("red");
                        trumpet.Deselect("orange");
                        trumpet.Deselect("green");
                        trumpet.Deselect("lightblue");
                        trumpet.Deselect("blue");
                    }
                }
                else
                {
                    GetComponent<Renderer>().material = inactivemats[4];
                    trumpet.Deselect("red");

                }
                previous = "red";
            }
            if (transform.position.y <= maxs[3] && transform.position.y >= mins[3])
            {
                if (isPinching)
                {
                    if (previous != "orange" && trumpet.isActive)
                    {
                        trumpet.UpdateNote();
                        previous = "orange";
                        trumpet.isActive = false;
                    }
                    GetComponent<Renderer>().material = activemats[3];
                    if (!trumpet.isActive) {
                        trumpet.Deselect("red");
                        trumpet.Select("orange");
                        trumpet.Deselect("green");
                        trumpet.Deselect("lightblue");
                        trumpet.Deselect("blue");

                    }

                }
                else
                {
                    GetComponent<Renderer>().material = inactivemats[3];
                    trumpet.Deselect("orange");

                }
                previous = "orange";
            }
            if (transform.position.y <= maxs[2] && transform.position.y >= mins[2])
            {
                if (isPinching)
                {
                    if (previous != "green" && trumpet.isActive)
                    {
                        trumpet.UpdateNote();
                        previous = "green";
                        trumpet.isActive = false;
                    }
                    GetComponent<Renderer>().material = activemats[2];
                    if (!trumpet.isActive)
                    {
                        trumpet.Select("green");
                        trumpet.Deselect("red");
                        trumpet.Deselect("orange");
                        trumpet.Deselect("lightblue");
                        trumpet.Deselect("blue");
                    }

                }
                else
                {
                    GetComponent<Renderer>().material = inactivemats[2];
                    trumpet.Deselect("green");

                }
                previous = "green";
            }
            if (transform.position.y <= maxs[1] && transform.position.y >= mins[1])
            {
                if (isPinching)
                {
                    if (previous != "lightblue" && trumpet.isActive)
                    {
                        trumpet.UpdateNote();
                        previous = "lightblue";
                        trumpet.isActive = false;
                    }
                    GetComponent<Renderer>().material = activemats[1];
                    if (!trumpet.isActive)
                    {
                        trumpet.Select("lightblue");
                        trumpet.Deselect("red");
                        trumpet.Deselect("orange");
                        trumpet.Deselect("green");
                        trumpet.Deselect("blue");
                    }


                }
                else
                {
                    GetComponent<Renderer>().material = inactivemats[1];
                    trumpet.Deselect("lightblue");

                }
                previous = "lightblue";
            }
            if (transform.position.y <= maxs[0] && transform.position.y >= mins[0])
            {
                if (isPinching)
                {
                    if (previous != "blue" && trumpet.isActive)
                    {
                        trumpet.UpdateNote();
                        previous = "blue";
                        trumpet.isActive = false;
                    }
                    GetComponent<Renderer>().material = activemats[0];
                    if (!trumpet.isActive)
                    {
                        trumpet.Select("blue");
                        trumpet.Deselect("red");
                        trumpet.Deselect("orange");
                        trumpet.Deselect("green");
                        trumpet.Deselect("lightblue");
                    }

                }
                else
                {
                    GetComponent<Renderer>().material = inactivemats[0];
                    trumpet.Deselect("blue");

                }
                previous = "blue";
            }
        }
    }
}
