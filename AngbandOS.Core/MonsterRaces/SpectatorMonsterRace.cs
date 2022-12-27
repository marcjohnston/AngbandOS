using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SpectatorMonsterRace : MonsterRace
    {
        protected SpectatorMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new CauseSeriousWoundsMonsterSpell(),
            new HoldMonsterSpell(),
            new SlowMonsterSpell(),
            new ForgetMonsterSpell());
        public override char Character => 'e';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Spectator";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new GazeAttackType(), new ParalyzeAttackEffect(), 1, 4),
            new MonsterAttack(new GazeAttackType(), new ConfuseAttackEffect(), 1, 4),
            new MonsterAttack(new GazeAttackType(), new UnBonusAttackEffect(), 0, 0),
        };
        public override string Description => "It has three small eyestalks and a large central eye.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Spectator";
        public override int Hdice => 10;
        public override int Hside => 13;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 32;
        public override int Mexp => 150;
        public override int NoticeRange => 30;
        public override int Rarity => 3;
        public override int Sleep => 5;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Spectator  ";
        public override bool Stupid => true;
    }
}
