using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ChaosGhostMonsterRace : MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos ghost";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Wail, new TerrifyAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new Exp40AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Claw, new LoseIntAttackEffect(), 1, 10),
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool Blindness => true;
        public override bool ColdBlood => true;
        public override string Description => "An almost life-like creature which is nothing more than a phantom created by the chaos.";
        public override bool DrainMana => true;
        public override bool Drop_2D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Chaos ghost";
        public override int Hdice => 14;
        public override bool Hold => true;
        public override int Hside => 20;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 33;
        public override int Mexp => 350;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Chaos    ";
        public override string SplitName3 => "   ghost    ";
        public override bool TakeItem => true;
        public override bool Undead => true;
    }
}
