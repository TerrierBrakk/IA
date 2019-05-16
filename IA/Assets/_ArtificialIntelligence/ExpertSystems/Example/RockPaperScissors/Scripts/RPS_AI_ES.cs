using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockPaperScissors
{
	public class RPS_AI_ES : RPS_AI 
	{
		public override RPS GetNextMove()
		{
			return base.GetNextMove();
		}
		
		public override void SetLastGameResult(GameResult lastGameResult, RPS userLastMove)
		{
			Debug.Log("---- Expert System ---- \n");
			base.SetLastGameResult(lastGameResult, userLastMove);
		}
	}
}