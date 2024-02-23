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
    private SummonAnimalActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 40;

    public override bool Activate()
    {
        SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(AnimalRangerMonsterFilter)), true);
        return true;
    }

    public override int RechargeTime() => 200 + SaveGame.DieRoll(300);

    public override int Value => 10000;

    public override string Name => "Summon animal";

    public override string Description => $"{Name.ToLower()} every 200+d300 turns";
}
