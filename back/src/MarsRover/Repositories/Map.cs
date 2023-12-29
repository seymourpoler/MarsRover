namespace MarsRover.Repositories
{
    public class Map
    {
        public int Id { get; set; }
        public int Horizontal { get; set; }
        public int Vertical { get; set; }
        public List<Obstacle> Obstacles { get; set; }
    }
}
