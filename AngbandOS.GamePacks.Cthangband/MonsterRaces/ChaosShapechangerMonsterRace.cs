// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaosShapechangerMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ColdBoltMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.FireBoltMonsterSpell)
    };

    public override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 14;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ConfuseAttackEffect), 1, 3),
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override string Description => "A vaguely humanoid form constantly changing its appearance.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Chaos shapechanger";
    public override int Hdice => 20;
    public override int Hside => 9;
    public override int LevelFound => 11;
    public override int Mexp => 38;
    public override int NoticeRange => 10;
    public override int Rarity => 2;
    public override bool Shapechanger => true;
    public override int Sleep => 12;
    public override int Speed => 110;
    public override string? MultilineName => "Chaos\nshapechanger";
}
