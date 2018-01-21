using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] cumulativeScores;
	public Text[] individualScores;

	private GameManager gameManager;

	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}

	public void UpdateScores(List<int> bowls){
		int j = 0;

		List<int> cumulativeScoresList = ScoreMaster.ScoreCumulative (bowls);

		for (int i = 0; i < cumulativeScoresList.Count; i++) {
			cumulativeScores [i].text = cumulativeScoresList[i].ToString();
		}
			
		/*for (int i = 0; i < bowls.Count; i++) {
			if (i < 18 && bowls [i] == 10) {
				individualScores [i].text = "10";
				i++
			} else { 
				individualScores[i].text = bowls[i].ToStirng
			}
		}*/

		foreach (int score in bowls) {
			if (j < 18 && score == 10) {
				individualScores [j].text = "X";
				j += 2;
			} else if (score == 10) {
				individualScores [j].text = "X";
				j++;
			} else if ((j % 2 != 0) && (score + bowls[j - 1] == 10)){
				individualScores [j].text = "/";
				j++;
			} else {
				individualScores [j].text = score.ToString ();
				j++;
			}
		}

	}
}
