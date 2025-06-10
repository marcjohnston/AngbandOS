// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DriderMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.Arrow3D6MonsterSpell),
        nameof(MonsterSpellsEnum.CauseLightWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.MagicMissileMonsterSpell),
        nameof(MonsterSpellsEnum.DarknessMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperSSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 12),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 12),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A dark elven torso merged with the bloated form of a giant spider.";
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Drider";
    public override int Hdice => 10;
    public override int Hside => 13;
    public override bool ImmunePoison => true;
    public override int LevelFound => 13;
    public override int Mexp => 55;
    public override int NoticeRange => 8;
    public override int Rarity => 2;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string? MultilineName => "Drider";
}
