using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Level2_2 : Level2
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
			new Level[,] { { new Level (20, 2, CoffeeCup.build (Model.OneCup_TwoBall).cylinder_speed (10)) } }, 
			new Level[,] { { new Level (20, 2, CoffeeCup.build (Model.OneCups_ThreeBall).cylinder_speed (10)) } }, 
			new Level[,] { { new Level (25, 3, CoffeeCup.build (Model.OneCups_ThreeBall).cylinder_speed (10)) } },
			new Level[,] { { new Level (25, 3, CoffeeCup.build (Model.OneCups_FourBall).cylinder_speed (15)) } },
			new Level[,] { { new Level (30, 4, CoffeeCup.build (Model.OneCups_FourBall).cylinder_speed (15)) } },
			new Level[,] { { new Level (30, 4, CoffeeCup.build (Model.OneCups_FiveBall).cylinder_speed (15)) } },
			new Level[,] { { new Level (35, 5, CoffeeCup.build (Model.OneCups_FiveBall).cylinder_speed (15)) } },
			new Level[,] { { new Level (35, 5, CoffeeCup.build (Model.OneCups_SixBall).cylinder_speed (20)) } },
			new Level[,] { { new Level (40, 6, CoffeeCup.build (Model.OneCups_SixBall).cylinder_speed (20)) } },
			new Level[,] { { new Level (40, 6, CoffeeCup.build (Model.OneCups_SevenBall).cylinder_speed (20)) } },
		};
	}

	//	//Overide
	//	public override IEnumerator LevelManagement ()
	//	{
	//		yield break;
	//	}
}
