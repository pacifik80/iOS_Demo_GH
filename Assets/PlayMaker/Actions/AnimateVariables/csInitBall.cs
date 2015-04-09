using UnityEngine;
using HutongGames.PlayMaker;

[ActionCategory(ActionCategory.AnimateVariables)]
public class csInitBall : FsmStateAction
{

	// Code that runs on entering the state.
	public override void OnEnter()
	{
		Finish();
	}


}
