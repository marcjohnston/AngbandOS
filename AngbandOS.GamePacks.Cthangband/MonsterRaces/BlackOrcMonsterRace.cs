// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlackOrcMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.Arrow1D6MonsterSpell)
    };

    public override string SymbolName => nameof(LowerOSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 36;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 4),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "He is a large orc with powerful arms and deep black skin.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Black orc";
    public override bool Friends => true;
    public override int Hdice => 12;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override int LevelFound => 13;
    public override bool Male => true;
    public override int Mexp => 45;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Black\norc";
}
