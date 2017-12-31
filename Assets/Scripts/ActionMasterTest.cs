using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;

	private ActionMaster actionMaster;

	[SetUp] // Setups an actionMaster
	public void Setup(){
		actionMaster = new ActionMaster();
	}

	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn() {
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02Bowl8ReturnsTidy() {
		Assert.AreEqual (tidy, actionMaster.Bowl(8));
	}

	[Test]
	public void T03Bowl28SpareReturnsEndTurn() {
		actionMaster.Bowl (2);
		Assert.AreEqual (endTurn, actionMaster.Bowl(8));
	}

	[Test]
	public void T04SecondBowlReturnsEndTurn() {
		actionMaster.Bowl (2);
		actionMaster.Bowl (2);
		actionMaster.Bowl (2);
		Assert.AreEqual (endTurn, actionMaster.Bowl(5));
	}

	[Test]
	public void T05LastBowlReturnsEndGame() {
		actionMaster.bowl = 21;
		Assert.AreEqual (endGame, actionMaster.Bowl(7));
	}

	[Test]
	public void T06NoStrikeOrSpareInLastSetEndsGame() {
		actionMaster.bowl = 19;
		actionMaster.Bowl (2);
		Assert.AreEqual (endGame, actionMaster.Bowl(7));
	}

	[Test]
	public void T07AfterFirstStrikeInLastSetResets() {
		actionMaster.bowl = 19;
		Assert.AreEqual (reset, actionMaster.Bowl(10));
	}

	[Test]
	public void T08AfterFirstStrikeInLastSetGoesToBowl20() {
		actionMaster.bowl = 19;
		actionMaster.Bowl (10);
		Assert.AreEqual (20, actionMaster.bowl);
	}

	[Test]
	public void T09AfterSecondStrikeInLastSetGoesToBowl21() {
		actionMaster.bowl = 19;
		actionMaster.Bowl (10);
		actionMaster.Bowl (10);
		Assert.AreEqual (21, actionMaster.bowl);
	}

	[Test]
	public void T10AfterSpareInLastSetGoesToBowl21() {
		actionMaster.bowl = 19;
		actionMaster.Bowl (2);
		actionMaster.Bowl (8);
		Assert.AreEqual (21, actionMaster.bowl);
	}

	[Test]
	public void T11AfterFirstBowlInLastSetReturnsTidy() {
		actionMaster.bowl = 19;
		Assert.AreEqual (tidy, actionMaster.Bowl(2));
	}

	[Test]
	public void T12CheckResetAtSpareInLastSet() {
		int[] rolls =  {1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		actionMaster.Bowl(1);
		Assert.AreEqual(reset, actionMaster.Bowl(9));
	}

	[Test]
	public void T13YoutubeRollsEndInEndGame(){
		int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2};
		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (endGame, actionMaster.Bowl (9));
	}

	[Test]
	public void T14TidyInBowl20AfterNoStrikeAndLastBowlAwarded(){
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1};
		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		actionMaster.Bowl (10);
		Assert.AreEqual (tidy, actionMaster.Bowl (9));
	}

	[Test]
	public void T15BensBowl20Test(){
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1, 10};
		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}
		Assert.AreEqual (tidy, actionMaster.Bowl (0));
	}

	[Test]
	public void T16Bowling10PinsOnSecondBowlOfFrameAdvancesCorrectly(){
		actionMaster.Bowl (0);
		actionMaster.Bowl (10);
		Assert.AreEqual (3, actionMaster.bowl);
	}

	[Test]
	public void T17Dondi10thFrameTurkey () {
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
		foreach (int roll in rolls) {
			actionMaster.Bowl (roll);
		}

		Assert.AreEqual(reset, actionMaster.Bowl(10));
		Assert.AreEqual(reset, actionMaster.Bowl(10));
		Assert.AreEqual(endGame, actionMaster.Bowl(10));
	}
}

