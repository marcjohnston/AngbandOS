using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FlyingPolypMonsterRace : MonsterRace
    {
        protected FlyingPolypMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ConfuseMonsterSpell(),
            new ManaBoltMonsterSpell(),
            new PlasmaBoltMonsterSpell(),
            new HasteMonsterSpell(),
            new HealMonsterSpell(),
            new SummonMonstersMonsterSpell(),
            new TeleportAwayMonsterSpell());
        public override char Character => 'A';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "Flying polyp";

        public override int ArmourClass => 68;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 4, 6),
        };
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override string Description => "'A horrible elder race of half polypous, utterly alien entities... Suggestions of monstrous plasticity and... lapses of visibility.' H.P.Lovecraft - 'The Shadow Out of Time'";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Flying polyp";
        public override int Hdice => 50;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 38;
        public override int Mexp => 1800;
        public override bool MoveBody => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 6;
        public override bool Reflecting => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 255;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Flying   ";
        public override string SplitName3 => "   polyp    ";
        public override bool TakeItem => true;
        public override bool WeirdMind => true;
    }
}
