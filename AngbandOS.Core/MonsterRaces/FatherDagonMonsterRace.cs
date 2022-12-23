using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FatherDagonMonsterRace : MonsterRace
    {
        protected FatherDagonMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new ScareMonsterSpell(),
            new BlinkMonsterSpell(),
            new SummonCthuloidMonsterSpell(),
            new TeleportAwayMonsterSpell(),
            new TeleportLevelMonsterSpell(),
            new TeleportToMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'X';
        public override Colour Colour => Colour.BrightChartreuse;
        public override string Name => "Father Dagon";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new PoisonAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new PoisonAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 4),
        };
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override bool Demon => true;
        public override string Description => "A scale-skinned humanoid fish, the ruler of deep ones.";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Father Dagon";
        public override bool GreatOldOne => true;
        public override int Hdice => 40;
        public override int Hside => 12;
        public override bool ImmuneFire => true;
        public override bool Invisible => true;
        public override int LevelFound => 28;
        public override bool Male => true;
        public override int Mexp => 750;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 5;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Father   ";
        public override string SplitName3 => "   Dagon    ";
        public override bool Unique => true;
    }
}
