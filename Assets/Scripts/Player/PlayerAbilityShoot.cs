using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<GunBase> guns;
    public Transform gunPosition;

    private GunBase _currentGun;
    private int _currentGunIndex = 0;

    protected override void Init()
    {
        base.Init();

        CreateGun();

        // Registra os métodos para serem chamados quando a tecla correspondente for pressionada
        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();
    }

    private void CreateGun()
    {
        // Instancia a primeira arma da lista ao iniciar
        _currentGun = Instantiate(guns[_currentGunIndex], gunPosition);

        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void Update()
    {
        // Verifica se a tecla 1 foi pressionada para trocar para a primeira arma
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchGun(0);
        }
        // Verifica se a tecla 2 foi pressionada para trocar para a segunda arma
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchGun(1);
        }
    }

    private void SwitchGun(int index)
    {
        if (index < 0 || index >= guns.Count || index == _currentGunIndex)
        return;

        // Desativa a arma atual
        _currentGun.StopShoot();
        Destroy(_currentGun.gameObject);

        // Atualiza o índice da arma atual
        _currentGunIndex = index;

        // Instancia a nova arma
        _currentGun = Instantiate(guns[_currentGunIndex], gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }


    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Start Shoot");
    }
    
    private void CancelShoot()
    {
        _currentGun.StopShoot();
        Debug.Log("Cancel Shoot");
    }
}
