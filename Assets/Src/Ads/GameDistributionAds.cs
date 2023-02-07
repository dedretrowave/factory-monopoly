namespace Src.Ads
{
    public class GameDistributionAds : Base.Ads
    {
        private new void Start()
        {
            base.Start();
            
            GameDistribution.OnRewardedVideoSuccess += InvokeRewardedGameWatched;
            GameDistribution.OnRewardedVideoFailure += InvokeRewardedGameSkipped;
        }
        
        public override void ShowAd()
        {
            GameDistribution.Instance.ShowAd();
        }

        public override void ShowRewardedAd()
        {
            GameDistribution.Instance.ShowRewardedAd();
        }
    }
}