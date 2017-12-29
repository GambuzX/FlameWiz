using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

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
	public void T06IfAfterLastBowlEndsGame() {
		actionMaster.bowl = 27;
		Assert.AreEqual (endGame, actionMaster.Bowl(10));
	}

	[Test]
	public void T07NoStrikeOrSpareInLastSetEndsGame() {
		actionMaster.bowl = 19;
		actionMaster.Bowl (2);
		Assert.AreEqual (endGame, actionMaster.Bowl(7));
	}

	[Test]
	public void T08AfterFirstStrikeInLastSetReturnsEndTurn() {
		actionMaster.bowl = 19;
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T09AfterFirstStrikeInLastSetGoesToBowl20() {
		actionMaster.bowl = 19;
		actionMaster.Bowl (10);
		Assert.AreEqual (20, actionMaster.bowl);
	}

	[Test]
	public void T10AfterSecondStrikeInLastSetGoesToBowl21() {
		actionMaster.bowl = 19;
		actionMaster.Bowl (10);
		actionMaster.Bowl (10);
		Assert.AreEqual (21, actionMaster.bowl);
	}

	[Test]
	public void T11AfterSpareInLastSetGoesToBowl21() {
		actionMaster.bowl = 19;
		actionMaster.Bowl (2);
		actionMaster.Bowl (8);
		Assert.AreEqual (21, actionMaster.bowl);
	}

	[Test]
	public void T12AfterFirstBowlInLastSetReturnsTidy() {
		actionMaster.bowl = 19;
		Assert.AreEqual (tidy, actionMaster.Bowl(2));
	}

}

