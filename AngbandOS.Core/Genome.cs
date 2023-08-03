// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations;

[Serializable]
internal class Genome // TODO: This is just a container
{
    public readonly List<Mutation> NaturalAttacks = new List<Mutation>();
    public int ArmourClassBonus;
    public bool ChaosGift;
    public int CharismaBonus;
    public bool CharismaOverride;
    public int ConstitutionBonus;
    public int DexterityBonus;
    public bool ElecHit;
    public bool Esp;
    public bool FeatherFall;
    public bool FireHit;
    public bool FreeAction;
    public int InfravisionBonus;
    public int IntelligenceBonus;
    public bool MagicResistance;
    public bool Regen;
    public bool ResFear;
    public bool ResTime;
    public int SearchBonus;
    public int SpeedBonus;
    public int StealthBonus;
    public int StrengthBonus;
    public bool SuppressRegen;
    public bool SustainAll;
    public bool Vulnerable;
    public int WisdomBonus;
    private readonly List<Mutation> _notPossessed = new List<Mutation>();
    private readonly List<Mutation> _possessed = new List<Mutation>();
    private readonly SaveGame SaveGame;

    public Genome(SaveGame saveGame)
    {
        SaveGame = saveGame;
        _possessed.Clear();
        // Active Mutations
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<BanishActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<BerserkActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<BlinkActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<BrFireActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ColdTouchActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<DazzleActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<DetCurseActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<EarthquakeActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<EatMagicActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<EatRockActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<GrowMoldActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<HypnGazeActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<IllumineActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<LaserEyeActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<LauncherActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<MidasTchActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<MindBlstActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<PanicHitActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<PolymorphActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<RadiationActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<RecallActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ResistActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ShriekActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<SmellMetActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<SmellMonActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<SpitAcidActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<SterilityActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<SwapPosActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<TelekinesActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<VampirismActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<VteleportActiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<WeighMagActiveMutation>());
        // Passive Mutations
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<AlbinoPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ArthritisPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<BlankFacPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ElecToucPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<EspPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<FearlessPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<FireBodyPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<FleshRotPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<HyperIntPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<HyperStrPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<IllNormPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<InfravisPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<IronSkinPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<LimberPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<MagicResPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<MoronicPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<MotionPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<PunyPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<RegenPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ResilientPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ResTimePassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ScalesPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ShortLegPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<SillyVoiPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<SusStatsPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<VulnElemPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<WartSkinPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<WingsPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<XtraEyesPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<XtraFatPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<XtraLegsPassiveMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<XtraNoisPassiveMutation>());
        // Random Mutations
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<AlcoholRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<AttAnimalRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<AttDemonRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<AttDragonRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<BanishAllRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<BeakRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<BersRageRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ChaosGiftRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<CowardiceRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<DisarmRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<EatLightRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<FlatulentRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<HalluRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<HornsRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<HpToSpRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<InvulnRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<NauseaRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<NormalityRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<PolyWoundRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ProdManaRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<RawChaosRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<RteleportRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<ScorTailRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<SpeedFluxRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<SpToHpRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<TentaclesRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<TrunkRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<WalkShadRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<WarningRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<WastingRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<WeirdMindRandomMutation>());
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get<WraithRandomMutation>());
    }

    public bool HasMutations => _possessed.Count > 0;

    public List<Mutation> ActivatableMutations()
    {
        List<Mutation> list = new List<Mutation>();
        foreach (Mutation mutation in _possessed)
        {
            if (string.IsNullOrEmpty(mutation.ActivationSummary(SaveGame.ExperienceLevel)))
            {
                continue;
            }
            list.Add(mutation);
        }
        return list;
    }

    public void GainMutation()
    {
        if (_notPossessed.Count == 0)
        {
            return;
        }
        SaveGame.MsgPrint("You change...");
        int total = 0;
        foreach (Mutation mutation in _notPossessed)
        {
            total += mutation.Frequency;
        }
        int roll = SaveGame.Rng.DieRoll(total);
        for (int i = 0; i < _notPossessed.Count; i++)
        {
            roll -= _notPossessed[i].Frequency;
            if (roll > 0)
            {
                continue;
            }
            Mutation mutation = _notPossessed[i];
            _notPossessed.RemoveAt(i);
            if (_possessed.Count > 0 && mutation.Group != MutationGroup.None)
            {
                int j = 0;
                do
                {
                    if (_possessed[j].Group == mutation.Group)
                    {
                        Mutation other = _possessed[j];
                        _possessed.RemoveAt(j);
                        other.OnLose(this);
                        SaveGame.MsgPrint(other.LoseMessage);
                        _notPossessed.Add(other);
                    }
                    else
                    {
                        j++;
                    }
                } while (j < _possessed.Count);
            }
            _possessed.Add(mutation);
            mutation.OnGain(this);
            SaveGame.MsgPrint(mutation.GainMessage);
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.HandleStuff();
            return;
        }
        SaveGame.MsgPrint("Oops! Fell out of mutation list!");
    }

    public string[] GetMutationList()
    {
        if (_possessed.Count == 0)
        {
            return new string[0];
        }
        string[] list = new string[_possessed.Count];
        for (int i = 0; i < _possessed.Count; i++)
        {
            list[i] = _possessed[i].HaveMessage;
        }
        return list;
    }

    public void LoseAllMutations()
    {
        if (_possessed.Count == 0)
        {
            return;
        }
        SaveGame.MsgPrint("You change...");
        do
        {
            Mutation mutation = _possessed[0];
            _possessed.RemoveAt(0);
            mutation.OnLose(this);
            _notPossessed.Add(mutation);
            SaveGame.MsgPrint(mutation.LoseMessage);
        } while (_possessed.Count > 0);
        SaveGame.UpdateBonusesFlaggedAction.Set();
        SaveGame.HandleStuff();
    }

    public void LoseMutation()
    {
        if (_possessed.Count == 0)
        {
            return;
        }
        SaveGame.MsgPrint("You change...");
        int total = 0;
        foreach (Mutation mutation in _possessed)
        {
            total += mutation.Frequency;
        }
        int roll = SaveGame.Rng.DieRoll(total);
        for (int i = 0; i < _possessed.Count; i++)
        {
            roll -= _possessed[i].Frequency;
            if (roll > 0)
            {
                continue;
            }
            Mutation mutation = _possessed[i];
            _possessed.RemoveAt(i);
            mutation.OnLose(this);
            _notPossessed.Add(mutation);
            SaveGame.MsgPrint(mutation.LoseMessage);
            return;
        }
        SaveGame.MsgPrint("Oops! Fell out of mutation list!");
        SaveGame.UpdateBonusesFlaggedAction.Set();
        SaveGame.HandleStuff();
    }

    public void OnProcessWorld()
    {
        foreach (Mutation mutation in _possessed.ToArray()) // The list may be modified.  Use the ToArray to prevent an issue.
        {
            mutation.OnProcessWorld(SaveGame);
        }
    }
}