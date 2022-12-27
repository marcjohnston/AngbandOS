using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class WhiteJellyMonsterRace : MonsterRace
    {
        protected WhiteJellyMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'j';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "White jelly";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new TouchAttackType(), new PoisonAttackEffect(), 1, 2),
        };
        public override string Description => "Its a large pile of white flesh.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "White jelly";
        public override int Hdice => 8;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 2;
        public override int Mexp => 10;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 1;
        public override int Sleep => 99;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   White    ";
        public override string SplitName3 => "   jelly    ";
        public override bool Stupid => true;
    }
}
