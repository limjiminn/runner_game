using UnityEngine;

public class BackgroundScrolll : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("텍스쳐의 스크롤 속도가 얼마나 빨라야 하는가?")]
    public float scrollSpeed;

    [Header("References")]
    public MeshRenderer meshRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update() 
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * GameManager.Instance.CalculateGameSpeed() / 20 * Time.deltaTime, 0);
    }
}
