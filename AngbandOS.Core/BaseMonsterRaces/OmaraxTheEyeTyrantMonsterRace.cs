using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class OmaraxTheEyeTyrantMonsterRace : Base2MonsterRace
    {
        public override char Character => 'e';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Omarax the Eye Tyrant";

        public override bool AcidBolt => true;
        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new Exp40AttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Gaze, new ParalyzeAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Gaze, new UnPowerAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Gaze, new LoseIntAttackEffect(), 2, 6)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool ColdBolt => true;
        public override bool Confuse => true;
        public override bool DarkBall => true;
        public override bool Darkness => true;
        public override string Description => "A disembodied eye, floating in the air. His gaze seems to shred your soul and his spells crush your will. He is ancient, his history steeped in forgotten evils, his atrocities numerous and sickening.";
        public override bool DrainMana => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Omarax the Eye Tyrant";
        public override int Hdice => 65;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 73;
        public override bool Male => true;
        public override int Mexp => 16000;
        public override bool MindBlast => true;
        public override int NoticeRange => 30;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "   Omarax   ";
        public override string SplitName2 => "  the Eye   ";
        public override string SplitName3 => "   Tyrant   ";
        public override bool SummonKin => true;
        public override bool Unique => true;
    }
}
