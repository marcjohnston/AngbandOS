using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class SpiritNagaMonsterRace : MonsterRace
    {
        public override char Character => 'n';
        public override Colour Colour => Colour.Turquoise;
        public override string Name => "Spirit naga";

        public override int ArmourClass => 75;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 8)
        };
        public override bool AttrClear => true;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Darkness => true;
        public override string Description => "A wraithly snake-like form with the torso of a beautiful woman, it is the most powerful of its kind.";
        public override bool Drop_2D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Spirit naga";
        public override int Hdice => 30;
        public override bool Heal => true;
        public override int Hside => 15;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 28;
        public override int Mexp => 60;
        public override bool MindBlast => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 120;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Spirit   ";
        public override string SplitName3 => "    naga    ";
    }
}
