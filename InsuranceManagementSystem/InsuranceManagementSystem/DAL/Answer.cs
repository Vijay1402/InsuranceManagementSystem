using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [ForeignKey("Question")]
        public int QuestionSLNO { get; set; }

        public virtual Questions Question { get; set; }

        [MaxLength(255)] 
        public string AnswerText { get; set; }

        [DataType(DataType.Date)]
        public DateTime AnswerDate { get; set; } = DateTime.Now; 
    }
}

