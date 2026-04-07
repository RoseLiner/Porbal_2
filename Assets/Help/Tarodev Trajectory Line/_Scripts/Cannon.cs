using UnityEngine;

public class Cannon : MonoBehaviour {
    [SerializeField] private Projection _projection;

    private void Update() {
        ForceMultiplier();
        HandleControls();
        _projection.SimulateTrajectory(_ballPrefab, _ballSpawn.position, _ballSpawn.forward * _throwForce);
    }

    #region Handle Controls

    [SerializeField] private Ball _ballPrefab;
    //        throwForce = force;
    [SerializeField] private float _throwForce = 20;
    [SerializeField] private float _force = 20;
    [SerializeField] private Transform _ballSpawn;
    [SerializeField] private Transform _barrelPivot;
    [SerializeField] private float _rotateSpeed = 30;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private ParticleSystem _launchParticles;

    public float currentForceMultiplier = 1.0f;
    public float minMultiplier = 0.5f;
    public float maxMultiplier = 2.0f;
    public float scrollSensitivity = 0.7f;

    private bool _canShoot = true;

    /// <summary>
    /// This is absolute spaghetti and should not be look upon for inspiration. I quickly smashed this together
    /// for the tutorial and didn't look back
    /// </summary>
    private void HandleControls() {
        if (Input.GetKey(KeyCode.DownArrow)) _barrelPivot.Rotate(Vector3.right * _rotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.UpArrow)) _barrelPivot.Rotate(Vector3.left * _rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * _rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0 ) && _canShoot) {
            var spawned = Instantiate(_ballPrefab, _ballSpawn.position, _ballSpawn.rotation);
            spawned.Init(_ballSpawn.forward * _throwForce, false);
            _canShoot = false;
            Invoke(nameof(ResetShoot), 3f);
            Destroy(spawned.gameObject, 7f);
            //_throwForce =_force;
            _launchParticles.Play();
            _source.PlayOneShot(_clip);
        }
    }

    void ForceMultiplier()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetAxis("Mouse ScrollWheel") != 0f )
        {
            currentForceMultiplier += scrollInput * scrollSensitivity;
            currentForceMultiplier = Mathf.Clamp(currentForceMultiplier, minMultiplier, maxMultiplier);
            _throwForce = _force * currentForceMultiplier;
        }
    }
    private void ResetShoot()
    {
        _canShoot = true;
    }
    #endregion
}