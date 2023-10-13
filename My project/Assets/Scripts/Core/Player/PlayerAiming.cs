using UnityEngine;
using Cinemachine;
using System.Collections;

public class PlayerAiming : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputReader inputReader;

    [Header("Crosshair Settings:")]
    [SerializeField] private RectTransform crosshairTransform;
    [SerializeField] private float crosshairSpeed = 50f;

    [Header("Camera Movement Settings:")]
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    [SerializeField] private float cameraSpeed = 2f;
    [SerializeField] private float minY = -2f;
    [SerializeField] private float maxY = 2f;

    [Header("Weapon Aiming Settings:")]
    [SerializeField] private float maxAimDistance = 100f;

    [Header("Shooting Settings:")]
    [SerializeField] private GameObject projectilePrefab; // Prefab for the projectile
    [SerializeField] private Transform projectileSpawnPoint; // Point where the projectile will be spawned, e.g., the weapon's muzzle
    [SerializeField] private float projectileSpeed = 20f; // Speed of the projectile
    [SerializeField] private float shootDelay = 0.5f;


    private Vector3 previousLookInput;
    private bool isFiring;
    private Camera mainCamera;
    private float initialCameraYOffset;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        initialCameraYOffset = cinemachineCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.y;
    }

    private void OnEnable()
    {
        inputReader.OnLookEvent += HandlePlayerLookInput;
    }

    private void OnDisable()
    {
        inputReader.OnLookEvent -= HandlePlayerLookInput;
    }

    private void Update()
    {
        HandlePlayerLook();
    }

    private void HandlePlayerLookInput(Vector2 lookInput)
    {
        previousLookInput = new Vector3(lookInput.x, 0, lookInput.y);
    }

    private void HandlePlayerLook()
    {
        //crosshairTransform.anchoredPosition += new Vector2(0, previousLookInput.z * crosshairSpeed * Time.deltaTime);

        CinemachineComposer composer = cinemachineCamera.GetCinemachineComponent<CinemachineComposer>();
        float newCameraYOffset = composer.m_TrackedObjectOffset.y + previousLookInput.z * cameraSpeed * Time.deltaTime;

        composer.m_TrackedObjectOffset.y = Mathf.Clamp(newCameraYOffset, initialCameraYOffset + minY, initialCameraYOffset + maxY);
    }

    public void Shoot()
    {
        ShootProjectile();
    }

    void ShootProjectile()
    {
        if (isFiring) return;

        Ray ray = mainCamera.ScreenPointToRay(crosshairTransform.position);
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit, maxAimDistance))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.origin + ray.direction * maxAimDistance;
        }

        // Calculate the shoot direction
        Vector3 shootDirection = (targetPoint - projectileSpawnPoint.position).normalized;


        // Instantiate the projectile and shoot it in the determined direction
        GameObject projectileInstance = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        Rigidbody projectileRb = projectileInstance.GetComponent<Rigidbody>();
        if (projectileRb) // Ensure the projectile has a Rigidbody component
        {
            projectileRb.velocity = shootDirection * projectileSpeed;
        }
        isFiring = true;
        StartCoroutine(FireDelay());

    }

    private IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(shootDelay);

        isFiring = false;   
    }
}