using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System;
namespace ProScores.Objects
{
    public class Player
    {
        [Required, MinLength(3)]
        public string Name { get; set; }

        private string _displayName;

        public string DisplayName
        {
            set { _displayName = value; }
            get
            {
                if (string.IsNullOrEmpty(_displayName))
                {
                    return Name;
                }
                return _displayName;
            }
        }

        public void RemoveWhiteSpaceFromTextFields()
        {
            Name = Name.Trim();            
        }
    }
}
