using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManagment : MonoBehaviour {

    [SerializeField] private Button[] allButtonsInScene;

    private Animation loadBGAnimation;

    public LoadBG LoadBG;

    private void Start()
    {
        loadBGAnimation = LoadBG.GetComponent<Animation>();
    }

    public void LoadScene(string nameScene)
    {
        LoadBG.NameLoadScene = nameScene;
        for (int i = 0; i < allButtonsInScene.Length; i++)
        {
            allButtonsInScene[i].enabled = false;
        }
        loadBGAnimation.Play("HideBG");
        LoadBG.LoadScene += SceneManager.LoadScene;
    }
}
