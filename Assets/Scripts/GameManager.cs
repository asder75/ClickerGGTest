using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DataManager dm;
    private void Awake()
    {
        Invoke(nameof(LoadBannerAd), 6f);
    }
    public void AttackCheck()
    {
#if PLATFORM_ANDROID
    if(Input.touchCount == 1)
        {
            Attack();
        }
#endif

#if UNITY_EDITOR
        Attack();
#endif
    }
    private void Attack()
    {
        dm.Hp -= dm.Damage;

        if(dm.Hp <= 0)
        {
            dm.Hp = dm.Level + 5;
            dm.Kills++;
            dm.Money += dm.Level;

            if (dm.Kills == 10)
            {
                dm.Kills = 0;
                dm.Level++;
            }
        }

        dm.ShowUiData();
    }
    public void UpDamage()
    {
        if(dm.Money >= dm.UpPrice)
        {
            dm.Money -= dm.UpPrice;
            dm.Damage += 1;
            dm.UpPrice += 50;
        }

        dm.ShowUiData();
    }
    private void LoadBannerAd()
    {
        BannerScript.instance.LoadBanner();
    }
}
