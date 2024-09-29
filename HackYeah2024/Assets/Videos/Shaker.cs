using UnityEngine;

[RequireComponent(typeof(ConstantForce))]
public class Shaker : MonoBehaviour {
    public float shakeMagnitude = 0.1f;  // Intensywno�� trz�sienia
    public float forceZ = 10f;           // Sta�a si�a wzd�u� osi Z

    private Vector3 initialLocalPosition; // Pocz�tkowa pozycja lokalna obiektu
    private ConstantForce constantForce;  // Referencja do komponentu ConstantForce

    void Start() {
        // Zapisz pocz�tkow� lokaln� pozycj� obiektu
        initialLocalPosition = transform.localPosition;

        // Pobierz referencj� do komponentu ConstantForce
        constantForce = GetComponent<ConstantForce>();

        // Ustaw sta�� si�� na osi Z
        constantForce.force = new Vector3(0, 0, forceZ);
    }

    void Update() {
        // Uzyskaj aktualn� pozycj� (uwzgl�dniaj�c� ruch na osi Z)
        Vector3 currentPosition = transform.localPosition;

        // Dodaj losowe trz�sienie do bie��cej pozycji, bez nadpisywania osi Z
        currentPosition.x = initialLocalPosition.x + Random.Range(-shakeMagnitude, shakeMagnitude);
        currentPosition.y = initialLocalPosition.y + Random.Range(-shakeMagnitude, shakeMagnitude);

        // Zastosuj zaktualizowan� pozycj� z efektem trz�sienia
        transform.localPosition = currentPosition;
    }
}