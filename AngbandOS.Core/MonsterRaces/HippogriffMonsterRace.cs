using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class HippogriffMonsterRace : MonsterRace
    {
        protected HippogriffMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'H';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Hippogriff";

        public override bool Animal => true;
        public override int ArmourClass => 14;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 5),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "A strange hybrid of eagle, lion and horse. It looks weird.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hippogriff";
        public override int Hdice => 20;
        public override int Hside => 9;
        public override int LevelFound => 11;
        public override int Mexp => 30;
        public override int NoticeRange => 12;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Hippogriff ";
    }
}
