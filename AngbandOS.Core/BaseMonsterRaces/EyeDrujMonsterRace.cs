using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class EyeDrujMonsterRace : Base2MonsterRace
    {
        public override char Character => 's';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Eye druj";

        public override int ArmourClass => 90;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new Exp80AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Gaze, new Exp80AttackEffect(), 0, 0),
        };
        public override bool ColdBlood => true;
        public override string Description => "A bloodshot eyeball floating in the air, you'd be forgiven for assuming it harmless.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 1;
        public override int FreqSpell => 1;
        public override string FriendlyName => "Eye druj";
        public override int Hdice => 10;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 55;
        public override bool ManaBolt => true;
        public override int Mexp => 24000;
        public override bool NetherBall => true;
        public override bool NetherBolt => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 20;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Eye     ";
        public override string SplitName3 => "    druj    ";
        public override bool SummonUndead => true;
        public override bool Undead => true;
    }
}
