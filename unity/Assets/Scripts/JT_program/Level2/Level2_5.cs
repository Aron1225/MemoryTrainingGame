using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_5 : Level2
{
	/*field*/

	public CameraCircularMovement MainCamera;

	/*methods*/

	//mono......................

	public override void OnAwake ()
	{
		base.OnAwake ();
		level_instance = this;
		CT2 = GetComponent<Level2_Controller> ();
		controller = CT2;
	}

	public override void OnStart ()
	{
		base.OnStart ();
		Parameter ();
	}

	public override void On_OnDestroy ()
	{
		base.On_OnDestroy ();
	}

	//function..................

	public override void Parameter ()
	{
		//{ Loop, random,iCoffeeCup}
		base.LevelParameter = new Level[][,] {
			new Level[,] { { new Level (20, 2, CoffeeCup.build (Model.OneCups_EightBall).camera_perspective (MainCamera, 10f)) } },
			new Level[,] { { new Level (20, 2, CoffeeCup.build (Model.OneCups_NineBall)) } },
			new Level[,] { { new Level (20, 3, CoffeeCup.build (Model.TwoCup_ThreeBall).cups_speed (10, 10)) } }, 
			new Level[,] { { new Level (20, 3, CoffeeCup.build (Model.TwoCup_FourBall).cups_speed (-10, -10)) } }, 
			new Level[,] { { new Level (25, 4, CoffeeCup.build (Model.ThreeCup_TwoBall).cups_speed (15, 15, 15)) } },
			new Level[,] { { new Level (25, 4, CoffeeCup.build (Model.ThreeCup_ThreeBall).cups_speed (-15, -15, -15)) } },
			new Level[,] { { new Level (30, 5, CoffeeCup.build (Model.ThreeCup_FourBall).cups_speed (15, 15, 15)) } },
			new Level[,] { { new Level (30, 5, CoffeeCup.build (Model.FourCup_TwoBall).cups_speed (-15, 30, -15, 30)) } },
			new Level[,] { { new Level (35, 6, CoffeeCup.build (Model.FourCup_ThreeBall).cups_speed (15, -30, 15, -30)) } },
			new Level[,] { { new Level (35, 6, CoffeeCup.build (Model.FourCup_FourBall).cups_speed (-15, 30, -15, 30)) } },
		};
	}

	//	//Overide
	//	public override IEnumerator LevelManagement ()
	//	{
	//		yield break;
	//	}
}
