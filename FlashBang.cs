using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashBang : MonoBehaviour
{
    private Image WhiteImage;
    private Rigidbody RB;
    private ParticleSystem FlashParticle;
    private MeshRenderer Renderer;
    private AudioSource WhiteNoise;
    private AudioSource Bang;

    private void Start()
    {
        Renderer = gameObject.GetComponent<MeshRenderer>();
        WhiteImage = GameObject.FindGameObjectWithTag("WhiteImage").GetComponent<Image>();
        WhiteNoise = GameObject.FindGameObjectWithTag("WhiteNoise").GetComponent<AudioSource>();
        Bang = GameObject.FindGameObjectWithTag("Bang").GetComponent<AudioSource>();
        FlashParticle = gameObject.GetComponent<ParticleSystem>();
        RB = gameObject.GetComponent<Rigidbody>();
        RB.velocity = new Vector3(10, 0, 0);
        StartCoroutine(WhiteFade());
    }

    private IEnumerator WhiteFade()
    {
        yield return new WaitForSeconds(4f);

        WhiteImage.color = new Vector4(1, 1, 1, 1);
        FlashParticle.Play();
        Bang.Play();
        WhiteNoise.Play();
        Renderer.enabled = false;

        float FadeSpeed = 1f;
        float Modifier = 0.01f;
        float WaitTime = 0;

        for(int i = 0; WhiteImage.color.a > 0; i++)
        {
            WhiteImage.color = new Vector4(1, 1, 1, FadeSpeed);
            FadeSpeed = FadeSpeed - 0.025f;
            Modifier = Modifier * 1.5f;
            WaitTime = 0.5f - Modifier;
            if (WaitTime < 0.1f) WaitTime = 0.1f;
            WhiteNoise.volume -= 0.05f;
            yield return new WaitForSeconds(WaitTime);
        }

        WhiteNoise.Stop();
        WhiteNoise.volume = 1;
    }
}
