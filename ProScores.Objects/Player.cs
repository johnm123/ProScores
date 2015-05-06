using System.ComponentModel.DataAnnotations;
namespace ProScores.Objects
{
    public class Player
    {
        [Required, MinLength(3)]
        public string Name { get; set; }

        public void RemoveWhiteSpaceFromTextFields()
        {
            Name = Name.Trim();
        }
    }
}
