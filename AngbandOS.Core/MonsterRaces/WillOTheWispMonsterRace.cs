using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class WillOTheWispMonsterRace : MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.BrightTurquoise;
        public override string Name => "Will o' the wisp";

        public override int ArmourClass => 150;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 9),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 9),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 9),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 9)
        };
        public override bool Blink => true;
        public override bool CauseSeriousWounds => true;
        public override bool Confuse => true;
        public override string Description => "A strange ball of glowing light. It disappears and reappears and seems to draw you to it. You seem somehow compelled to stand still and watch its strange dancing motion.";
        public override bool EmptyMind => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Will o' the wisp";
        public override int Hdice => 20;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 37;
        public override int Mexp => 500;
        public override bool Nonliving => true;
        public override int NoticeRange => 30;
        public override bool PassWall => true;
        public override bool Powerful => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override int Sleep => 0;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "    Will    ";
        public override string SplitName2 => "   o' the   ";
        public override string SplitName3 => "    wisp    ";
        public override bool TeleportSelf => true;
    }
}