// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PotionMimicMonsterRace : MonsterRace
{
    protected PotionMimicMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BlindnessMonsterSpell(),
        new CauseSeriousWoundsMonsterSpell(),
        new ColdBoltMonsterSpell(),
        new ConfuseMonsterSpell(),
        new ScareMonsterSpell());
    public override char Character => '!';
    public override string Name => "Potion mimic";

    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new PoisonAttackEffect(), 3, 4),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 3),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 3),
    };
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "A strange creature that disguises itself as discarded objects to lure unsuspecting adventurers within reach of its venomous claws.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Potion mimic";
    public override int Hdice => 10;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 18;
    public override int Mexp => 60;
    public override bool NeverMove => true;
    public override int NoticeRange => 25;
    public override int Rarity => 3;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Potion   ";
    public override string SplitName3 => "   mimic    ";
}
