using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System;
namespace ProScores.Objects
{
    public class Player
    {
        [Required, MinLength(3)]
        public string Name { get; set; }

        public string NickName { get; set; }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(this.NickName))
                {
                    return this.Name;
                }
                return this.NickName;
            }
        }

        public void RemoveWhiteSpaceFromTextFields()
        {
            Name = Name.Trim();            
        }
    }
}
