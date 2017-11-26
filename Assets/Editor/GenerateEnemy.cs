using UnityEngine;
using UnityEditor;

public class GenerateEnemy : MonoBehaviour{
    [MenuItem("Custom Objects/Create Enemy")]

    private static void Init()
    {
        GameObject enemyObject = new GameObject(); //This is the enemy object
        enemyObject.name = Tags.ENEMY; //Sets the created objects name to Enemy so you can find it easily in the hierarchy
        enemyObject.tag = Tags.ENEMY; //Gives the enemy the Enemy tag
        enemyObject.layer = 9; //Sets the enemies layer to the Enemy Layer
        
        //Adds all the components needed by an enemy
        Rigidbody2D enemyRB = enemyObject.AddComponent<Rigidbody2D>();
        enemyObject.AddComponent<SpriteRenderer>();
        BoxCollider2D collider = enemyObject.AddComponent<BoxCollider2D>();
        enemyObject.AddComponent<Animator>();
        enemyObject.AddComponent<Enemy>();
        enemyObject.AddComponent<MoveObject>();
        enemyObject.AddComponent<Healthbar>();
        enemyObject.AddComponent<EnemyAnimations>();

        collider.isTrigger = true; // Makes the collider a trigger so it can get hit by spells and such
        enemyRB.gravityScale = 0; //Sets the gravity to 0 so it wont fall down;

        //Creates the enemies canvas
        GameObject enemyCanvas = Instantiate(Resources.Load("Prefabs/Enemies/EnemyCanvas")) as GameObject;
        enemyCanvas.transform.SetParent(enemyObject.transform); //Sets the generated enemy as the parent of the canvas
        Vector2 canvasPos = new Vector2(0,-0.07f); //Basic canvas position
        enemyCanvas.transform.position = canvasPos; //Sets the canvas position
    }

}
