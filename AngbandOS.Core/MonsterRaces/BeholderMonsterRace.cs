using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BeholderMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new AcidBoltMonsterSpell(),
            new BlindnessMonsterSpell(),
            new ColdBoltMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DrainManaMonsterSpell(),
            new FireBoltMonsterSpell(),
            new MindBlastMonsterSpell(),
            new ScareMonsterSpell(),
            new SlowMonsterSpell(),
            new DarknessMonsterSpell(),
            new ForgetMonsterSpell());
        public override char Character => 'e';
        public override Colour Colour => Colour.Green;
        public override string Name => "Beholder";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new Exp20AttackEffect(), 2, 4),
            new MonsterAttack(AttackType.Gaze, new ParalyzeAttackEffect(), 2, 4),
            new MonsterAttack(AttackType.Gaze, new LoseIntAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Gaze, new UnPowerAttackEffect(), 2, 6)
        };
        public override bool BashDoor => true;
        public override string Description => "A disembodied eye, surrounded by twelve smaller eyes on stalks.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Beholder";
        public override int Hdice => 16;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 38;
        public override int Mexp => 6000;
        public override int NoticeRange => 30;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Beholder  ";
    }
}
