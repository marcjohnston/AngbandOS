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
        _notPossessed.Add(new BanishActiveMutation());
        _notPossessed.Add(new BerserkActiveMutation());
        _notPossessed.Add(new BlinkActiveMutation());
        _notPossessed.Add(new BrFireActiveMutation());
        _notPossessed.Add(new ColdTouchActiveMutation());
        _notPossessed.Add(new DazzleActiveMutation());
        _notPossessed.Add(new DetCurseActiveMutation());
        _notPossessed.Add(new EarthquakeActiveMutation());
        _notPossessed.Add(new EatMagicActiveMutation());
        _notPossessed.Add(new EatRockActiveMutation());
        _notPossessed.Add(new GrowMoldActiveMutation());
        _notPossessed.Add(new HypnGazeActiveMutation());
        _notPossessed.Add(new IllumineActiveMutation());
        _notPossessed.Add(new LaserEyeActiveMutation());
        _notPossessed.Add(new LauncherActiveMutation());
        _notPossessed.Add(new MidasTchActiveMutation());
        _notPossessed.Add(new MindBlstActiveMutation());
        _notPossessed.Add(new PanicHitActiveMutation());
        _notPossessed.Add(new PolymorphActiveMutation());
        _notPossessed.Add(new RadiationActiveMutation());
        _notPossessed.Add(new RecallActiveMutation());
        _notPossessed.Add(new ResistActiveMutation());
        _notPossessed.Add(new ShriekActiveMutation());
        _notPossessed.Add(new SmellMetActiveMutation());
        _notPossessed.Add(new SmellMonActiveMutation());
        _notPossessed.Add(new SpitAcidActiveMutation());
        _notPossessed.Add(new SterilityActiveMutation());
        _notPossessed.Add(new SwapPosActiveMutation());
        _notPossessed.Add(new TelekinesActiveMutation());
        _notPossessed.Add(new VampirismActiveMutation());
        _notPossessed.Add(new VteleportActiveMutation());
        _notPossessed.Add(new WeighMagActiveMutation());
        // Passive Mutations
        _notPossessed.Add(new AlbinoPassiveMutation());
        _notPossessed.Add(new ArthritisPassiveMutation());
        _notPossessed.Add(new BlankFacPassiveMutation());
        _notPossessed.Add(new ElecToucPassiveMutation());
        _notPossessed.Add(new EspPassiveMutation());
        _notPossessed.Add(new FearlessPassiveMutation());
        _notPossessed.Add(new FireBodyPassiveMutation());
        _notPossessed.Add(new FleshRotPassiveMutation());
        _notPossessed.Add(new HyperIntPassiveMutation());
        _notPossessed.Add(new HyperStrPassiveMutation());
        _notPossessed.Add(new IllNormPassiveMutation());
        _notPossessed.Add(new InfravisPassiveMutation());
        _notPossessed.Add(new IronSkinPassiveMutation());
        _notPossessed.Add(new LimberPassiveMutation());
        _notPossessed.Add(new MagicResPassiveMutation());
        _notPossessed.Add(new MoronicPassiveMutation());
        _notPossessed.Add(new MotionPassiveMutation());
        _notPossessed.Add(new PunyPassiveMutation());
        _notPossessed.Add(new RegenPassiveMutation());
        _notPossessed.Add(new ResilientPassiveMutation());
        _notPossessed.Add(new ResTimePassiveMutation());
        _notPossessed.Add(new ScalesPassiveMutation());
        _notPossessed.Add(new ShortLegPassiveMutation());
        _notPossessed.Add(new SillyVoiPassiveMutation());
        _notPossessed.Add(new SusStatsPassiveMutation());
        _notPossessed.Add(new VulnElemPassiveMutation());
        _notPossessed.Add(new WartSkinPassiveMutation());
        _notPossessed.Add(new WingsPassiveMutation());
        _notPossessed.Add(new XtraEyesPassiveMutation());
        _notPossessed.Add(new XtraFatPassiveMutation());
        _notPossessed.Add(new XtraLegsPassiveMutation());
        _notPossessed.Add(new XtraNoisPassiveMutation());
        // Random Mutations
        _notPossessed.Add(new AlcoholRandomMutation());
        _notPossessed.Add(new AttAnimalRandomMutation());
        _notPossessed.Add(new AttDemonRandomMutation());
        _notPossessed.Add(new AttDragonRandomMutation());
        _notPossessed.Add(new BanishAllRandomMutation());
        _notPossessed.Add(new BeakRandomMutation());
        _notPossessed.Add(new BersRageRandomMutation());
        _notPossessed.Add(new ChaosGiftRandomMutation());
        _notPossessed.Add(new CowardiceRandomMutation());
        _notPossessed.Add(new DisarmRandomMutation());
        _notPossessed.Add(new EatLightRandomMutation());
        _notPossessed.Add(new FlatulentRandomMutation());
        _notPossessed.Add(new HalluRandomMutation());
        _notPossessed.Add(new HornsRandomMutation());
        _notPossessed.Add(new HpToSpRandomMutation());
        _notPossessed.Add(new InvulnRandomMutation());
        _notPossessed.Add(new NauseaRandomMutation());
        _notPossessed.Add(new NormalityRandomMutation());
        _notPossessed.Add(new PolyWoundRandomMutation());
        _notPossessed.Add(new ProdManaRandomMutation());
        _notPossessed.Add(new RawChaosRandomMutation());
        _notPossessed.Add(new RteleportRandomMutation());
        _notPossessed.Add(new ScorTailRandomMutation());
        _notPossessed.Add(new SpeedFluxRandomMutation());
        _notPossessed.Add(new SpToHpRandomMutation());
        _notPossessed.Add(new TentaclesRandomMutation());
        _notPossessed.Add(new TrunkRandomMutation());
        _notPossessed.Add(new WalkShadRandomMutation());
        _notPossessed.Add(new WarningRandomMutation());
        _notPossessed.Add(new WastingRandomMutation());
        _notPossessed.Add(new WeirdMindRandomMutation());
        _notPossessed.Add(new WraithRandomMutation());
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
        int roll = Program.Rng.DieRoll(total);
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
        int roll = Program.Rng.DieRoll(total);
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