using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
  
    public float backgroundSpeed; 
    public Renderer backgroundRenderer;


    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0, backgroundSpeed * Time.deltaTime); 
    }
}
