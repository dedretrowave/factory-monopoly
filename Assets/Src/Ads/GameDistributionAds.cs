namespace Src.Ads
{
    public class GameDistributionAds : Base.Ads
    {
        public override void ShowAd()
        {
            GameDistribution.Instance.ShowAd();
        }
    }
}