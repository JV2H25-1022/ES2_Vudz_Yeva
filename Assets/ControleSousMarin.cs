using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class ControleSousMarin : MonoBehaviour
{
    [SerializeField] private float _vitesseMouvement;
    private Rigidbody _rb;
    private Vector3 directionInput;
    private Animator _animator;
    private ControleSousMarin _mouvementSousMarin;

    [SerializeField] private float _modifierAnimTranslation;
// Start is called before the first frame update
void Start()
    {
    _rb = GetComponent<Rigidbody>();
    _animator = GetComponent<Animator>();
    _mouvementSousMarin = GetComponent<ControleSousMarin>();
    }

    void OnAvantArriere(InputValue directionBase)
    {
        Vector3 directionAvecVitesse = directionBase.Get<Vector3>() * _vitesseMouvement;
        directionInput = new Vector3(0f, directionAvecVitesse.z, 0f);
    }
    void OnHautBas(InputValue directionBase)
    {
        Vector2 directionAvecVitesse = directionBase.Get<Vector2>() * _vitesseMouvement;
        directionInput = new Vector3 (directionAvecVitesse.x, 0f, directionAvecVitesse.y);
    }

    void FixedUpdate()
    {
        // calculer et appliquer la translation
        Vector3 mouvement = _mouvementSousMarin.directionInput;
        _rb.velocity = mouvement;
      

        // calculer un modifiant pour la vitesse d'animation
        
        _animator.SetFloat("Vitesse", mouvement.magnitude * _modifierAnimTranslation);
       
    }
}
