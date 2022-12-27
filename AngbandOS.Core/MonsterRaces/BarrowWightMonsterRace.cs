using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BarrowWightMonsterRace : MonsterRace
    {
        protected BarrowWightMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new CauseSeriousWoundsMonsterSpell(),
            new HoldMonsterSpell(),
            new ScareMonsterSpell(),
            new DarknessMonsterSpell());
        public override char Character => 'W';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Barrow wight";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 8),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 8),
            new MonsterAttack(new TouchAttackType(), new Exp40AttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a ghostly nightmare of a entity.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Barrow wight";
        public override bool Friends => true;
        public override int Hdice => 15;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 33;
        public override int Mexp => 375;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Barrow   ";
        public override string SplitName3 => "   wight    ";
        public override bool Undead => true;
    }
}
