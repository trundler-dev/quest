﻿using Quest.Player;

namespace Quest.Systems.Items;

public partial class Carriable : BaseCarriable
{
	public virtual string ModelPath => "";
	public virtual HoldType HoldType => HoldType.None;
	public virtual HoldHandedness HoldHandedness => HoldHandedness.TwoHands;

	public override void Spawn()
	{
		base.Spawn();

		if ( !string.IsNullOrEmpty( ModelPath ) )
		{
			SetModel( ModelPath );
		}
	}

	public override void ActiveStart( Entity ent )
	{
		EnableDrawing = true;

		if ( ent is QuestPlayer player )
		{
			var animator = player.Animator;
			if ( animator != null )
			{
				SimulateAnimator( animator );
			}
		}
	}

	public override void SimulateAnimator( PawnAnimator anim )
	{
		base.SimulateAnimator( anim );

		anim.SetAnimParameter( "holdtype", (int)HoldType );
		anim.SetAnimParameter( "holdtype_handedness", (int)HoldHandedness );
	}
}
