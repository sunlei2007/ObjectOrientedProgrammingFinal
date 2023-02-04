using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFinal
{
    public class Monster
    {
        private int _Id;
        public int Id { get { return _Id; } }
        public string Name { get; set; }

        private int _strength;
        public int Strength
        {
            get { return _strength; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Strength cannot less than zero!");
                }
                _strength = value;
            }
        }
        private int _defence;
        public int Defence
        {
            get { return _defence; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Defence cannot less than zero!");
                }
                _defence = value;
            }
        }

        private int _originalHealth;
        public int OriginalHealth
        {
            get { return _originalHealth; }
            set
            {
                if (value < 100 || value > 200)
                {
                    throw new Exception("OriginalHealth must be between 100 and 200!");
                }
                _originalHealth = value;
            }
        }



        private int? _currentHealth;
        public int? CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("CurrentHealth cannot less than zero!");
                }
                if (value > OriginalHealth)
                {
                    _currentHealth = OriginalHealth;
                }
                else
                {
                    _currentHealth = value;
                }
            }
        }
        public Monster(int id,string name,int strength,int defence,int originalHealth)
        { 
            _Id= id;
            Name = name;
            Strength = strength;
            Defence = defence;
            OriginalHealth = originalHealth;
            CurrentHealth = originalHealth;
            
        }
    }
}
