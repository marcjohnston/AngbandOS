using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FireGiantMonsterRace : MonsterRace
    {
        protected FireGiantMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'P';
        public override Colour Colour => Colour.Red;
        public override string Name => "Fire giant";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new FireAttackEffect(), 3, 7),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 7),
        };
        public override bool BashDoor => true;
        public override string Description => "A glowing fourteen foot tall giant. Flames drip from its red skin.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Fire giant";
        public override bool Giant => true;
        public override int Hdice => 20;
        public override int Hside => 8;
        public override bool ImmuneFire => true;
        public override int LevelFound => 16;
        public override bool Male => true;
        public override int Mexp => 54;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Fire    ";
        public override string SplitName3 => "   giant    ";
    }
}
