using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourcesController : MonoBehaviour
{
    public List<TextAsset> GetAllCountriesTextAssset()
    {
        return Resources.LoadAll<TextAsset>("Countries/").ToList();
    }

    public List<TextAsset> GetAllDepartmentsTextAsset()
    {
        return Resources.LoadAll<TextAsset>("Departments/").ToList();
    }

    public List<Country> GetAllCountries()
    {
        List<TextAsset> textCountries = GetAllCountriesTextAssset();

        List<Country> classType = new List<Country>();

        foreach (TextAsset asset in textCountries)
        {
            Country s = JsonUtility.FromJson<Country>(asset.text);

            classType.Add(s);
        }

        return classType;
    }

    public List<Department> GetAllDepartments()
    {
        List<TextAsset> textAssets = GetAllDepartmentsTextAsset();

        List<Department> classType = new List<Department>();

        foreach (TextAsset asset in textAssets)
        {
            Department department = JsonUtility.FromJson<Department>(asset.text);

            classType.Add(department);
        }

        return classType;
    }

    public Sprite GetFlagSprite(string countryName)
    {
        return Resources.Load<Sprite>("Sprites/Flags" + countryName + "image");
    }
}
