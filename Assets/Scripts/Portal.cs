using UnityEngine;

public class Portal : Collideble
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            GameManager.instance.SaveState();

            //Teleport Player
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length - 1)];

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
