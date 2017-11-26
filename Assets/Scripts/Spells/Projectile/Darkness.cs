using UnityEngine;

public class Darkness : ProjectileSpell {

    [SerializeField] private GameObject _afterEffect;
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnDestroy()
    {
        GameObject darkHole = Instantiate(_afterEffect);
        darkHole.transform.position = this.transform.position;
    }
}
