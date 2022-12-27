using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NightbladeMonsterRace : MonsterRace
    {
        protected NightbladeMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'h';
        public override Colour Colour => Colour.Black;
        public override string Name => "Nightblade";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new PoisonAttackEffect(), 3, 4),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 4),
            new MonsterAttack(new HitAttackType(), new LoseConAttackEffect(), 3, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "A dark elf so stealthy that he is almost impossible to see.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Nightblade";
        public override bool Friends => true;
        public override int Hdice => 19;
        public override int Hside => 13;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 36;
        public override bool Male => true;
        public override int Mexp => 315;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Nightblade ";
    }
}
