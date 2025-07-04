// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlueDragonBatMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.LightningBreatheBallMonsterSpell)
    };

    public override string SymbolName => nameof(LowerBSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override bool Animal => true;
    public override int ArmorClass => 26;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.ElectricityAttackEffect), 1, 3),
        (nameof(StingAttack), nameof(AttackEffectsEnum.ElectricityAttackEffect), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a glowing blue bat with a sharp tail.";
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Blue dragon bat";
    public override int Hdice => 4;
    public override int Hside => 4;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 21;
    public override int Mexp => 54;
    public override int NoticeRange => 12;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 130;
    public override string? MultilineName => "Blue\ndragon\nbat";
}
