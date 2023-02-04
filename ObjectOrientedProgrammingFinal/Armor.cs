namespace ObjectOrientedProgrammingFinal
{
    public class Armor
    {
        private int _Id;
        public int Id { get { return _Id; } }
        public string Name { get; set; }

        private int _power;
        public int Power
        {
            get { return _power; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Power cannot less than zero!");
                }
                _power = value;
            }
        }

        public Armor(int id, string name, int power)
        {
            _Id = id;
            Name = name;
            Power = power;
        }

    }
}