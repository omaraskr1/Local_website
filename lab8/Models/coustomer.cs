using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab8.Models
{
	public class coustomer
	{
		public int id { get; set; }
		[Required]
		[StringLength(255)]
		public string name { get; set; }
		public bool issubscribed { get; set; }
		public DateTime? birthday { get; set; }
	}
}