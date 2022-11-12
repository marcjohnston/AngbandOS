using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BroddaTheEasterlingMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Brodda, the Easterling";

        public override int ArmourClass => 25;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12)
        };
        public override bool BashDoor => true;
        public override string Description => "A nasty piece of work, Brodda picks on defenseless women and children.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Brodda, the Easterling";
        public override int Hdice => 21;
        public override int Hside => 10;
        public override int LevelFound => 9;
        public override bool Male => true;
        public override int Mexp => 100;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Brodda   ";
        public override bool Unique => true;
    }
}
