using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RockPaperScissors
{

	public class RPS_Human : MonoBehaviour 
	{
		public RPS_Game gameManager;
		public void Update()
		{
			if(Input.GetKeyDown(KeyCode.A)) { gameManager.OnPlayerChoice(0);}
			if(Input.GetKeyDown(KeyCode.S)) { gameManager.OnPlayerChoice(1);}
			if(Input.GetKeyDown(KeyCode.D)) { gameManager.OnPlayerChoice(2);}
		}
	}
}