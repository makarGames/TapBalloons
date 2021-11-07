using UnityEngine;

public class VfxExplosion : MonoBehaviour
{
    public Color color
    {
        set
        {
            ParticleSystem.MainModule settings = _particles.main;

            settings.startColor = new Color(value.r, value.g, value.b, 0.5f);
        }
    }

    private ParticleSystem _particles;

    private void Awake()
    {
        _particles = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        GetComponent<ParticleSystem>()?.Play();
    }
}
