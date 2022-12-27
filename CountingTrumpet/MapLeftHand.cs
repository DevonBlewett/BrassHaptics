/* Brass Haptics MapRightHand.cs
* Created by Devon Blewett December 2022
* 
* This script places the prefab blocks for the register selection on the left hand
* 
*
*/

using System.Collections.Generic;
using UnityEngine;

public class MapLeftHand : MonoBehaviour
{
    private bool notMapped = true;
    // prefabs for the cubes to be placed on the fingertips
    public GameObject indexCube;
    public GameObject middleCube;
    public GameObject ringCube;
    public GameObject pinkyCube;
    public GameObject thumbCube;
    // prefab for the collision zone to be placed in the palm
    public GameObject plane;
    public OVRSkeleton skeleton;
    private List<OVRBone> fingerBones;
    public OVRHand leftHand;


    public bool ready = false;

    public void SetSkeleton()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
    }



    void Update()
    {
        if (leftHand.IsTracked)
        {
            ready = true;

            // if there are no bones, try to get the list of bones again
            if (fingerBones == null || fingerBones.Count == 0)
            {
                fingerBones = new List<OVRBone>(skeleton.Bones);
            }

   
            // if there are bones, map the cubes to the fingertips
                if (fingerBones.Count > 1)
                {
                
                    if (notMapped)
                    {
                        notMapped = false;
                    // exact positions can be modified.  In our tests, the left hand cubes did not align properly and may need some rotation.
                        GameObject newBlock = Instantiate(indexCube);
                        newBlock.transform.position = new Vector3(0, 0, 0);
                        newBlock.GetComponent<Renderer>().material.color = Color.magenta;
                        newBlock.transform.parent = fingerBones[8].Transform;
                        newBlock.transform.localPosition = fingerBones[8].Transform.localPosition;

                        newBlock = Instantiate(middleCube);
                        newBlock.transform.position = new Vector3(0, 0, 0);
                        newBlock.GetComponent<Renderer>().material.color = Color.magenta;
                        newBlock.transform.parent = fingerBones[11].Transform;
                        newBlock.transform.localPosition = fingerBones[11].Transform.localPosition;

                        newBlock = Instantiate(ringCube);
                        newBlock.transform.position = new Vector3(0, 0, 0);
                        newBlock.GetComponent<Renderer>().material.color = Color.magenta;
                        newBlock.transform.parent = fingerBones[14].Transform;
                        newBlock.transform.localPosition = fingerBones[14].Transform.localPosition;


                        newBlock = Instantiate(thumbCube);
                        newBlock.transform.position = new Vector3(0, 0, 0);
                        newBlock.GetComponent<Renderer>().material.color = Color.magenta;
                        newBlock.transform.parent = fingerBones[5].Transform;
                        newBlock.transform.localPosition = fingerBones[5].Transform.localPosition;



                        newBlock = Instantiate(pinkyCube);
                        newBlock.transform.position = new Vector3(0, 0, 0);
                        newBlock.GetComponent<Renderer>().material.color = Color.magenta;
                        newBlock.transform.parent = fingerBones[18].Transform;
                        newBlock.transform.localPosition = fingerBones[18].Transform.localPosition;

                        GameObject newplane = Instantiate(plane);
                        newplane.transform.position = new Vector3(0, 0, 0);
                        newplane.GetComponent<Renderer>().material.color = Color.black;
                        newplane.transform.parent = fingerBones[1].Transform;
                        newplane.transform.localPosition = new Vector3(fingerBones[1].Transform.localPosition.x - .19f, fingerBones[1].Transform.localPosition.y + .1f, fingerBones[1].Transform.localPosition.z);
                        //  newplane.transform.localRotation = new Quaternion(0, 0, 90, 0);

                    }


                }
            }
        
    }
}
