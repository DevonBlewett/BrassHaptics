/* Brass Haptics MapLeftPinch.cs
* Created by Devon Blewett December 2022
* 
* This script places the prefab for the block used to pinch the register selection
* 
*
*/


using System.Collections.Generic;
using UnityEngine;

public class MapLeftPinch : MonoBehaviour
{
    // bool for if the hand is already mapped
    private bool notMapped = true;
    // the cube to be attached to the middle finger
    public GameObject Cube;
    // variable for the hand skeleton
    public OVRSkeleton skeleton;
    // list to hold the bones in the skeleton
    private List<OVRBone> fingerBones;
    // variable for the hand information
    public OVRHand leftHand;


    public bool ready = false;

    public void SetSkeleton()
    {
        // create a list of the bones in the skeleton
        fingerBones = new List<OVRBone>(skeleton.Bones);
    }



    // Update is called once per frame
    void Update()
    {

        if (leftHand.IsTracked)
        {
            ready = true;

            // if there are no bones in the list, such as if loading has lagged, try to get the bones again
            if (fingerBones == null || fingerBones.Count == 0)
            {
                fingerBones = new List<OVRBone>(skeleton.Bones);
            }

           
                  
                if (fingerBones.Count > 1)
                {

                    /* Draw the cubes along the hand bones, leaving out some cause they don't display well */
                    if (notMapped)
                    {
                        notMapped = false;

                        GameObject newBlock = Instantiate(Cube);


                        newBlock.transform.position = new Vector3(0, 0, 0);
                        newBlock.GetComponent<Renderer>().material.color = Color.magenta;
                        newBlock.transform.parent = fingerBones[11].Transform;
                        newBlock.transform.localPosition = fingerBones[11].Transform.localPosition;


                    }


                }
            
        }
    }
}
