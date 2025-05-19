// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LostSoulMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportSelfMonsterSpell)
    };

    public override string SymbolName => nameof(UpperGSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override int ArmorClass => 10;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 2),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.LoseWisAttackEffect), 0, 0),
    };
    public override bool ColdBlood => true;
    public override string Description => "It is almost insubstantial.";
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Lost soul";
    public override int Hdice => 2;
    public override int Hside => 8;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 7;
    public override int Mexp => 18;
    public override int NoticeRange => 12;
    public override bool PassWall => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Lost\nsoul";
    public override bool TakeItem => true;
    public override bool Undead => true;
}
