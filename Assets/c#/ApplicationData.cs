using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationData
{
	//record the start time of this level
	static public float levelStartTime = Time.time;

	//record the time player used to pass this level
	static public float TimeToPassLevel;

	//record try time the player used to pass this level
	static public int levelTryTime = 0;

	//record the time the player fall into gap and loss
	static public int TimeFallIntoGap = 0;

	//record the time the player hit the obstacle
	static public int TimeHitObstacle = 0;

	//record the coins this player has
	static public int coins = 0;

	//record the coins this player get at this level
	static public int coinsGetThisLevel = 0;

	//record the hammers this player has
	static public int hammer_num = 0;

	//record the fans this player has
	static public int fan_num = 0;

	//record the heathiers this player has
	static public int healthier_num = 0;

	//record the last scene this player has
	static public int last_scene = 0;
	static public int playerlives = 5;

}
