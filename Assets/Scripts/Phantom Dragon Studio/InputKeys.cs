using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputKeys : MonoBehaviour
 {
     public AdventureGame _adventureGame;
 
     private void Update()
     {
         if (Input.GetKeyDown(KeyCode.W))
         {
             var options = _adventureGame.state.GetNextStates();
             _adventureGame.ManageState(options[0].GetIndex());
         }
 
         if (Input.GetKeyDown(KeyCode.D))
         {
             _adventureGame.ManageState(_adventureGame.state.GetNextStates()[1].GetIndex());
         }
 
         if (Input.GetKeyDown(KeyCode.A))
             _adventureGame.ManageState(_adventureGame.state.GetNextStates()[2].GetIndex());
     }
 }