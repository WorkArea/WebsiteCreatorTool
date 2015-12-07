using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations.Schema;


namespace WebsiteCreatorTool.Data.Entities
{
    //Table["SampleTable"]
    public class SampleEntity
    {
        public int SampleId { get; set; }
        public int ForeignId { get; set; }
        public string Title { get; set; }
    }
}
