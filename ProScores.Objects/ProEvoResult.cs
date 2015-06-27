using System;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProScores.Objects
{
    public class ProEvoResult
    {    
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string PlayerHome { get; set; }

        [Required, MinLength(3)]
        public string TeamHome { get; set; }

        [Required, MinLength(3)]
        public string PlayerAway { get; set; }

        [Required, MinLength(3)]
        public string TeamAway { get; set; }
       
        public int GoalsHome { get; set; }

        public int GoalsAway { get; set; }

        public DateTime Date { get; set; }

        public string CommentsHome { get; set; }

        public string CommentsAway { get; set; }

        public string GetMergedComments()
        {
            var stringBuilder = new StringBuilder();

            if (!String.IsNullOrEmpty(CommentsHome))
            {
                stringBuilder.Append(PlayerHome);
                stringBuilder.Append(": \"");
                stringBuilder.Append(CommentsHome);
                stringBuilder.Append("\"");
              
                if (!String.IsNullOrEmpty(CommentsAway))
                {
                    // Add a space if we know some more comments are coming...
                    stringBuilder.Append(" ");
                }
            }
            
            if (!String.IsNullOrEmpty(CommentsAway))
            {
                stringBuilder.Append(PlayerAway);
                stringBuilder.Append(": \"");
                stringBuilder.Append(CommentsAway);
                stringBuilder.Append("\"");
            }
          
            return stringBuilder.ToString();
        }

        public void RemoveWhiteSpaceFromTextFields()
        {
            PlayerHome = PlayerHome.Trim();
            PlayerAway = PlayerAway.Trim();
            TeamHome = TeamHome.Trim();
            TeamAway = TeamAway.Trim();
            CommentsHome = CommentsHome != null ? CommentsHome.Trim() : String.Empty;
        }
    }
}