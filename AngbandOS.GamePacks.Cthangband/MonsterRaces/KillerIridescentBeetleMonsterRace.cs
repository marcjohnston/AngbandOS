// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KillerIridescentBeetleMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperKSymbol);
    public override ColorEnum Color => ColorEnum.Pink;
    
    public override bool Animal => true;
    public override int ArmorClass => 60;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.ElectricityAttackEffect), 1, 12),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.ElectricityAttackEffect), 1, 12),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.ParalyzeAttackEffect), 0, 0),
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "It is a giant beetle, whose carapace shimmers with vibrant energies.";
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Killer iridescent beetle";
    public override int Hdice => 25;
    public override int Hside => 10;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 37;
    public override bool LightningAura => true;
    public override int Mexp => 850;
    public override int NoticeRange => 16;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Killer\niridescent\nbeetle";
    public override bool WeirdMind => true;
}
