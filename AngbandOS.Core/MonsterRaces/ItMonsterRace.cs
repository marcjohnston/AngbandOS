using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ItMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ShriekMonsterSpell(),
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DrainManaMonsterSpell(),
            new ScareMonsterSpell(),
            new BlinkMonsterSpell(),
            new CreateTrapsMonsterSpell(),
            new DarknessMonsterSpell(),
            new ForgetMonsterSpell(),
            new HealMonsterSpell(),
            new SummonHydraMonsterSpell(),
            new SummonMonsterMonsterSpell(),
            new SummonUndeadMonsterSpell(),
            new TeleportAwayMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => '·';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "It";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new BlindAttackEffect(), 8, 8),
            new MonsterAttack(AttackType.Touch, new TerrifyAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Gaze, new Exp40AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new EatItemAttackEffect(), 0, 0)
        };
        public override bool AttrClear => true;
        public override bool CharClear => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "Nobody has ever seen It.";
        public override bool Drop_1D2 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "It";
        public override int Hdice => 77;
        public override int Hside => 9;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 24;
        public override int Mexp => 400;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override int Rarity => 3;
        public override bool Reflecting => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 25;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "     It     ";
        public override bool Unique => true;
    }
}
