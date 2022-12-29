using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AncientRedDragonMonsterRace : MonsterRace
    {
        protected AncientRedDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheFireMonsterSpell(),
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'D';
        public override Colour Colour => Colour.Red;
        public override string Name => "Ancient red dragon";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 10),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 10),
            new MonsterAttack(new BiteAttackType(), new FireAttackEffect(), 5, 14),
        };
        public override bool BashDoor => true;
        public override string Description => "A huge draconic form. Wisps of smoke steam from its nostrils and the extreme heat surrounding it makes you gasp for breath.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Ancient red dragon";
        public override int Hdice => 10;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 40;
        public override int Mexp => 2750;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool Powerful => true;
        public override int Rarity => 1;
        public override int Sleep => 70;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "  Ancient   ";
        public override string SplitName2 => "    red     ";
        public override string SplitName3 => "   dragon   ";
    }
}
