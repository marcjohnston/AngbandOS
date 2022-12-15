using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class OgreMageMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ColdBallMonsterSpell(),
            new HoldMonsterSpell(),
            new CreateTrapsMonsterSpell(),
            new HealMonsterSpell(),
            new SummonMonsterMonsterSpell());
        public override char Character => 'O';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Ogre mage";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8)
        };
        public override bool BashDoor => true;
        public override string Description => "A hideous ogre wrapped in black sorcerous robes.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Ogre mage";
        public override bool Giant => true;
        public override int Hdice => 30;
        public override int Hside => 12;
        public override int LevelFound => 27;
        public override int Mexp => 300;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Ogre    ";
        public override string SplitName3 => "    mage    ";
    }
}
