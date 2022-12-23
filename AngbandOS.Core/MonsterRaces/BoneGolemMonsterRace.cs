using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BoneGolemMonsterRace : MonsterRace
    {
        protected BoneGolemMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new CauseCriticalWoundsMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DrainManaMonsterSpell(),
            new HoldMonsterSpell(),
            new ManaBallMonsterSpell(),
            new NetherBallMonsterSpell(),
            new SummonUndeadMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => 'g';
        public override Colour Colour => Colour.BrightBeige;
        public override string Name => "Bone golem";

        public override int ArmourClass => 170;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 6, 8),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 6, 8),
            new MonsterAttack(AttackType.Hit, new LoseStrAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Hit, new LoseStrAttackEffect(), 4, 6)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A skeletal form, black as night, constructed from the bones of its previous victims and inhabited by the soul of a lich of great power.";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Bone golem";
        public override int Hdice => 35;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillWall => true;
        public override int LevelFound => 71;
        public override int Mexp => 23000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override int Sleep => 50;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Bone    ";
        public override string SplitName3 => "   golem    ";
        public override bool Undead => true;
    }
}
