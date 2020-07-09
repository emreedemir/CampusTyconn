using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CountryEditor : EditorWindow
{
    public string countryName = "Country Name";

    public string economy = "1 from 10";

    public string freedom = "1 from 10";

    public string humanity = "1 from 10";

    public string universityCount = "1";

    public int uCount = 0;

    Vector2 scrollPos;

    List<CEClas<string, string, string>> universites;
    private void OnEnable()
    {
        universites = new List<CEClas<string, string, string>>();
    }

    [MenuItem("Campustan/Create Country")]
    public static void ShowWindow()
    {
        EditorWindow window = EditorWindow.GetWindow(typeof(CountryEditor));

        window.minSize = new Vector2(300, 700);

    }

    private void OnGUI()
    {
        GUILayout.Label("Country Name");

        countryName = GUILayout.TextField(countryName);

        GUILayout.Label("Economy");

        economy = GUILayout.TextField(economy);

        GUILayout.Label("Freedom");

        freedom = GUILayout.TextField(freedom);

        GUILayout.Label("Humanity");

        humanity = GUILayout.TextField(humanity);


        /*
         * 
         *   GUILayout.Label("University Count");

        universityCount = GUILayout.TextField(universityCount);

        GUILayout.BeginVertical();

        scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(300), GUILayout.Height(300));

        for (int i = 0; i < uCount; i++)
        {
            GUILayout.Label("University Name");

            universites[i].val1 = GUILayout.TextField(universites[i].val1);

            GUILayout.Label("University Difficulty");

            universites[i].val2 = GUILayout.TextField(universites[i].val2);

            GUILayout.Label("University feeCof");

            universites[i].val3 = GUILayout.TextField(universites[i].val3);
        }

        GUILayout.EndScrollView();

        GUILayout.EndVertical();

        if (GUILayout.Button("Create Universities"))
        {
            universites.Clear();

            uCount = int.Parse(universityCount);

            for (int i = 0; i < uCount; i++)
            {
                CEClas<string, string, string> x = new CEClas<string, string, string>();

                x.val1 = "University Name";

                x.val2 = "University Diffuclty";

                x.val3 = "University feeCof";

                universites.Add(x);
            }
        }
        */

        if (GUILayout.Button("Save Country"))
        {
            CreateCountry();
        }
    }

    public void CreateCountry()
    {
       
        Country country = new Country(countryName, int.Parse(economy), int.Parse(freedom), int.Parse(humanity));

        string countryText = JsonUtility.ToJson(country, true);

        string filePath = Application.dataPath + "/Resources/Countries/" + country.countryName + ".json";

        File.WriteAllText(filePath, countryText);

        Debug.Log("Country Saved");
    }
}
class CEClas<T, G, C>
{
    public T val1;
    public G val2;
    public C val3;
}

