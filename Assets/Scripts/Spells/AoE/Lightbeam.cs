public class Lightbeam : AreaOfEffectSpell {
    
	protected override void Awake () {
        base.Awake();
        _soundEffectTag = SoundEffectTags.LIGHTBEAM;
	}
}
