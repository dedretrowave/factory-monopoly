using CrazyGames;

namespace Src.Ads
{
    public class CrazyGamesAds : Base.Ads
    {
        public override void ShowAd()
        {
            CrazyAds.Instance.beginAdBreak();
        }

        public override void ShowRewardedAd()
        {
            CrazyAds.Instance.beginAdBreakRewarded(InvokeRewardedGameWatched);
        }
    }
}