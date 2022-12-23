using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SauronTheSorcererMonsterRace : MonsterRace
    {
        protected SauronTheSorcererMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DarkBallMonsterSpell(),
            new FireBallMonsterSpell(),
            new IceBoltMonsterSpell(),
            new ManaBallMonsterSpell(),
            new ManaBoltMonsterSpell(),
            new NetherBallMonsterSpell(),
            new PlasmaBoltMonsterSpell(),
            new ScareMonsterSpell(),
            new WaterBallMonsterSpell(),
            new DreadCurseMonsterSpell(),
            new ForgetMonsterSpell(),
            new SummonDemonMonsterSpell(),
            new SummonHiDragonMonsterSpell(),
            new SummonHiUndeadMonsterSpell(),
            new SummonMonstersMonsterSpell(),
            new TeleportLevelMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'p';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Sauron, the Sorcerer";

        public override int ArmourClass => 160;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 10, 12),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 10, 12),
            new MonsterAttack(AttackType.Touch, new UnPowerAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new UnPowerAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override string Description => "Mighty in spells and enchantments,he created the One Ring. His eyes glow with power and his gaze seeks to destroy your soul. He has many servants, and rarely fights without them.";
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Sauron, the Sorcerer";
        public override int Hdice => 105;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 98;
        public override bool Male => true;
        public override int Mexp => 50000;
        public override bool MoveBody => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Reflecting => true;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Sauron   ";
        public override bool Unique => true;
    }
}
