using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class Logger : EditorWindow
{
    [MenuItem("Lol/Logger")]

    public static Logger ShowWindow()
    {
        Logger window = GetWindow<Logger>();

        window.titleContent = new GUIContent("Logger");
        window.minSize = new Vector2(300, 300);

        return window;
    }

     void OnEnable()
    {
        TextField message = new TextField("Сообщение");

        ColorField color = new ColorField("Выбор цвета");
        color.showAlpha = false;

        Button send = new Button(() =>
        {
            Debug.Log("<color='#" + ColorUtility.ToHtmlStringRGB(color.value) + " '>" + message.value + "</color>");
        });

        send.text = "Отправить!";

        rootVisualElement.Add(message);
        rootVisualElement.Add(color);
        rootVisualElement.Add(send);


    }
}
