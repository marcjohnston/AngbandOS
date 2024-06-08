// AngbandOS: 2022 Marc Johnston
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
internal class SummonAnimalActivation : Activation
{
    private SummonAnimalActivation(Game game) : base(game) { }
    
    protected override bool OnActivate(Item item)
    {
        Game.SummonSpecificFriendly(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<MonsterFilter>(nameof(AnimalRangerMonsterFilter)), true);
        return true;
    }

    protected override string RechargeTimeRollExpression => "1d300+200";

    public override int Value => 10000;

    public override string Name => "Summon animal";

}
