using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class DriderMonsterRace : MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Drider";

        public override int ArmourClass => 30;
        public override bool Arrow3D6 => true;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override bool CauseLightWounds => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "A dark elven torso merged with the bloated form of a giant spider.";
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Drider";
        public override int Hdice => 10;
        public override int Hside => 13;
        public override bool ImmunePoison => true;
        public override int LevelFound => 13;
        public override bool MagicMissile => true;
        public override int Mexp => 55;
        public override int NoticeRange => 8;
        public override int Rarity => 2;
        public override int Sleep => 80;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Drider   ";
    }
}