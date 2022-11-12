using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ChaosShapechangerMonsterRace : MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos shapechanger";

        public override int ArmourClass => 14;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Hit, new ConfuseAttackEffect(), 1, 3),
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool ColdBolt => true;
        public override bool Confuse => true;
        public override string Description => "A vaguely humanoid form constantly changing its appearance.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Chaos shapechanger";
        public override int Hdice => 20;
        public override int Hside => 9;
        public override int LevelFound => 11;
        public override int Mexp => 38;
        public override int NoticeRange => 10;
        public override int Rarity => 2;
        public override bool Shapechanger => true;
        public override int Sleep => 12;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Chaos    ";
        public override string SplitName3 => "shapechanger";
    }
}
