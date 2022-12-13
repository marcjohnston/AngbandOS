using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class OgreMonsterRace : MonsterRace
    {
        public override char Character => 'O';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Ogre";

        public override int ArmourClass => 33;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A hideous, smallish giant that is often found near or with orcs.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Ogre";
        public override bool Friends => true;
        public override bool Giant => true;
        public override int Hdice => 13;
        public override int Hside => 9;
        public override int LevelFound => 13;
        public override int Mexp => 50;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Ogre    ";
    }
}
