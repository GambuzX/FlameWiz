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
		actionMaster.bowl = 2;
		Assert.AreEqual (endTurn, actionMaster.Bowl(5));
	}

	[Test]
	public void T05LastBowlReturnsEndTurn() {
		actionMaster.bowl = 23;
		Assert.AreEqual (endTurn, actionMaster.Bowl(7));
	}

	[Test]
	public void T06AfterLastBowlEndsGame() {
		actionMaster.bowl = 24;
		Assert.AreEqual (endGame, actionMaster.Bowl(8));
	}

}

