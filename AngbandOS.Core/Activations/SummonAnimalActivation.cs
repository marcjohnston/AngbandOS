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
    public override int RandomChance => 40;

    protected override bool OnActivate(Item item)
    {
        Game.SummonSpecificFriendly(Game.MapY, Game.MapX, Game.ExperienceLevel.Value, Game.SingletonRepository.MonsterFilters.Get(nameof(AnimalRangerMonsterFilter)), true);
        return true;
    }

    public override int RechargeTime() => 200 + Game.DieRoll(300);

    public override int Value => 10000;

    public override string Name => "Summon animal";

    public override string Frequency => "200+d300";
}
