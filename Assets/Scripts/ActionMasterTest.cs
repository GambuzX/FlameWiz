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

	private List<int> pinFalls;

	[SetUp] // Setups an actionMaster
	public void Setup(){
		pinFalls = new List<int> ();
	}

	/*[Test]
	public void T00PassingTest() {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn() {
		pinFalls.Add (10);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T02Bowl8ReturnsTidy() {
		pinFalls.Add (8);
		Assert.AreEqual (tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T03Bowl28SpareReturnsEndTurn() {
		pinFalls.Add (2);
		pinFalls.Add (8);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T04SecondBowlReturnsEndTurn() {
		int[] rolls = { 1, 1, 1, 1 };

		foreach (int roll in rolls) {
			pinFalls.Add(roll);
		}

		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T05LastBowlReturnsEndGame() {

		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1, 1,1};

		foreach (int roll in rolls) {
			pinFalls.Add(roll);
		}

		Assert.AreEqual (endGame, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T07AfterFirstStrikeInLastSetResets() {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1, 10};

		foreach (int roll in rolls) {
			pinFalls.Add(roll);
		}

		Assert.AreEqual (reset, ActionMaster.NextAction(pinFalls));
	}*/

	/*
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
	}*/
    /*
	[Test]
	public void T11AfterFirstBowlInLastSetReturnsTidy() {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1, 1};

		foreach (int roll in rolls) {
			pinFalls.Add(roll);
		}

		Assert.AreEqual (tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T12CheckResetAtSpareInLastSet() {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1, 1,9};

		foreach (int roll in rolls) {
			pinFalls.Add(roll);
		}

		Assert.AreEqual (reset, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T13YoutubeRollsEndInEndGame(){
		int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9};

		foreach (int roll in rolls) {
			pinFalls.Add(roll);
		}

		Assert.AreEqual (endGame, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T14TidyInBowl20AfterNoStrikeAndLastBowlAwarded(){
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1, 10, 9};

		foreach (int roll in rolls) {
			pinFalls.Add(roll);
		}

		Assert.AreEqual (tidy, ActionMaster.NextAction(pinFalls));
	}


	[Test]
	public void T15BensBowl20Test(){
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1, 10,0};

		foreach (int roll in rolls) {
			pinFalls.Add(roll);
		}

		Assert.AreEqual (tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T16Bowling10PinsOnSecondBowlOfFrameAdvancesCorrectly(){
		int[] rolls = { 0, 10 };

		foreach (int roll in rolls) {
			pinFalls.Add(roll);
		}

		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T17Dondi10thFrameTurkey () {
		int[] rolls = {1,1 , 1,1 , 1,1 , 1,1, 1,1 , 1,1 , 1,1 , 1,1 , 1,1, 10};

		foreach (int roll in rolls) {
			pinFalls.Add(roll);
		}

		Assert.AreEqual (reset, ActionMaster.NextAction(pinFalls));

		pinFalls.Add (10);
		Assert.AreEqual (reset, ActionMaster.NextAction(pinFalls));

		pinFalls.Add (10);
		Assert.AreEqual (endGame, ActionMaster.NextAction(pinFalls));
	} */
}