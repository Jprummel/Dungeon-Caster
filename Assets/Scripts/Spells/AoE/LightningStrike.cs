public class LightningStrike : AreaOfEffectSpell {

    protected override void Awake()
    {
        base.Awake();
        _soundEffectTag = SoundEffectTags.LIGHTBEAM;
    }
}
