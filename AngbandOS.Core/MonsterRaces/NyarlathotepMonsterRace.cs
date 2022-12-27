using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NyarlathotepMonsterRace : MonsterRace
    {
        protected NyarlathotepMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ChaosBallMonsterSpell(),
            new BlindnessMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new FireBallMonsterSpell(),
            new IceBoltMonsterSpell(),
            new ManaBallMonsterSpell(),
            new ManaBoltMonsterSpell(),
            new NetherBallMonsterSpell(),
            new PlasmaBoltMonsterSpell(),
            new ScareMonsterSpell(),
            new WaterBallMonsterSpell(),
            new DarknessMonsterSpell(),
            new DreadCurseMonsterSpell(),
            new ForgetMonsterSpell(),
            new SummonCthuloidMonsterSpell(),
            new SummonDemonMonsterSpell(),
            new SummonGreatOldOneMonsterSpell(),
            new SummonHiDragonMonsterSpell(),
            new SummonHiUndeadMonsterSpell(),
            new SummonMonstersMonsterSpell(),
            new SummonReaverMonsterSpell(),
            new TeleportAwayMonsterSpell(),
            new TeleportLevelMonsterSpell(),
            new TeleportToMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'X';
        public override Colour Colour => Colour.Red;
        public override string Name => "Nyarlathotep";

        public override int ArmourClass => 165;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new UnBonusAttackEffect(), 12, 12),
            new MonsterAttack(new HitAttackType(), new UnPowerAttackEffect(), 12, 12),
            new MonsterAttack(new HitAttackType(), new ConfuseAttackEffect(), 10, 2),
            new MonsterAttack(new HitAttackType(), new BlindAttackEffect(), 3, 2)
        };
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override string Description => "The Crawling Chaos in it's most monstrous form. It will do all in its power to keep you away from its master, Azathoth.";
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Nyarlathotep";
        public override bool GreatOldOne => true;
        public override int Hdice => 99;
        public override int Hside => 111;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 99;
        public override bool LightningAura => true;
        public override int Mexp => 65000;
        public override bool MoveBody => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 1;
        public override bool Reflecting => true;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override bool Smart => true;
        public override int Speed => 145;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Nyarlathotep";
        public override bool Unique => true;
    }
}
