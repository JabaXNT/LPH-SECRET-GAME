using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ChapterLoader : MonoBehaviour
{
    public Text ChapterName;
    public Button objectTestButton;
    public Button objectVideo1Button;
    public Button objectVideo2Button;
    private SummaryData objectData;

    void Start()
    {
        objectData = SummaryData.currentChapter;
        if (objectData.testPath == "test1")
        {
            objectVideo1Button.onClick.AddListener(() => LoadExhibitScene(new ExhibitData("Паскалина", "Videos/Pascalina", "Паскалина (1642 г.) - механический калькулятор, созданный французским математиком и философом Блезом Паскалем. Это первое известное устройство, предназначенное для выполнения арифметических операций, таких как сложение, вычитание, умножение и деление. Паскалина использовала систему зубчатых колес для представления чисел и проведения вычислений.", "Scenes/Pascalina", "Assets/Sprites/Exhibits/pascalina.png", "Scenes/Chapters/FirstRoom")));
            objectVideo2Button.onClick.AddListener(() => LoadExhibitScene(new ExhibitData("Ex1", "Videos/Wilgelm", "Считающие часы Вильгельма Шиккарда (1623) - это механическое устройство, созданное немецким ученым и изобретателем Вильгельмом Шиккардом. Это был первый известный механический калькулятор, предназначенный для выполнения арифметических операций. Устройство состояло из набора зубчатых колес и рычагов, которые взаимодействовали друг с другом для выполнения математических операций. Хотя считающие часы Шиккарда были сложными и ненадежными по сравнению с позднейшими калькуляторами, они стали основой для развития механических вычислительных машин в будущем.", "Scenes/Pascalina", "Assets/Sprites/Exhibits/pascalina.png", "Scenes/Chapters/FirstRoom")));
        }
        objectTestButton.onClick.AddListener(LoadTestScene);
    }

    void LoadTestScene()
    {
        SceneManager.LoadScene("TestScene");
    }

    void LoadExhibitScene(ExhibitData exhibitData)
    {
        ExhibitData.currentExhibit = exhibitData;
        SceneManager.LoadScene("ExhibitScene");
    }
}
