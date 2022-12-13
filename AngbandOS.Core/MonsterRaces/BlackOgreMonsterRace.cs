using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BlackOgreMonsterRace : MonsterRace
    {
        public override char Character => 'O';
        public override Colour Colour => Colour.Black;
        public override string Name => "Black ogre";

        public override int ArmourClass => 33;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A massive orc-like figure with black skin and powerful arms.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Black ogre";
        public override bool Friends => true;
        public override bool Giant => true;
        public override int Hdice => 20;
        public override int Hside => 9;
        public override int LevelFound => 15;
        public override int Mexp => 75;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Black    ";
        public override string SplitName3 => "    ogre    ";
    }
}
