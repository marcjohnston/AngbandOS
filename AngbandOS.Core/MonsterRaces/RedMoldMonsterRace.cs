using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class RedMoldMonsterRace : MonsterRace
    {
        protected RedMoldMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'm';
        public override Colour Colour => Colour.Red;
        public override string Name => "Red mold";

        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new FireAttackEffect(), 4, 4),
        };
        public override string Description => "It is a strange red growth on the dungeon floor; it seems to burn with flame.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Red mold";
        public override int Hdice => 17;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 19;
        public override int Mexp => 64;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 1;
        public override int Sleep => 70;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Red     ";
        public override string SplitName3 => "    mold    ";
        public override bool Stupid => true;
    }
}
