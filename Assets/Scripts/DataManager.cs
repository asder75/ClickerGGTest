using System;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set; }
    private Save sv = new Save();

    public int Money = 0;
    public int UpPrice = 50;
    public int Damage = 1;
    public int Hp = 5;
    public int Level = 0;
    public int Kills = 0;

    public Text MoneyText;
    public Text UpPriceText;
    public Text DamageText;
    public Text HpText;
    public Text LevelText;
    public Text KillsText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        LoadData();
        ShowUiData();
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));

            Money = sv.Money;
            UpPrice = sv.UpPrice;
            Damage = sv.Damage;
            Hp = sv.Hp;
            Level = sv.Level;
            Kills = sv.Kills;
        }
    }
    private void SaveData()
    {
        sv.Money = Money;
        sv.UpPrice = UpPrice;
        sv.Damage = Damage;
        sv.Hp = Hp;
        sv.Level = Level;
        sv.Kills = Kills;

        PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
    }
    [Serializable]
    public class Save
    {
        public int Money;
        public int UpPrice;
        public int Damage;
        public int Hp;
        public int Level;
        public int Kills;
    }
    public void ShowUiData()
    {
    MoneyText.text = "" + Money;
    UpPriceText.text = "" + UpPrice;
    DamageText.text = "" + Damage;
    HpText.text = "" + Hp;
    LevelText.text = "" + Level;
    KillsText.text = "" + Kills + "/10";
}

#if PLATFORM_ANDROID
    private void OnApplicationPause()
    {
        SaveData();
    }
#endif

#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        SaveData();
    }
#endif
}
