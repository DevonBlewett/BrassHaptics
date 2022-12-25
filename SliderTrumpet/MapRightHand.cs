/* Brass Haptics MapRightHand.cs
* Created by Devon Blewett December 2022
* 
* This script places the prefab blocks for the valves on the right hand
* 
*
*/
using System.Collections.Generic;
using UnityEngine;

public class MapRightHand : MonoBehaviour
{
    private bool notMapped = true;
    // prefabs for the cubes to be put on the hand
    public GameObject indexCube;
    public GameObject middleCube;
    public GameObject ringCube;
    // prefab for the trigger zone to be placed in the palm
    public GameObject plane;
    public OVRSkeleton skeleton;
    private List<OVRBone> fingerBones; 
    public OVRHand rightHand;


    public bool ready = false;
        
    public void SetSkeleton()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
    }


    // Update is called once per frame
    void Update()
    {
        if (rightHand.IsTracked)
        {
            ready = true;

        // if there are no bones, try to get the list of bones again
        if (fingerBones == null || fingerBones.Count == 0)
        {
            fingerBones = new List<OVRBone>(skeleton.Bones);
        }

    

                if (fingerBones.Count > 1)
                {

                   // if there are bones and the hand was not already mapped, add the prefabs to the three fingertips and palm
                   // the exact positions can be modified for personal preference
                    if (notMapped)
                    {
                        notMapped = false;

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


                        GameObject newplane = Instantiate(plane);
                        newplane.transform.position = new Vector3(0, 0, 0);
                        newplane.GetComponent<Renderer>().material.color = Color.black;
                        newplane.transform.parent = fingerBones[1].Transform;
                        newplane.transform.localPosition = new Vector3(fingerBones[1].Transform.localPosition.x + .01f, fingerBones[1].Transform.localPosition.y - .05f, fingerBones[1].Transform.localPosition.z);
                        newplane.transform.localRotation = new Quaternion(0, 0, 90, 0);

                    }


                }
            
        }
    }
}
