// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class UrukMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.Arrow1D6MonsterSpell)
    };

    public override string SymbolName => nameof(LowerOSymbol);
    
    public override int ArmorClass => 50;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "He is a cunning orc of power, as tall as a man, and stronger. He fears little.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 12;
    public override int FreqSpell => 12;
    public override string FriendlyName => "Uruk";
    public override bool Friends => true;
    public override int Hdice => 8;
    public override int Hside => 10;
    public override bool ImmunePoison => true;
    public override int LevelFound => 18;
    public override bool Male => true;
    public override int Mexp => 68;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Uruk";
}
