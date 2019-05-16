using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockPaperScissors
{
	public class RPS_AI : MonoBehaviour 
	{
		private RPS lastAIChoice;
		
		public virtual void SetLastGameResult(GameResult lastGameResult , RPS userLastMove)
		{
			Debug.Log("Last Match Results [Human: "+userLastMove.ToString()+"] | [AI: "+lastAIChoice.ToString()+"] : "+lastGameResult.ToString()+"\n");
		}
		
		public virtual RPS GetNextMove()
		{
			lastAIChoice = (RPS)Random.Range(0,3);
			return lastAIChoice;
		}
	
	}
}