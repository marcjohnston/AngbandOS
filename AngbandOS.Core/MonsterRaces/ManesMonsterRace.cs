using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ManesMonsterRace : MonsterRace
    {
        protected ManesMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'u';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Manes";

        public override int ArmourClass => 32;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "It is a minor but aggressive demon.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Manes";
        public override bool Friends => true;
        public override int Hdice => 8;
        public override int Hside => 8;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override int LevelFound => 7;
        public override int Mexp => 16;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Manes    ";
    }
}
