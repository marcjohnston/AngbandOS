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
    public int ArmorClassBonus;
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
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(BanishActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(BerserkActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(BlinkActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(BrFireActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ColdTouchActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(DazzleActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(DetCurseActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(EarthquakeActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(EatMagicActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(EatRockActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(GrowMoldActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(HypnGazeActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(IllumineActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(LaserEyeActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(LauncherActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(MidasTchActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(MindBlstActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(PanicHitActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(PolymorphActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(RadiationActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(RecallActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ResistActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ShriekActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(SmellMetActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(SmellMonActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(SpitAcidActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(SterilityActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(SwapPosActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(TelekinesActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(VampirismActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(VteleportActiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(WeighMagActiveMutation)));
        // Passive Mutations
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(AlbinoPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ArthritisPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(BlankFacPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ElecToucPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(EspPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(FearlessPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(FireBodyPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(FleshRotPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(HyperIntPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(HyperStrPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(IllNormPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(InfravisPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(IronSkinPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(LimberPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(MagicResPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(MoronicPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(MotionPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(PunyPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(RegenPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ResilientPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ResTimePassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ScalesPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ShortLegPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(SillyVoiPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(SusStatsPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(VulnElemPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(WartSkinPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(WingsPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(XtraEyesPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(XtraFatPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(XtraLegsPassiveMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(XtraNoisPassiveMutation)));
        // Random Mutations
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(AlcoholRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(AttAnimalRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(AttDemonRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(AttDragonRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(BanishAllRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(BeakRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(BersRageRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ChaosGiftRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(CowardiceRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(DisarmRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(EatLightRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(FlatulentRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(HalluRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(HornsRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(HpToSpRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(InvulnRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(NauseaRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(NormalityRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(PolyWoundRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ProdManaRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(RawChaosRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(RteleportRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(ScorTailRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(SpeedFluxRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(SpToHpRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(TentaclesRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(TrunkRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(WalkShadRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(WarningRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(WastingRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(WeirdMindRandomMutation)));
        _notPossessed.Add(SaveGame.SingletonRepository.Mutations.Get(nameof(WraithRandomMutation)));
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
        int roll = SaveGame.DieRoll(total);
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
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
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
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
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
        int roll = SaveGame.DieRoll(total);
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
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        SaveGame.HandleStuff();
    }

    public void OnProcessWorld()
    {
        foreach (Mutation mutation in _possessed.ToArray()) // The list may be modified.  Use the ToArray to prevent an issue.
        {
            mutation.OnProcessWorld();
        }
    }
}