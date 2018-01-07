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
        List<int> plays = new List<int>();
        plays.Add(10);
		Assert.AreEqual (endTurn, actionMaster.Bowl(plays));
	}

	[Test]
	public void T02Bowl8ReturnsTidy() {
        List<int> plays = new List<int>();
        plays.Add(8);
        Assert.AreEqual (tidy, actionMaster.Bowl(plays));
	}
[Test]
	public void T03Bowl28SpareReturnsEndTurn() {
        List<int> plays = new List<int>();
        int[] rolls = { 2, 8 };
        ActionMaster.Action action = new ActionMaster.Action();

        foreach (int roll in rolls)
        {
            plays.Add(roll);
            action = actionMaster.Bowl(plays);
        }

        Assert.AreEqual(endTurn, action);
    }

	[Test]
	public void T04SecondBowlReturnsEndTurn() {
        List<int> plays = new List<int>();
        int[] rolls = { 2, 5};
        ActionMaster.Action action = new ActionMaster.Action();
        
        foreach (int roll in rolls)
        {
           plays.Add(roll);
           action = actionMaster.Bowl(plays);
        }

        Assert.AreEqual(endTurn, action);
    }

	
	[Test]
	public void T05LastBowlReturnsEndGame() {
        List<int> plays = new List<int>();
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 1 ,1 ,1};
        ActionMaster.Action action = new ActionMaster.Action();

        foreach (int roll in rolls)
        {
            plays.Add(roll);
            action = actionMaster.Bowl(plays);
        }

        Assert.AreEqual(endGame, action);
	}

	[Test]
	public void T06NoStrikeOrSpareInLastSetEndsGame() {

        List<int> plays = new List<int>();
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 1};
        ActionMaster.Action action = new ActionMaster.Action();

        foreach (int roll in rolls)
        {
            plays.Add(roll);
            action = actionMaster.Bowl(plays);
        }

        Assert.AreEqual(endGame, action);
    }

    
	[Test]
	public void T07AfterFirstStrikeInLastSetResets() {
		List<int> plays = new List<int>();
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10};
		ActionMaster.Action action = new ActionMaster.Action();

		foreach (int roll in rolls)
		{
			plays.Add(roll);
			action = actionMaster.Bowl(plays);
		}

		Assert.AreEqual(reset, action);
	}
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
	} */

	[Test]
	public void T11AfterFirstBowlInLastSetReturnsTidy() {
		List<int> plays = new List<int>();
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5};
		ActionMaster.Action action = new ActionMaster.Action();

		foreach (int roll in rolls)
		{
			plays.Add(roll);
			action = actionMaster.Bowl(plays);
		}

		Assert.AreEqual(tidy, action);
	}

	[Test]
	public void T12CheckResetAtSpareInLastSet() {
		List<int> plays = new List<int>();
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,9};
		ActionMaster.Action action = new ActionMaster.Action();

		foreach (int roll in rolls)
		{
			plays.Add(roll);
			action = actionMaster.Bowl(plays);
		}

		Assert.AreEqual(reset, action);
	}


	[Test]
	public void T13YoutubeRollsEndInEndGame(){
		List<int> plays = new List<int>();
		int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9};
		ActionMaster.Action action = new ActionMaster.Action();

		foreach (int roll in rolls)
		{
			plays.Add(roll);
			action = actionMaster.Bowl(plays);
		}

		Assert.AreEqual(endGame, action);
	}

	[Test]
	public void T14TidyInBowl20AfterNoStrikeAndLastBowlAwarded(){
		List<int> plays = new List<int>();
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 , 1 ,10, 1};
		ActionMaster.Action action = new ActionMaster.Action();

		foreach (int roll in rolls)
		{
			plays.Add(roll);
			action = actionMaster.Bowl(plays);
		}

		Assert.AreEqual(tidy, action);
	}

	/*
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
	} */
}

