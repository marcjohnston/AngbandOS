// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HellcatMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerFSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 5),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 5),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
    };
    public override string Description => "It is as large as a tiger, its yellow eyes are pupilless.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Hellcat";
    public override bool Friends => true;
    public override int Hdice => 9;
    public override int Hside => 8;
    public override bool ImmuneFire => true;
    public override int LevelFound => 12;
    public override int Mexp => 40;
    public override int NoticeRange => 20;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string? MultilineName => "Hellcat";
    public override bool WeirdMind => true;
}
