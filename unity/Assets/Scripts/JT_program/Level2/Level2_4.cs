using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_4 : Level2
{
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
			new Level[,] { { new Level (20, 2, CoffeeCup.build (Model.TwoCup_TwoBall).cylinder_speed (4).cups_speed (10, 10)) } }, 
			new Level[,] { { new Level (20, 2, CoffeeCup.build (Model.TwoCup_TwoBall).cylinder_speed (-4).cups_speed (-10, 20)) } },
			new Level[,] { { new Level (20, 2, CoffeeCup.build (Model.TwoCup_ThreeBall).cylinder_speed (4).cups_speed (10, 10)) } }, 
			new Level[,] { { new Level (20, 2, CoffeeCup.build (Model.TwoCup_FourBall).cylinder_speed (-4).cups_speed (-10, -10)) } }, 
			new Level[,] { { new Level (25, 3, CoffeeCup.build (Model.ThreeCup_TwoBall).cylinder_speed (6).cups_speed (15, 15, 15)) } },
			new Level[,] { { new Level (25, 3, CoffeeCup.build (Model.ThreeCup_ThreeBall).cylinder_speed (-6).cups_speed (-15, -15, -15)) } },
			new Level[,] { { new Level (30, 4, CoffeeCup.build (Model.ThreeCup_FourBall).cylinder_speed (8).cups_speed (15, 15, 15)) } },
			new Level[,] { { new Level (30, 4, CoffeeCup.build (Model.FourCup_TwoBall).cylinder_speed (-8).cups_speed (-15, 30, -15, 30)) } },
			new Level[,] { { new Level (35, 5, CoffeeCup.build (Model.FourCup_ThreeBall).cylinder_speed (10).cups_speed (15, -30, 15, -30)) } },
			new Level[,] { { new Level (35, 5, CoffeeCup.build (Model.FourCup_FourBall).cylinder_speed (-10).cups_speed (-15, 30, -15, 30)) } },
		};
	}

	//	//Overide
	//	public override IEnumerator LevelManagement ()
	//	{
	//		yield break;
	//	}
}
