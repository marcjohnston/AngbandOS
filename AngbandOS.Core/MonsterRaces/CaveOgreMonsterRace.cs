using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class CaveOgreMonsterRace : MonsterRace
    {
        public override char Character => 'O';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Cave ogre";

        public override int ArmourClass => 33;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A giant orc-like figure with an awesomely muscled frame.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Cave ogre";
        public override bool Friends => true;
        public override bool Giant => true;
        public override int Hdice => 30;
        public override int Hside => 9;
        public override int LevelFound => 26;
        public override int Mexp => 42;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Cave    ";
        public override string SplitName3 => "    ogre    ";
    }
}
