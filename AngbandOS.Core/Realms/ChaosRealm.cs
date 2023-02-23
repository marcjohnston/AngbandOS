namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class ChaosRealm : BaseRealm
    {
        private ChaosRealm(SaveGame savedGame) : base(savedGame) { }

        public override string[] Info => new string[] {
            "The Chaos realm is the most destructive realm. It focuses",
            "on combat spells. It is a very good choice for anyone who",
            "wants to be able to damage their foes directly, but is ",
            "somewhat lacking in non-combat spells."
        };

        public override string Name => "Chaos";
        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.ChaosBook;

        protected override Spell[] GetGenerateSpellList()
        {
            List<Spell> spellList = new List<Spell>();

            // Sign of Chaos
            spellList.Add(new ChaosSpellMagicMissile());
            spellList.Add(new ChaosSpellTrapAndDoorDestruction());
            spellList.Add(new ChaosSpellFlashOfLight());
            spellList.Add(new ChaosSpellTouchOfConfusion());
            spellList.Add(new ChaosSpellManaBurst());
            spellList.Add(new ChaosSpellFireBolt());
            spellList.Add(new ChaosSpellFistOfForce());
            spellList.Add(new ChaosSpellTeleportSelf());
            // Chaos Mastery
            spellList.Add(new ChaosSpellWonder());
            spellList.Add(new ChaosSpellChaosBolt());
            spellList.Add(new ChaosSpellSonicBoom());
            spellList.Add(new ChaosSpellDoomBolt());
            spellList.Add(new ChaosSpellFireBall());
            spellList.Add(new ChaosSpellTeleportOther());
            spellList.Add(new ChaosSpellWordOfDestruction());
            spellList.Add(new ChaosSpellInvokeChaos());
            // G'harne Fragments
            spellList.Add(new ChaosSpellPolymorphOther());
            spellList.Add(new ChaosSpellChainLightning());
            spellList.Add(new ChaosSpellArcaneBinding());
            spellList.Add(new ChaosSpellDisintegrate());
            spellList.Add(new ChaosSpellAlterReality());
            spellList.Add(new ChaosSpellPolymorphSelf());
            spellList.Add(new ChaosSpellChaosBranding());
            spellList.Add(new ChaosSpellSummonDemon());
            // Book of Azathoth
            spellList.Add(new ChaosSpellGravityBeam());
            spellList.Add(new ChaosSpellMeteorSwarm());
            spellList.Add(new ChaosSpellFlameStrike());
            spellList.Add(new ChaosSpellCallChaos());
            spellList.Add(new ChaosSpellShardBall());
            spellList.Add(new ChaosSpellManaStorm());
            spellList.Add(new ChaosSpellBreatheChaos());
            spellList.Add(new ChaosSpellCallTheVoid());

            return spellList.ToArray();
        }
    }
}
