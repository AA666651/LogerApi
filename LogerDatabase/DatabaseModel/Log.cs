using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogerDatabase.DatabaseModel
{
    public class Log
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public LogType LogType { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }
    }
}