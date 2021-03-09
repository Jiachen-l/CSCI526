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

}
