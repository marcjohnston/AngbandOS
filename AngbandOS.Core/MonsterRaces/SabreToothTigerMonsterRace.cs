using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SabreToothTigerMonsterRace : MonsterRace
    {
        protected SabreToothTigerMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'f';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Sabre-tooth tiger";

        public override bool Animal => true;
        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 10),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 10),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 10),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 10)
        };
        public override bool BashDoor => true;
        public override string Description => "A fierce and dangerous cat, its huge tusks and sharp claws would lacerate even the strongest armour.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Sabre-tooth tiger";
        public override int Hdice => 20;
        public override int Hside => 14;
        public override int LevelFound => 20;
        public override int Mexp => 120;
        public override int NoticeRange => 40;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "Sabre-tooth ";
        public override string SplitName3 => "   tiger    ";
    }
}
