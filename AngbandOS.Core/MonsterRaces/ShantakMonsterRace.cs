using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ShantakMonsterRace : MonsterRace
    {
        public override char Character => 'B';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Shantak";

        public override bool Animal => true;
        public override int ArmourClass => 55;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
        };
        public override bool Cthuloid => true;
        public override string Description => "A scaly bird larger than an elephant, with a horse-like head.";
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Shantak";
        public override bool Haste => true;
        public override int Hdice => 25;
        public override int Hside => 20;
        public override bool ImmuneAcid => true;
        public override int LevelFound => 27;
        public override int Mexp => 280;
        public override int NoticeRange => 12;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Shantak   ";
    }
}