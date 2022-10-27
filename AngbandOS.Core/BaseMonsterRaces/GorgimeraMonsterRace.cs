using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GorgimeraMonsterRace : MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Gorgimera";

        public override int ArmourClass => 55;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new FireAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Gaze, new ParalyzeAttackEffect(), 2, 4),
            new MonsterAttack(AttackType.Butt, new HurtAttackEffect(), 1, 3)
        };
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override string Description => "It has 3 heads - gorgon, goat and dragon - all attached to a lion's body.";
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Gorgimera";
        public override int Hdice => 25;
        public override int Hside => 20;
        public override bool ImmuneFire => true;
        public override int LevelFound => 27;
        public override int Mexp => 200;
        public override int NoticeRange => 12;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Gorgimera  ";
    }
}
