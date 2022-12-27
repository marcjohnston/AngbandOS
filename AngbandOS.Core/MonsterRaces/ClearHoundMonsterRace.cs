using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ClearHoundMonsterRace : MonsterRace
    {
        protected ClearHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'Z';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "Clear hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 6),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 6),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 6),
        };
        public override bool AttrClear => true;
        public override bool BashDoor => true;
        public override string Description => "A completely translucent hound.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Clear hound";
        public override bool Friends => true;
        public override int Hdice => 10;
        public override int Hside => 6;
        public override bool Invisible => true;
        public override int LevelFound => 15;
        public override int Mexp => 50;
        public override int NoticeRange => 30;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Clear    ";
        public override string SplitName3 => "   hound    ";
    }
}
