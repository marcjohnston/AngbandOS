﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Summon a demon, with a 1-in-3 chance of it being hostile.
/// </summary>
[Serializable]
internal class SummonDemonActivation : Activation
{
    private SummonDemonActivation(Game game) : base(game) { }
    public override int RandomChance => 5;

    protected override bool OnActivate(Item item)
    {
        if (Game.DieRoll(3) == 1)
        {
            if (Game.SummonSpecific(Game.MapY.Value, Game.MapX.Value, (int)(Game.ExperienceLevel.Value * 1.5), Game.SingletonRepository.MonsterFilters.Get(nameof(DemonMonsterFilter))))
            {
                Game.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                Game.MsgPrint("'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'");
            }
        }
        else
        {
            if (Game.SummonSpecificFriendly(Game.MapY.Value, Game.MapX.Value, (int)(Game.ExperienceLevel.Value * 1.5), Game.SingletonRepository.MonsterFilters.Get(nameof(DemonMonsterFilter)), Game.ExperienceLevel.Value == 50))
            {
                Game.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                Game.MsgPrint("'What is thy bidding... Master?'");
            }
        }
        return true;
    }

    public override int RechargeTime() => 666 + Game.DieRoll(333);

    public override int Value => 20000;

    public override string Name => "Summon demon";

    public override string Frequency => "666+d333";
}