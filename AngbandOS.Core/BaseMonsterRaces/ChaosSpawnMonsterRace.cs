using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ChaosSpawnMonsterRace : MonsterRace
    {
        public override char Character => 'e';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos spawn";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new ParalyzeAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Gaze, new UnBonusAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Gaze, new Exp40AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Gaze, new HurtAttackEffect(), 10, 6)
        };
        public override bool BashDoor => true;
        public override string Description => "It has two eyestalks and a large central eye. Its gaze can kill.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Chaos spawn";
        public override int Hdice => 20;
        public override int Hside => 18;
        public override int LevelFound => 36;
        public override int Mexp => 600;
        public override int NoticeRange => 20;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Chaos    ";
        public override string SplitName3 => "   spawn    ";
    }
}
