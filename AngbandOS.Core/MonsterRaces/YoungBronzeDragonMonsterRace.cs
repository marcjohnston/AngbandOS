using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class YoungBronzeDragonMonsterRace : MonsterRace
    {
        protected YoungBronzeDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheConfusionMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'd';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Young bronze dragon";

        public override int ArmourClass => 63;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 4),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 4),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "It has a form that legends are made of. Its still-tender scales are a rich bronze hue, and its shape masks its true form.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Young bronze dragon";
        public override int Hdice => 27;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 29;
        public override int Mexp => 310;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 150;
        public override int Speed => 110;
        public override string SplitName1 => "   Young    ";
        public override string SplitName2 => "   bronze   ";
        public override string SplitName3 => "   dragon   ";
    }
}
