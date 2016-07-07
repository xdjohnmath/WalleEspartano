using UnityEngine;
using System.Collections;

//Criação de enums 
public enum direction { left, right, up, down };
public enum rotationDirection { left, right};
public enum objetcsTypes { treadmill, engine, press, springs };


public class ObjectsManager : MonoBehaviour{

    //Inicialização dos enums
    [SerializeField]
    public direction dir;
    public objetcsTypes types;
    public rotationDirection rotDir;

    //Variáveis float
    [SerializeField]
    public float rotationSpeed;
    public float movementSpeed;
    public float boxSpeed = 2;
    public float leftEdge, rightEdge, upEdge, downEdge;

    public bool canMoveDirection, movePress, pressActive;
 
    void Start () {
        //Settando as coisas

        SettingType ();
        SettingObjetcNameAndTag (types, this.gameObject);
        
    }

    void FixedUpdate () {
        //Settando movimento e rotação dos objetos que se movimentam/rotacionam na fase
        if (movePress == true) {
            MovementPhysics (dir, movementSpeed);
            MovePress (dir, movementSpeed);
        }
        else {
            Movement (dir, movementSpeed);
        }

        Rotation (rotDir, rotationSpeed);

        //mudando movimento e rotação ao digitar
        if (Input.anyKeyDown && canMoveDirection == true) {
            ChangeMovementDirection (dir);
            ChangeRotationDirection (rotDir);
        }
        //Se o objeto se movimenta, ele tem limites
        if (movementSpeed != 0) {
            Borders (leftEdge, rightEdge, upEdge, downEdge);
        }

    }

    //mudando movimento e rotação ao clicar
    void OnMouseDown () {
        if (canMoveDirection == true) {
            ChangeMovementDirection (dir);
            ChangeRotationDirection (rotDir);
        }
    }

    //Método de Settar nome e tag - Caso adicionado enum no objectsTypes, adicionar cases aqui
	public void SettingObjetcNameAndTag (objetcsTypes objType, GameObject obj) {
        switch (objType) {
            case objetcsTypes.treadmill:
                obj.name = "Treadmill ";
                obj.tag = "Treadmill";
            break;
            case objetcsTypes.engine:
                obj.name = "Engine ";
                obj.tag = "Engine";
            break;
            case objetcsTypes.press:
                obj.name = "Press ";
                obj.tag = "Press";
            break;
            case objetcsTypes.springs:
                obj.name = "Springs ";
                obj.tag = "Springs";
            break;
        }
    }

    //Settando so tipos de objetos - Caso adicionado enum no objectsTypes, adicionar cases aqui
    public void SettingType () {
        switch (types) {
            case objetcsTypes.treadmill:
                types = objetcsTypes.treadmill;
            break;
            case objetcsTypes.engine:
                types = objetcsTypes.engine;
            break;
            case objetcsTypes.press:
                types = objetcsTypes.press;
            break;
            case objetcsTypes.springs:
                types = objetcsTypes.springs;
            break;
        }
    }

    //Método para movimentar os objetos sem física
    public void Movement (direction dir, float speed) {
        if (dir == direction.left) {
            transform.Translate (Vector2.left * speed * Time.deltaTime);
        }
        else if (dir == direction.right) {
            transform.Translate (Vector2.right * speed * Time.deltaTime);
        }
        else if (dir == direction.up) {
            transform.Translate (Vector2.up * speed * Time.deltaTime);
        }
        else if (dir == direction.down) {
            transform.Translate (Vector2.down * speed * Time.deltaTime);
        }
    }

    //Método para movimentar os objetos com física
    public void MovementPhysics (direction dir, float speed) {
        if (dir == direction.left) {
            gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * speed, ForceMode2D.Force);
        }
        else if (dir == direction.right) {
            gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * speed, ForceMode2D.Force);
        }
        else if (dir == direction.up) {
            gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * speed, ForceMode2D.Force);
        }
        else if (dir == direction.down) {
            gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.down * speed, ForceMode2D.Force);
        }
    }

   void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Press") {
            StartCoroutine (DelayPress (1f));
        }
        if (other.gameObject.tag == "Stop") {
            StartCoroutine (DelayPress (2f));
            StartCoroutine (PressActivator (3f));
            
        }
    }

    IEnumerator DelayPress (float t) {
        yield return new WaitForSeconds (t);
        pressActive = false;
    }

    IEnumerator PressActivator (float t) {
        yield return new WaitForSeconds (t);
        pressActive = true;
        
    }

    public void MovePress (direction dir, float speed) {
        if (dir == direction.left) {
            if (pressActive == true) {
                gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * speed * 10, ForceMode2D.Impulse);
            }
            else {
                gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * speed * 0.1f, ForceMode2D.Impulse);
            }
        }
        else if (dir == direction.right) {
            if (pressActive == true) {
                gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * speed * 10, ForceMode2D.Impulse);
            }
            else {
                gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * speed * 0.1f, ForceMode2D.Impulse);

            }
        }
        else if (dir == direction.up) {
            if (pressActive == true) {
                gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * speed * 10, ForceMode2D.Impulse);
            }
            else {
                gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.down * speed * 0.1f, ForceMode2D.Impulse);

            }
        }
        else if (dir == direction.down) {
            if (pressActive == true) {
                gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.down * speed * 10, ForceMode2D.Impulse);
            }
            else {
                gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * speed * 0.1f, ForceMode2D.Impulse);

            }
        }
    }

    //Método para rotacionar os objetos
    public void Rotation (rotationDirection dir, float speed) {
        if (dir == rotationDirection.left) {
            transform.Rotate (Vector3.forward * speed * Time.deltaTime);
        }
        else if (dir == rotationDirection.right) {
            transform.Rotate (Vector3.back * speed * Time.deltaTime);
        }
    }
    
    //Método para mudar a direção
    public void ChangeMovementDirection (direction thisDir) {
        switch (thisDir) {
            case direction.left:
                dir = direction.right;
            break;
            case direction.right:
                dir = direction.left;
            break;
            case direction.up:
                dir = direction.up;
            break;
            case direction.down:
                dir = direction.down;
            break;
        }
    }

    //Método para mudar a rotação
    public void ChangeRotationDirection (rotationDirection thisDir) {
        switch (thisDir) {
            case rotationDirection.left:
                rotDir = rotationDirection.right;
            break;
            case rotationDirection.right:
                rotDir = rotationDirection.left;
            break;
        }
    }

    //Método para dar limites
    public void Borders (float left, float right, float up, float down) {
        if (transform.position.x <= left) {
            dir = direction.right;
        }
        else if (transform.position.x >= right) {
            dir = direction.left;
        }
        else if (transform.position.y <= down) {
            dir = direction.down;
        }
        else if (transform.position.y >= up) {
            dir = direction.up;
        }
    }

    

}
