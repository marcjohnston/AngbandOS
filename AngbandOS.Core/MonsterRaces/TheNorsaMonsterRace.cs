using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TheNorsaMonsterRace : MonsterRace
    {
        protected TheNorsaMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheAcidMonsterSpell(),
            new BreatheColdMonsterSpell(),
            new BreatheLightningMonsterSpell(),
            new BreatheFireMonsterSpell(),
            new BreathePoisonMonsterSpell(),
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new ScareMonsterSpell(),
            new SummonHiDragonMonsterSpell(),
            new SummonMonstersMonsterSpell());
        public override char Character => 'H';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "The Norsa";

        public override int ArmourClass => 125;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new CrushAttackType(), new AcidAttackEffect(), 8, 12),
            new MonsterAttack(new CrushAttackType(), new FireAttackEffect(), 8, 12),
            new MonsterAttack(new CrushAttackType(), new ElectricityAttackEffect(), 8, 12),
            new MonsterAttack(new CrushAttackType(), new PoisonAttackEffect(), 10, 14)
        };
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override string Description => "An elephantine horror with five trunks, each capable of breathing destructive blasts of elements.";
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "The Norsa";
        public override int Hdice => 100;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 70;
        public override bool LightningAura => true;
        public override int Mexp => 47500;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override int Sleep => 70;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    The     ";
        public override string SplitName3 => "   Norsa    ";
        public override bool Unique => true;
    }
}
