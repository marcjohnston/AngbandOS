// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingMimicMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBoltMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.CauseSeriousWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ColdBoltMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.FireBoltMonsterSpell),
        nameof(MonsterSpellsEnum.LightningBoltMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetMonsterSpell),
        nameof(MonsterSpellsEnum.MonsterSummonMonsterSpell)
    };

    public override string SymbolName => nameof(EqualSignSymbol);
    public override ColorEnum Color => ColorEnum.Gold;
    
    public override int ArmorClass => 60;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 4),
        (nameof(HitAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 4),
        (nameof(HitAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 4),
        (nameof(HitAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 4)
    };
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "A strange creature that disguises itself as discarded objects to lure unsuspecting adventurers within reach of its venomous claws.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Ring mimic";
    public override int Hdice => 10;
    public override int Hside => 35;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 29;
    public override int Mexp => 200;
    public override bool NeverMove => true;
    public override int NoticeRange => 30;
    public override int Rarity => 4;
    public override int Sleep => 100;
    public override int Speed => 120;
    public override string? MultilineName => "Ring\nmimic";
}
