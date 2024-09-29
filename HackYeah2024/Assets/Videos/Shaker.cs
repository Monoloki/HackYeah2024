using UnityEngine;

[RequireComponent(typeof(ConstantForce))]
public class Shaker : MonoBehaviour {
    public float shakeMagnitude = 0.1f;  // Intensywnoœæ trzêsienia
    public float forceZ = 10f;           // Sta³a si³a wzd³u¿ osi Z

    private Vector3 initialLocalPosition; // Pocz¹tkowa pozycja lokalna obiektu
    private ConstantForce constantForce;  // Referencja do komponentu ConstantForce

    void Start() {
        // Zapisz pocz¹tkow¹ lokaln¹ pozycjê obiektu
        initialLocalPosition = transform.localPosition;

        // Pobierz referencjê do komponentu ConstantForce
        constantForce = GetComponent<ConstantForce>();

        // Ustaw sta³¹ si³ê na osi Z
        constantForce.force = new Vector3(0, 0, forceZ);
    }

    void Update() {
        // Uzyskaj aktualn¹ pozycjê (uwzglêdniaj¹c¹ ruch na osi Z)
        Vector3 currentPosition = transform.localPosition;

        // Dodaj losowe trzêsienie do bie¿¹cej pozycji, bez nadpisywania osi Z
        currentPosition.x = initialLocalPosition.x + Random.Range(-shakeMagnitude, shakeMagnitude);
        currentPosition.y = initialLocalPosition.y + Random.Range(-shakeMagnitude, shakeMagnitude);

        // Zastosuj zaktualizowan¹ pozycjê z efektem trzêsienia
        transform.localPosition = currentPosition;
    }
}