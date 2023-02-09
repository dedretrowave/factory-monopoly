namespace Src.Ads
{
    public class GameArterAds : Base.Ads
    {
        public override void ShowAd()
        {
            Garter.I.RequestAd("adUnitId");
        }

        public override void ShowRewardedAd()
        {
            Garter.I.RequestAd("adUnitId", (state) =>
            {
                switch (state)
                {
                    case "completed":
                        InvokeRewardedGameWatched();
                        break;
                    case "failed":
                        InvokeRewardedGameSkipped();
                        break;
                    default:
                        break;
                }
            });
        }
    }
}