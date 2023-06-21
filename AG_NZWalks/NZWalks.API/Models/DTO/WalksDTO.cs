namespace NZWalks.API.Models.DTO
{
    public class WalksDTO
    {

        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionID { get; set; }
        public Guid WalkDifficultyID { get; set; }
    }
}
