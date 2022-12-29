using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class CantorasTheSkeletalLordMonsterRace : MonsterRace
    {
        protected CantorasTheSkeletalLordMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BrainSmashMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new IceBoltMonsterSpell(),
            new ManaBoltMonsterSpell(),
            new NetherBallMonsterSpell(),
            new ScareMonsterSpell(),
            new SlowMonsterSpell(),
            new WaterBallMonsterSpell(),
            new SummonHiUndeadMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => 's';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Cantoras, the Skeletal Lord";

        public override int ArmourClass => 120;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new GazeAttackType(), new Exp80AttackEffect(), 0, 0),
            new MonsterAttack(new GazeAttackType(), new Exp80AttackEffect(), 0, 0),
            new MonsterAttack(new TouchAttackType(), new PoisonAttackEffect(), 3, 5),
            new MonsterAttack(new TouchAttackType(), new PoisonAttackEffect(), 3, 5)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A legion of evil undead druj animating the skeleton of a once mighty sorcerer. His power is devastating and his speed unmatched in the underworld. Flee his wrath!";
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 1;
        public override int FreqSpell => 1;
        public override string FriendlyName => "Cantoras, the Skeletal Lord";
        public override int Hdice => 75;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 84;
        public override bool Male => true;
        public override int Mexp => 45000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 80;
        public override bool Smart => true;
        public override int Speed => 140;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Cantoras  ";
        public override bool Undead => true;
        public override bool Unique => true;
    }
}
