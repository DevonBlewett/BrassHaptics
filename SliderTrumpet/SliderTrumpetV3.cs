/* Brass Haptics SliderTrumpetV3.cs
 * Created by Devon Blewett December 2022
 * 
 * This script contains a virtual trumpet that plays notes based on activated register and valves
 * 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PitchDetector;
using MidiPlayerTK;
using TMPro;

public class SliderTrumpetV3 : MonoBehaviour
{
    // value of note to be played
    public int noteValue = 67;
    // value of the current not being played
    public int currentNote = 0;
    // MPTKEvent, which contains value, velocity, ect, to play note in Unity
    MPTKEvent playNote;

    // bool for if trumpet is currently playing note
    public bool isActive = false;

    // bools for if the valves are active
    public bool f1Active = false;
    public bool f2Active = false;
    public bool f3Active = false;

    // bools for which register is active
    public bool l1Active = false;
    public bool l2Active = false;
    public bool l3Active = false;
    public bool l4Active = false;
    public bool l5Active = false;

    // reference to the Midistream player used to play the MPTK event.  Remeber to set this trumpet to transpose -2
    public MidiStreamPlayer trumpet;
    // enum for the possible octave states
    public enum Register { First, Second, Third, Fourth, Fifth, Off };

    // variable to store which register is active
    public Register reg = Register.Off;
    // set event handlers 
    void Start()
    {
        // set the channel to trumpet
        trumpet.MPTK_ChannelForcedPresetSet(0, 56);
        // create an MPTK event to use
        playNote = new MPTKEvent()
        {
            Channel = 0,
            Length = 3000,
            Velocity = 50,

            Value = noteValue



        };
    }


    void Update()
    {
        // a series of branch statements to determine which register is currently being pinched
        // starts at 54
        if (l5Active)
        {
            // 80 - 84
            isActive = true; //base notes 3
            reg = Register.Fifth;

        }
        else if (l4Active)
        {
            // 73 - 79
            isActive = true;// off notes 2
            reg = Register.Fourth;
        }
        else if (l3Active)
        {
            // 68 - 72
            isActive = true;// base notes 2
            reg = Register.Third;
        }

        else if (l2Active)
        {
            // 61 - 67
            isActive = true; // off notes 1
            reg = Register.Second;
        }
        else if (l1Active)
        {
            //54 - 60 
            isActive = true; // base notes 1
            reg = Register.First;
        }
        else
        {
            isActive = false;
        }
        // if the trumpet is currently active (a register has been pinched), evaluate the valve state and set noteValue
        if (isActive)
        {
            
            if (!f1Active && !f2Active && !f3Active)
            {
                if (reg == Register.First)
                {
                    noteValue = 60;
                }
                else if (reg == Register.Second)
                {
                    noteValue = 67;
                }
                else if (reg == Register.Third)
                {
                    noteValue = 72;
                }
                else if (reg == Register.Fourth)
                {
                    noteValue = 79;
                }
                else if (reg == Register.Fifth)
                {
                    noteValue = 84;
                }
            }
            else if (f1Active || f2Active || f3Active)
            {
                if (f1Active && f2Active && f3Active)
                {
                    if (reg == Register.First)
                    {
                        noteValue = 54;
                    }
                    else if (reg == Register.Second)
                    {
                        noteValue = 61;
                    }
                    else if (reg == Register.Third)
                    {
                        noteValue = -1;
                    }
                    else if (reg == Register.Fourth)
                    {
                        noteValue = 73;
                    }
                    else if (reg == Register.Fifth)
                    {
                        noteValue = -1;
                    }
                }
                else if (f1Active && f2Active)
                {
                    if (reg == Register.First)
                    {
                        noteValue = 57;
                    }
                    else if (reg == Register.Second)
                    {
                        noteValue = 64;
                    }
                    else if (reg == Register.Third)
                    {
                        noteValue = 69;
                    }
                    else if (reg == Register.Fourth)
                    {
                        noteValue = 76;
                    }
                    else if (reg == Register.Fifth)
                    {
                        noteValue = 81;
                    }
                }

                else if (f1Active && f3Active)
                {
                    if (reg == Register.First)
                    {
                        noteValue = 55;
                    }
                    else if (reg == Register.Second)
                    {
                        noteValue = 62;
                    }
                    else if (reg == Register.Third)
                    {
                        noteValue = -1;
                    }
                    else if (reg == Register.Fourth)
                    {
                        noteValue = 74;
                    }
                    else if (reg == Register.Fifth)
                    {
                        noteValue = -1;
                    }
                }
                else if (f2Active && f3Active)
                {
                    if (reg == Register.First)
                    {
                        noteValue = 56;
                    }
                    else if (reg == Register.Second)
                    {
                        noteValue = 63;
                    }
                    else if (reg == Register.Third)
                    {
                        noteValue = 68;
                    }
                    else if (reg == Register.Fourth)
                    {
                        noteValue = 75;
                    }
                    else if (reg == Register.Fifth)
                    {
                        noteValue = 80;
                    }
                }
                else if (f1Active)
                {
                    if (reg == Register.First)
                    {

                        noteValue = 58;
                    }
                    else if (reg == Register.Second)
                    {
                        noteValue = 65;
                    }
                    else if (reg == Register.Third)
                    {
                        noteValue = 70;
                    }
                    else if (reg == Register.Fourth)
                    {
                        noteValue = 77;
                    }
                    else if (reg == Register.Fifth)
                    {
                        noteValue = 82;
                    }
                }
                else if (f2Active)
                {
                    if (reg == Register.First)
                    {
                        noteValue = 59;
                    }
                    else if (reg == Register.Second)
                    {
                        noteValue = 66;
                    }
                    else if (reg == Register.Third)
                    {
                        noteValue = 71;
                    }
                    else if (reg == Register.Fourth)
                    {
                        noteValue = 78;
                    }
                    else if (reg == Register.Fifth)
                    {
                        noteValue = 83;
                    }
                }
                else if (f3Active)
                {
                    if (reg == Register.First)
                    {
                        noteValue = -1;
                    }
                    else if (reg == Register.Second)
                    {
                        noteValue = -1;
                    }
                    else if (reg == Register.Third)
                    {
                        noteValue = -1;
                    }
                    else if (reg == Register.Fourth)
                    {
                        noteValue = -1;
                    }
                    else if (reg == Register.Fifth)
                    {
                        noteValue = -1;
                    }
                }



            }
            // if the current note does not match the note to be played (prevent looping)
            if (currentNote != noteValue && noteValue != -1)
            {
                // set the note
                currentNote = noteValue;
                // set the MIDi values and play the note
                //56
                trumpet.MPTK_ChannelForcedPresetSet(0, 56);
                playNote.Value = noteValue;
                playNote.Channel = 0;
                playNote.Length = 10;
                playNote.Duration = -1;
                trumpet.MPTK_PlayEvent(playNote);
            }
 
        }
    }



   
    // receive input about which valves are pressed
    public void Activate(string fname)
    {
        print("activate: " + fname);
        if (fname == "index")
        {
            f1Active = true;

        }
        if (fname == "middle")
        {
            f2Active = true;
        }
        if (fname == "ring")
        {
            f3Active = true;
        }
        // update the note whenever the valve state changes
        UpdateNote();

    }

    // receive input about the valve state being turned off
    public void Deactivate(string fname)
    {
        if (fname == "index")
        {
            f1Active = false;

        }
        if (fname == "middle")
        {
            f2Active = false;
        }
        if (fname == "ring")
        {
            f3Active = false;
        }
        // update the note whenever the valve state changes
        UpdateNote();

    }
    // stops the current note to prevent a permanent tone 
    public void UpdateNote()
    {
        trumpet.MPTK_StopEvent(playNote);
    }
    // receive input about the octave that is pinched
    public void Select(string name)
    {
        UpdateNote();
        currentNote = 0;
        if (name == "blue")
        {
            l1Active = true;
        }
        if (name == "lightblue")
        {
            l2Active = true;
        }
        if (name == "green")
        {
            l3Active = true;
        }
        if (name == "orange")
        {
            l4Active = true;
        }
        if (name == "red")
        {
            l5Active = true;
        }
    }
    // receive input about an octave being unselected
    public void Deselect(string name)
    {
        UpdateNote();
        currentNote = 0;
        if (name == "blue")
        {
            l1Active = false;
        }
        if (name == "lightblue")
        {
            l2Active = false;
        }
        if (name == "green")
        {
            l3Active = false;
        }
        if (name == "orange")
        {
            l4Active = false;
        }
        if (name == "red")
        {
            l5Active = false;
        }
    }


}
