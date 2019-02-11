using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using policecaseapi.Models;
using System.Linq;
using System.Xml.Linq;


namespace policecaseapi.Controllers
{
    [Route("policecase/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class DistriktController : Controller
    {
        //gets single distrikt, located by id
        [HttpGet("{id}")]
        public XElement Get(int id)
        {
            XElement distrikterXML = XElement.Load("xml/distrikter.xml");
            
            var distriktToGet = (from distrikt in distrikterXML.Descendants("sak")
                                 where (int)distrikt.Element("id") == id
                                 select distrikt).SingleOrDefault();

            return distriktToGet;

        }
        
    }
}
