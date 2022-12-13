using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NazgulMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheNetherMonsterSpell(),
            new DrainManaMonsterSpell(),
            new HoldMonsterSpell(),
            new ScareMonsterSpell());
        public override char Character => 'W';
        public override Colour Colour => Colour.Black;
        public override string Name => "Nazgul";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new TerrifyAttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new TerrifyAttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Hit, new Exp80AttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Hit, new Exp80AttackEffect(), 4, 6)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A tall black cloaked Ringwraith, radiating an aura of fear.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Nazgul";
        public override int Hdice => 50;
        public override int Hside => 40;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 45;
        public override bool Male => true;
        public override int Mexp => 9500;
        public override bool MoveBody => true;
        public override int NoticeRange => 90;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistNether => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Nazgul   ";
        public override bool Undead => true;
    }
}
