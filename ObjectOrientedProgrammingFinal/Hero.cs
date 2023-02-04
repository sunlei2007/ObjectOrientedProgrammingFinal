using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFinal
{
    public class Hero
    {
        private int _Id;
        public int Id { get { return _Id; } }

        private string _name;
        public string Name 
        {
            get { return _name; }
            set 
            {
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Name must greater than two letters!");
                }
                _name = value; 
            }
        }

        private int _baseStrength;
        public int BaseStrength 
        { 
            get { return _baseStrength; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("BaseStrength cannot less than zero!");
                }
                _baseStrength = value;
            }
        }
        private int _baseDefence;
        public int BaseDefence
        {
            get { return _baseDefence; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("BaseDefence cannot less than zero!");
                }
                _baseDefence = value;
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

        

        private int _currentHealth;
        public int CurrentHealth
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

        public Weapon? EquippedWeapon { get; set; }
        public Armor? EquippedArmor { get; set; }

        public Hero(int id,string name,int baseStrength,int baseDefence, int originalHealth)
        {
            _Id= id;
            Name= name;
            BaseDefence= baseDefence;
            BaseStrength= baseStrength; 
            OriginalHealth= originalHealth;
            CurrentHealth = originalHealth;
        }
    }
}
