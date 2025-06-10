using UnityEngine;
//Week 13- Inheritence in C# and particle effects
//Andrea Hayes
//17 May 2025
//Code Version: unkown
//Wits DIGA2003A Lecture Slides
public class Particles : MonoBehaviour
{
    public ParticleSystem dust;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Dust();
    }

    public void Dust()
    {
        dust.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
