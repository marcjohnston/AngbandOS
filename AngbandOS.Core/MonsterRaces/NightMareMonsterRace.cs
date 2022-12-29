using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NightMareMonsterRace : MonsterRace
    {
        protected NightMareMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'q';
        public override Colour Colour => Colour.Black;
        public override string Name => "Night mare";

        public override int ArmourClass => 85;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new Exp80AttackEffect(), 2, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
            new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 6, 6)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A fearsome skeletal horse with glowing eyes, that watch you with little more than a hatred of all that lives.";
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Night mare";
        public override int Hdice => 15;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 39;
        public override int Mexp => 2900;
        public override int NoticeRange => 30;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Night    ";
        public override string SplitName3 => "    mare    ";
        public override bool Undead => true;
    }
}
