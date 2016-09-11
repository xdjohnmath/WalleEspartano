using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

    //Inicialização de variáveis
    public float speed;
    public int speedMod;
    public direction dir;
    public bool mayMove = false;
    
    //Default modificador de velocidade
    void Start () {
        speedMod = 50;
    }

    //Colisão das caixas com os objetos
    void OnCollisionStay2D (Collision2D other) {
        //Colisão com a esteira
        if (other.gameObject.tag == "Treadmill") {
            //Setta as variaveis das caixas para serem iguais as váriaveis das esteiras 
            speed = other.gameObject.GetComponent<ObjectsManager> ().boxSpeed * speedMod;
            dir = other.gameObject.GetComponent<ObjectsManager> ().dir;
            //Pode se mover
            mayMove = true;
        }
    }

    //Ao sair da colisão
    void OnCollisionExit2D (Collision2D other) {
        //Se for com a esteira
        if (other.gameObject.tag == "Treadmill") {
            //Não pode mais andar e a velocidade volta a ser 0
            mayMove = false;
            speed = 0;
        }
    }

    //Ao colidir com o trigger 
    void OnTriggerEnter2D (Collider2D other) {
        //trigger do cano do fim da fase
        if (other.gameObject.name == "EndPhase") {
            //Destroi e soma um nas caixas ganhas
            Destroy (this.gameObject);
            BoxManager.instance.wonBoxes++;
        }
        //trigger da fornalha
        if (other.gameObject.name == "Furnace") {
            //destroi e soma um nas caixas perdidas
            Destroy (this.gameObject);
            BoxManager.instance.lostBoxes++;
        }
        //destroi caixa
        if (other.gameObject.tag == "BoxDestroyer") {
            Destroy (this.gameObject);
            print ("hi");
        }
    }
    
    //Se puder se mover, chama função de mover
    void FixedUpdate () {
        if (mayMove) {
            MoveBoxes (dir, speed);

        }
    }

    //Adiciona força dada a direção e a velocidade do objeto que ele tá 
    public void MoveBoxes (direction dir, float speed) {
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



}
