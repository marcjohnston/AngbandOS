using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class UndeadBeholderMonsterRace : Base2MonsterRace
    {
        public override char Character => 'e';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Undead beholder";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new Exp40AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Gaze, new ParalyzeAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Gaze, new LoseIntAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Gaze, new UnPowerAttackEffect(), 2, 6)
        };
        public override bool BashDoor => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "A disembodied eye, floating in the air. Black nether storms rage around its bloodshot pupil and light seems to bend as it sucks its power from the very air around it. Your soul chills as it drains your vitality for its evil enchantments.";
        public override bool DrainMana => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Undead beholder";
        public override int Hdice => 27;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 42;
        public override bool ManaBolt => true;
        public override int Mexp => 4000;
        public override bool MindBlast => true;
        public override int NoticeRange => 30;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Undead   ";
        public override string SplitName3 => "  beholder  ";
        public override bool SummonUndead => true;
        public override bool Undead => true;
    }
}
