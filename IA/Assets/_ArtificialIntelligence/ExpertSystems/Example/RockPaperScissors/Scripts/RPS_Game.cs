using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RockPaperScissors
{
	public enum RPS
	{
		Rock = 0,
		Paper = 1,
		Scissors = 2
	}
	
	public enum GameResult
	{
		Tie = 0,
		WonHuman = 1,
		WonAI = 2
	}
	
	public class RPS_Game : MonoBehaviour 
	{
		public Color[] resultColors;
	
		public Sprite[] rockPaperScisors_Sprites;
		public Image selectionHuman,selectionRandom, selectionExpertSystem;
		
		public Text[] resultTextRandom;
		public Text[] resultTextExpertSystem;
		
		public RPS_AI artificialIntelligence_Random;
		public RPS_AI artificialIntelligence_ExpertSystem;
		
		private int[] results_Random = new int[3];//0 tie 1 human 2 ai
		private int[] results_ExpertSystem = new int[3];//0 tie 1 human 2 ai
		
		public void OnPlayerChoice(int choice)
		{
			Debug.Log("New Match");
			selectionHuman.sprite = rockPaperScisors_Sprites[choice];
			
			CheckResult(false,ref results_Random      , (RPS)choice, artificialIntelligence_Random.GetNextMove());
			CheckResult(true ,ref results_ExpertSystem, (RPS)choice, artificialIntelligence_ExpertSystem.GetNextMove());
		}

		void CheckResult(bool isExpertSystem, ref int[] results, RPS lastUserChoice, RPS lastAIChoice)
		{
			RPS_AI artificialIntelligence = isExpertSystem? artificialIntelligence_ExpertSystem: artificialIntelligence_Random;
			
			int result=0;
			
			if(lastAIChoice==lastUserChoice)
			{
				//Tie
				results[0]++;
				artificialIntelligence.SetLastGameResult( GameResult.Tie,lastUserChoice);
			}
			else
			{
				if( 
					(lastUserChoice== RPS.Paper && lastAIChoice== RPS.Scissors) || 
					(lastUserChoice== RPS.Rock && lastAIChoice== RPS.Paper) || 
					(lastUserChoice== RPS.Scissors && lastAIChoice== RPS.Rock)
				   )
				{
					//AI Wins
					results[2]++;
					result=2;
					artificialIntelligence.SetLastGameResult( GameResult.WonAI,lastUserChoice);
				}
				else
				{
					//User Wins
					results[1]++;
					result=1;
					artificialIntelligence.SetLastGameResult( GameResult.WonHuman,lastUserChoice);
				}
			}
			
			if(isExpertSystem)
			{
				selectionExpertSystem.sprite = rockPaperScisors_Sprites[(int)lastAIChoice];
				selectionExpertSystem.color = resultColors[result];
			}
			else
			{
				selectionRandom.sprite = rockPaperScisors_Sprites[(int)lastAIChoice];
				selectionRandom.color = resultColors[result];
			}
			
			UpdateResults();
		}
		
		public void UpdateResults()
		{
			for(int i=0;i<3;i++)
			{
				resultTextRandom[i].text = results_Random[i].ToString();
				resultTextExpertSystem[i].text = results_ExpertSystem[i].ToString();
			}
		}
	}
}