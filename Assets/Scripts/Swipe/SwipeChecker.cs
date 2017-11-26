using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwipeChecker : MonoBehaviour
{

    //Rune swipe
    [SerializeField] private List<GameObject> _spellPoints = new List<GameObject>();
    [SerializeField] private List<Collider2D> _runeColliders = new List<Collider2D>();

    private List<GameObject> _runeCombo = new List<GameObject>();

    private string _spellCode;
    private int _currentLinePoint;

    private Collider2D _lastTouched;

    [SerializeField] private GameObject _spellToSpawn;
    [SerializeField] private LineRenderer _lineRenderer;

    private void Awake()
    {
        for (int i = 0; i < _spellPoints.Count; i++)
        {
            Collider2D coll = _spellPoints[i].GetComponent<Collider2D>();
            _runeColliders.Add(coll);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Raycast();
        }

        if (Input.GetMouseButtonUp(0))
        {
            MakeCode();
            ResetRune();
        }
    }

    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (!GameState.IsPaused && GameState.CanSwipe)
        {
            _lineRenderer.positionCount = 1 + _currentLinePoint;
            if (hit)
            {
                if (hit.collider.tag == Tags.RUNEPOINT)
                {
                    _runeCombo.Add(hit.collider.gameObject);
                    _lastTouched = hit.collider;
                    _lineRenderer.SetPosition(_currentLinePoint, hit.collider.gameObject.transform.position);
                    _currentLinePoint = _currentLinePoint + 1;
                    _lineRenderer.positionCount = 1 + _currentLinePoint;
                    TurnOnColliders();
                }
                else if (hit.collider.tag == Tags.UILEVELDIVIDER)
                {
                    ResetRune();
                }
            }
            _lineRenderer.SetPosition(_currentLinePoint, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void ResetRune()
    {
        _currentLinePoint = 0;
        _lineRenderer.positionCount = 1 + _currentLinePoint;

        for (int i = 0; i < _spellPoints.Count; i++)
        {
            _runeColliders[i].enabled = true;
        }
        _runeCombo.Clear();
        _spellCode = null;
    }

    void TurnOnColliders() {
        for (int i = 0; i < _runeColliders.Count; i++)
        {
            if (_runeColliders[i] == _lastTouched)
            {
                _runeColliders[i].enabled = false;
            }
            else if (_runeColliders[i] != _lastTouched)
            {
                _runeColliders[i].enabled = true;
            }
        }
    }

    void MakeCode() {
        for (int i = 0; i < _runeCombo.Count; i++)
        {
            _spellCode = _spellCode + _runeCombo[i].name;            
        }
        if (_spellCode != null)
        {
            SpellCombos.onSpawnSpell(_spellCode);
            _spellCode = null;
        }
    }
}