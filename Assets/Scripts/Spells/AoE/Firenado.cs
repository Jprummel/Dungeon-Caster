public class Firenado : AreaOfEffectSpell {
    
	protected override void Awake () {
        base.Awake();
        _soundEffectTag = SoundEffectTags.FIRENADO;
	}
}
