using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowDamage : MonoBehaviour {

    public delegate void ShowDamageEvent(Vector2 spawnPos,int damage, bool isCritical);
    public static ShowDamageEvent onShowDamage;
    
    [SerializeField] private GameObject _damageCanvas;
    
	void Awake () {
        onShowDamage += ShowDamageDone;
	}

    void ShowDamageDone(Vector2 spawnPos,int damage, bool isCritical)
    {
        GameObject damageCanvas = Instantiate(_damageCanvas);
        Text damageText = damageCanvas.GetComponentInChildren<Text>();
        damageCanvas.transform.position = spawnPos;
        if (isCritical) //If the spell is critical, show it in text and change the style to italic
        {
            damageText.text = "Critical" + "\n" + damage; 
            damageText.fontStyle = FontStyle.Italic;
        }else if (!isCritical) //Else just show damage
        {
            damageText.text = damage.ToString();
        }
        //Gives the damagecanvas a "jump / hop" effect
        damageCanvas.transform.DOJump(new Vector3(damageCanvas.transform.position.x, damageCanvas.transform.position.y + 1, 0), 2, 1, 1.5f);
    }

    private void OnDisable()
    {
        onShowDamage -= ShowDamageDone;
    }
}
