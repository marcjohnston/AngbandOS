using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class DeathQuasitMonsterRace : MonsterRace
    {
        protected DeathQuasitMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new CauseCriticalWoundsMonsterSpell(),
            new ConfuseMonsterSpell(),
            new ScareMonsterSpell(),
            new ForgetMonsterSpell(),
            new SummonDemonMonsterSpell());
        public override char Character => 'u';
        public override string Name => "Death quasit";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new LoseDexAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3),
        };
        public override bool Demon => true;
        public override string Description => "It is a demon of small stature, but its armoured frame moves with lightning speed and its powers make it a tornado of death and destruction.";
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Death quasit";
        public override int Hdice => 44;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 40;
        public override int Mexp => 1000;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Death    ";
        public override string SplitName3 => "   quasit   ";
    }
}
