namespace Src.Ads
{
    public class GameMonetizeAds : Base.Ads
    {
        public override void ShowAd()
        {
            GameMonetize.Instance.ShowAd();
        }

        public override void ShowRewardedAd()
        {
            GameMonetize.Instance.ShowAd();
        }
    }
}