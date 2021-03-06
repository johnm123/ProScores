﻿using System;
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

        public MergedComments MergedComments()
        {
            return new MergedComments()
                   {
                       CommentsAway = CommentsAway,
                       CommentsHome = CommentsHome,
                       PlayerAway = PlayerAway, 
                       PlayerHome = PlayerHome
                   };
        }

        public void RemoveWhiteSpaceFromTextFields()
        {
            PlayerHome = PlayerHome.Trim();
            PlayerAway = PlayerAway.Trim();
            TeamHome = TeamHome.Trim();
            TeamAway = TeamAway.Trim();
            CommentsHome = CommentsHome != null ? CommentsHome.Trim() : String.Empty;
            CommentsAway = CommentsAway != null ? CommentsAway.Trim() : String.Empty;
        }
    }
}