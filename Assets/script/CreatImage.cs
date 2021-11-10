using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreatImage : MonoBehaviour
{
    private GameObject objj;
    public float x = 0.003f, y = 0.003f;
    // Start is called before the first frame update
    void Start()
    {
        find("image.jpg");
        objj = GameObject.Find("Mark");
    }

    void Update()
    {
        changeImage(objj, x, y);    
    }

    public void find(string vFileName)
    {
        string Path = "Assets\\Resources\\" + vFileName;
        if (File.Exists(Path))
        {
            creatSprite(vFileName);
        }
    }

    public void creatSprite(string vFileName)
    {
        string FileName = Path.GetFileNameWithoutExtension(vFileName);
        GameObject Object = new GameObject();
        Object.AddComponent<SpriteRenderer>();
        SpriteRenderer SpriteRenderer = Object.GetComponent<SpriteRenderer>();
        SpriteRenderer.drawMode = SpriteDrawMode.Sliced;
        SpriteRenderer.name = "Mark";
        Texture2D Picture = (Texture2D)Resources.Load(FileName) as Texture2D;
        Rect size = new Rect(0, 0, Picture.width, Picture.height);
        Vector2 Pivot = new Vector2(0, 0);
        SpriteRenderer.sprite = Sprite.Create(Picture, size, Pivot);
        Object.transform.position = new Vector3(-12.47276f, 9.216198f, 0);
    }

    private void changeImage(GameObject obj, float x, float y)
    {
        SpriteRenderer spr = obj.GetComponent<SpriteRenderer>();
        spr.size = new Vector2(UnityEngine.Screen.width * x, UnityEngine.Screen.height * y);
    }
}