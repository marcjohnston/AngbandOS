// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CaveLizardMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperRSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override bool Animal => true;
    public override int ArmorClass => 16;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 5),
    };
    public override string Description => "It is an armored lizard with a powerful bite.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Cave lizard";
    public override int Hdice => 3;
    public override int Hside => 6;
    public override int LevelFound => 4;
    public override int Mexp => 8;
    public override int NoticeRange => 8;
    public override int Rarity => 1;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string? MultilineName => "Cave\nlizard";
}
