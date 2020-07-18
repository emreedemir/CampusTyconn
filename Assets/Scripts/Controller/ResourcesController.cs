using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using CampusTyconn;

public class ResourcesController : MonoBehaviour
{
    private List<SocialEvent> socialEvents;

    private List<Feature> characterFeatures;

    public List<Feature> allCharacterFeature
    {
        get
        {
            if (characterFeatures == null)
            {
                characterFeatures = InitiliazeCharacterFeatures(GameController.Instance.characterData);
            }
            return characterFeatures;
        }
    }

    public List<SocialEvent> allSocialEvents
    {
        get
        {
            if (socialEvents == null)
            {
                socialEvents = InitiliazeSocialEvents(GameController.Instance.characterData);
            }
            return socialEvents;
        }
    }

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

    public List<SocialEvent> InitiliazeSocialEvents(CharacterData characterData)
    {
        List<SocialEvent> socialEvents = new List<SocialEvent>();

        SocialEvent partySocialEvent =
            SocialEventBuilder.CreateNewEvent().SetEventName("Give A Party").
            SetEventCost(100).SetEventMessage("Nice Party").AddTargetFeatureToEvent(new KeyValuePair<Feature, int>(characterData.popularity, 20)).
            AddTargetFeatureToEvent(new KeyValuePair<Feature, int>(characterData.respect, 5));


        socialEvents.Add(partySocialEvent);

        SocialEvent cinema = SocialEventBuilder.CreateNewEvent().SetEventName("Go Cinema").
            SetEventCost(10).SetEventMessage("Interesting Film").AddTargetFeatureToEvent(new KeyValuePair<Feature, int>(characterData.selfRealization, 10));

        socialEvents.Add(cinema);

  
        SocialEvent meetFriends = SocialEventBuilder.CreateNewEvent().SetEventName("Meet Friends")
            .SetEventCost(20).SetEventMessage("Entertaining Meet").AddTargetFeatureToEvent(new KeyValuePair<Feature, int>(characterData.happiness, 10));

        socialEvents.Add(meetFriends);


        SocialEvent concert = SocialEventBuilder.CreateNewEvent().SetEventName("Go Concert")
            .SetEventCost(50).SetEventMessage("Nice Signs").AddTargetFeatureToEvent(new KeyValuePair<Feature, int>(characterData.selfRealization, 10))
            .AddTargetFeatureToEvent(new KeyValuePair<Feature, int>(characterData.happiness, 5));

        socialEvents.Add(concert);

        return socialEvents;
    }

    public CharacterData GetCharacterData()
    {
        TextAsset textCharacterDataAsset = Resources.Load<TextAsset>("/CharacterData");

        CharacterData newCharacterData = JsonUtility.FromJson<CharacterData>(textCharacterDataAsset.text);

        return newCharacterData;
    }

    public List<Feature> InitiliazeCharacterFeatures(CharacterData characterData)
    {
        List<Feature> features = new List<Feature>();

        features.Add(characterData.health);

        features.Add(characterData.popularity);

        features.Add(characterData.respect);

        features.Add(characterData.selfRealization);

        return features;
    }
}
