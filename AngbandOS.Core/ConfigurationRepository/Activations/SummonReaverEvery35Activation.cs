﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Summon animals.
/// </summary>
[Serializable]
internal class SummonReaverEvery500p1d500Activation : Activation
{
    private SummonReaverEvery500p1d500Activation(SaveGame saveGame) : base(saveGame) { }
    public override string? PreActivationMessage => "Your {0} flickers black for a moment...";
    public override int RandomChance => 20;

    protected override bool OnActivate(Item item)
    {
        SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(ReaverMonsterFilter)), true);
        return true;
    }

    public override int RechargeTime() => 500 + SaveGame.DieRoll(500);

    public override int Value => 10000;

    public override string Name => "Summon a black reaver";

    public override string Frequency => "500+d500";
}