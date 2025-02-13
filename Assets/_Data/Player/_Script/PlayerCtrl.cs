using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCtrl : TFGMonoBehaviour
{
    [SerializeField] protected vThirdPersonController thirdPersonController;
    public vThirdPersonController ThirdPersonController => thirdPersonController;
    [SerializeField] protected vThirdPersonCamera thirdPersonCamera;
    public vThirdPersonCamera ThirdPersonCamera => thirdPersonCamera;
    [SerializeField] protected CrosshairPointer crosshairPointer;
    public CrosshairPointer CrosshairPointer => crosshairPointer;

    [SerializeField] protected Rig aimingRig;
    public Rig AimingRig => aimingRig;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected Weapons weapons;
    public Weapons Weapons => weapons;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadThirdPersonController();
        this.LoadThirdPersonCamera();
        this.LoadCrosshairPointer();
        this.LoadAimingRig();
        this.LoadAnimator();
        this.LoadWeapons();
    }

    protected virtual void LoadWeapons()
    {
        if (this.weapons != null) return;
        this.weapons = GetComponentInChildren<Weapons>();
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadAimingRig()
    {
        if (this.aimingRig != null) return;
        this.aimingRig = transform.Find("Model").Find("AimingRig").GetComponent<Rig>();
        Debug.Log(transform.name + ": LoadAimingRig", gameObject);
    }

    protected virtual void LoadThirdPersonController()
    {
        if (thirdPersonController != null) return;
        this.thirdPersonController = GetComponent<vThirdPersonController>();
        Debug.Log(transform.name + ": LoadThirdPersonController", gameObject);
    }

    protected virtual void LoadThirdPersonCamera()
    {
        if (thirdPersonCamera != null) return;
        this.thirdPersonCamera = GameObject.FindAnyObjectByType<vThirdPersonCamera>();
        this.thirdPersonCamera.rightOffset = 0.6f;
        this.thirdPersonCamera.defaultDistance = 1.2f;
        this.thirdPersonCamera.height = 1.3f;
        this.thirdPersonCamera.yMinLimit = -40f;
        this.thirdPersonCamera.yMaxLimit = 40f;
        Debug.Log(transform.name + ": LoadThirdPersonCamera", gameObject);
    }

    protected virtual void LoadCrosshairPointer()
    {
        if (crosshairPointer != null) return;
        this.crosshairPointer = GetComponentInChildren<CrosshairPointer>();
        Debug.Log(transform.name + ": LoadCrosshairPointer", gameObject);
    }
}
