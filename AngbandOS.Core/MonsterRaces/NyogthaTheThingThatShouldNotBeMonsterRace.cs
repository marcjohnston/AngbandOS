using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NyogthaTheThingThatShouldNotBeMonsterRace : MonsterRace
    {
        protected NyogthaTheThingThatShouldNotBeMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheAcidMonsterSpell(),
            new BreatheDarkMonsterSpell(),
            new BreathePoisonMonsterSpell(),
            new BreatheRadiationMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new MindBlastMonsterSpell(),
            new HasteMonsterSpell(),
            new SummonCthuloidMonsterSpell(),
            new SummonHiUndeadMonsterSpell(),
            new SummonKinMonsterSpell(),
            new SummonUndeadMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'X';
        public override Colour Colour => Colour.Black;
        public override string Name => "Nyogtha, the Thing that Should not Be";

        public override int ArmourClass => 120;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new CrushAttackType(), new AcidAttackEffect(), 10, 6),
            new MonsterAttack(new CrushAttackType(), new ColdAttackEffect(), 10, 6),
            new MonsterAttack(new CrushAttackType(), new AcidAttackEffect(), 10, 6),
            new MonsterAttack(new CrushAttackType(), new HurtAttackEffect(), 16, 6)
        };
        public override bool BashDoor => true;
        public override string Description => "A nightmarish fetid, black irididescence oozing towards you.";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Nyogtha, the Thing that Should not Be";
        public override bool GreatOldOne => true;
        public override int Hdice => 55;
        public override int Hside => 99;
        public override bool HurtByLight => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int LevelFound => 56;
        public override int Mexp => 20000;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool Regenerate => true;
        public override bool ResistNether => true;
        public override bool ResistPlasma => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Nyogtha   ";
        public override bool Unique => true;
    }
}
