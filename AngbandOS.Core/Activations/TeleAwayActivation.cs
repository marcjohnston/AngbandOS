﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Teleport away an opponent.
/// </summary>
[Serializable]
internal class TeleAwayActivation : DirectionalActivation
{
    private TeleAwayActivation(Game game) : base(game) { }
    public override int RandomChance => 85;

    public override int RechargeTime() => 200;

    protected override bool Activate(int direction)
    {
        Game.FireBeam(Game.SingletonRepository.Projectiles.Get(nameof(TeleportAwayAllProjectile)), direction, Game.ExperienceLevel.Value);
        return true;
    }

    public override int Value => 2000;

    public override string Name => "Teleport away";

    public override string Frequency => "200";
}