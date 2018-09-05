namespace Services
{
    public class PlayerStartsService
    {
        /// <summary>
        /// Current cherries
        /// </summary>
        public int Cherries { get; set; }

        /// <summary>
        /// Current health
        /// </summary>
        public int Health { get; set; }
        
        /// <summary>
        /// Player damage
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Has paused
        /// </summary>
        public bool HasPaused { get; set; }

        /// <summary>
        /// Has game over
        /// </summary>
        public bool HasGameOver { get; set; }
    }
}