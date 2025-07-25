// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KingCobraMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperJSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(SpitAttack), nameof(AttackEffectsEnum.BlindAttackEffect), 1, 2),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a large snake with a hooded face.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "King cobra";
    public override int Hdice => 8;
    public override int Hside => 10;
    public override bool ImmunePoison => true;
    public override int LevelFound => 9;
    public override int Mexp => 28;
    public override int NoticeRange => 8;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 1;
    public override int Speed => 110;
    public override string? MultilineName => "King\ncobra";
}
