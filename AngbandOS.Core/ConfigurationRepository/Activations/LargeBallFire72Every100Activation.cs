﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

[Serializable]
internal class LargeBallFire72Every100Activation : DirectionalActivation
{
    private LargeBallFire72Every100Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override string? PreActivationMessage => "Your {0} rages in fire...";

    public override int RechargeTime() => 100;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), direction, 72, 3);
        return true;
    }

    public override int Value => 6000;

    public override string Name => "Large fire ball (72)";

    public override string Frequency => "100";
}