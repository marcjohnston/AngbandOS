// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DarkYoungOfShubNiggurathMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.CauseSeriousWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.HealMonsterSpell),
        nameof(MonsterSpellsEnum.CthuloidSummonMonsterSpell)
    };

    public override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 75;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 6),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 6),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 1, 6),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 1, 6)
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "A black, ropy, slimy jelly tree-thing; an enormous writhing mass.";
    public override bool Drop_1D2 => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Dark young of Shub-Niggurath";
    public override int Hdice => 12;
    public override int Hside => 100;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 43;
    public override int Mexp => 5000;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 80;
    public override int Speed => 120;
    public override string? MultilineName => "Dark\nyoung of\nShub-Niggura";
}
