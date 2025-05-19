// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GiantYellowScorpionMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperSSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override bool Animal => true;
    public override int ArmorClass => 38;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
        (nameof(StingAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 2, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a giant scorpion with a sharp stinger.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant yellow scorpion";
    public override int Hdice => 12;
    public override int Hside => 8;
    public override int LevelFound => 22;
    public override int Mexp => 60;
    public override int NoticeRange => 12;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Giant\nyellow\nscorpion";
    public override bool WeirdMind => true;
}
