// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShantakMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.HasteMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperBSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override bool Animal => true;
    public override int ArmorClass => 55;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
    };
    public override bool Cthuloid => true;
    public override string Description => "A scaly bird larger than an elephant, with a horse-like head.";
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Shantak";
    public override int Hdice => 25;
    public override int Hside => 20;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 27;
    public override int Mexp => 280;
    public override int NoticeRange => 12;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Shantak";
}
